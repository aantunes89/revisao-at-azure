using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.ApiServices;
using WebApp.Models.Pessoa;

namespace WebApp.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaApi pessoaApi;
        private readonly ICarroApi carroApi;

        public PessoaController(IPessoaApi pessoaApi, ICarroApi carroApi)
        {
            this.pessoaApi = pessoaApi;
            this.carroApi = carroApi;
        }

        // GET: PessoaController
        public async Task<ActionResult> Index()
        {
            var viewModel = await pessoaApi.GetPessoas();

            return View(viewModel);
        }

        // GET: PessoaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var viewModel = await pessoaApi.GetPessoa(id);

            return View(viewModel);
        }

        // GET: PessoaController/Create
        public async Task<ActionResult> Create()
        {
            var viewModel = new CriarPessoaViewModel();

            viewModel.Carros = await carroApi.GetCarros();

            return View(viewModel);
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CriarPessoaViewModel viewModel)
        {
            try
            {
                await pessoaApi.PostPessoa(viewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Filhos(int id)
        {
            var viewModel = new ListarFilhosViewModel();
            viewModel.Filhos = await pessoaApi.GetFilhos(id);

            var pessoas = await pessoaApi.GetPessoas();
            viewModel.Pessoas = pessoas;
            viewModel.Pessoa = pessoas.First(x => x.Id == id);

            pessoas.Remove(viewModel.Pessoa);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Filhos([FromForm] CadastrarFilhoViewModel viewModel)
        {
            await pessoaApi.PostFilhos(viewModel.PessoaId, viewModel.FilhoIds);

            return RedirectToAction(nameof(Filhos), new { Id = viewModel.PessoaId });
        }
    }
}
