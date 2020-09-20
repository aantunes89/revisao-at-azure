using System;
using System.Collections.Generic;

namespace WebApp.Models.Pessoa
{
    public class CriarPessoaViewModel
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }

        public List<CarroViewModel> Carros { get; set; }
        public int CarroId { get; set; }
    }
}
