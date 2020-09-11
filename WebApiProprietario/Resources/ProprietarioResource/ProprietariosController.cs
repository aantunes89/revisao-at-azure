using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiProprietario.Data;
using AutoMapper;
using WebApiProprietario.Domain;

namespace WebApiProprietario.Resources.ProprietarioResource
{
    [ApiController]
    [Route("api/proprietarios")]
    public class ProprietariosController : ControllerBase
    {
        private readonly WebApiProprietarioContext _context;
        private readonly IMapper _mapper;

        public ProprietariosController(WebApiProprietarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var list = BuscarProprietarios();

            return Ok(list); //200
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] Guid id)
        {
            var response = BuscarProprietarioPor(id);

            if (response == null)
                return NotFound(); //404

            return Ok(response); //200
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProprietarioRequest proprietarioRequest)
        {
            var erros = proprietarioRequest.Erros();

            if (erros.Any())
                return UnprocessableEntity(erros); //422

            var response = CriarProprietario(proprietarioRequest);

            return CreatedAtAction(nameof(Get), new { response.Id }, response); //201
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] ProprietarioRequest request)
        {
            var response = BuscarProprietarioPor(id);

            if (response == null)
                return NotFound(); //404

            AlterarProprietario(id, request);

            return NoContent(); //204
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var response = BuscarProprietarioPor(id);

            if (response == null)
                return NotFound(); //404

            ExcluirProprietario(id);

            return NoContent(); //204
        }

        //id
        [HttpGet("{id}/carros")]
        public ActionResult GetCarrosDoProprietario([FromRoute] Guid id)
        {
            var proprietario = _context.Proprietarios.Find(id);

            if (proprietario == null)
                return NotFound(); //404

            var carros = _context.Carros.Where(x => x.ProprietarioId == id).ToList();

            var response = _mapper.Map<List<CarroResponse>>(carros);

            return Ok(response);
        }

        [HttpPost("{id}/carros")]
        public ActionResult PostCarrosDoProprietario([FromRoute]Guid id, [FromBody] CarroRequest request)
        {
            var proprietario = _context.Proprietarios.Find(id);

            if (proprietario == null)
                return NotFound(); //404

            var response = CriarCarro(id, request);

            return CreatedAtAction(nameof(PostCarrosDoProprietario), new { response.Id }, response); //201
        }

        private IEnumerable<ProprietarioResponse> BuscarProprietarios()
        {
            var proprietarios = _context.Proprietarios.ToList();

            return _mapper.Map<IEnumerable<ProprietarioResponse>>(proprietarios);
        }

        private ProprietarioResponse BuscarProprietarioPor(Guid id)
        {
            var proprietario = _context.Proprietarios.Find(id);

            if (proprietario == null)
                return null;

            return _mapper.Map<ProprietarioResponse>(proprietario);
        }

        private ProprietarioResponse CriarProprietario(ProprietarioRequest proprietarioRequest)
        {
            var proprietario = _mapper.Map<Proprietario>(proprietarioRequest);
            proprietario.Id = Guid.NewGuid();

            _context.Proprietarios.Add(proprietario);
            _context.SaveChanges();

            return _mapper.Map<ProprietarioResponse>(proprietario);
        }

        private void AlterarProprietario(Guid id, ProprietarioRequest request)
        {
            var proprietario = _context.Proprietarios.Find(id);

            proprietario = _mapper.Map(request, proprietario);

            _context.Proprietarios.Update(proprietario);
            _context.SaveChanges();
        }

        private void ExcluirProprietario(Guid id)
        {
            var proprietario = _context.Proprietarios.Find(id);

            if (proprietario == null)
                return;

            _context.Proprietarios.Remove(proprietario);
            _context.SaveChanges();
        }

        private CarroResponse CriarCarro(Guid proprietarioId, CarroRequest request)
        {
            var carro = _mapper.Map<Carro>(request);
            carro.ProprietarioId = proprietarioId;

            _context.Carros.Add(carro);
            _context.SaveChanges();

            var response = _mapper.Map<CarroResponse>(carro);

            return response;
        }
    }
}
