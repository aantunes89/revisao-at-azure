using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Pessoa
{
    public class DadosPessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public CarroViewModel Carro { get; set; }
        public int CarroId { get; set; }
    }
}
