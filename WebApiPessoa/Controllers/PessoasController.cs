using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPessoa.Data;
using WebApiPessoa.Models;

namespace WebApiPessoa.Controllers
{
    [ApiController]
    [Route("api/pessoas")]
    public class PessoasController : ControllerBase
    {
        private readonly WebApiPessoaContext _context;
        private readonly IMapper mapper;

        public PessoasController(WebApiPessoaContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
        {
            var pessoas = await _context.Pessoa.ToListAsync();

            var response = mapper.Map<List<PessoaResponse>>(pessoas);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }

        [HttpGet("{id}/filhos")]
        public async Task<ActionResult> GetFilhos(int id)
        {
            var pessoa = await _context.Pessoa.Include(x => x.Filhos).FirstOrDefaultAsync(x => x.Id == id);

            if (pessoa == null)
                return NotFound();

            var response = mapper.Map<List<PessoaResponse>>(pessoa.Filhos);

            return Ok(response);
        }

        [HttpPost("{id}/filhos")]
        public async Task<ActionResult> PostFilhos([FromRoute]int id, [FromBody] PostFilhosRequest request)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);

            if (pessoa == null)
                return NotFound();

            var filhos = await _context.Pessoa.Where(x => request.Ids.Contains(x.Id)).ToListAsync();

            pessoa.Filhos = filhos;

            _context.Pessoa.Update(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class PessoaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }

    public class PostFilhosRequest
    {
        public int[] Ids { get; set; }
    }
}
