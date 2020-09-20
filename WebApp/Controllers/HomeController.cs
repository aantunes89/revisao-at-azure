using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.ApiServices;
using WebApp.Models;
using WebApp.Models.Home;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPessoaApi pessoaApi;

        public HomeController(ILogger<HomeController> logger, IPessoaApi pessoaApi)
        {
            _logger = logger;
            this.pessoaApi = pessoaApi;
        }

        public async Task<IActionResult> Index()
        {
            var paginaInicial = new PaginaInicialViewModel();
            paginaInicial.QuantidadeDeCarros = 190;
            paginaInicial.QuantidadeDeFabricantes = 1234;
            paginaInicial.QuantidadeDeProprietarios = 4563;

            var pessoas = await pessoaApi.GetPessoas();
            paginaInicial.QuantidadeDePessoas = pessoas.Count;

            return View(paginaInicial);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
