using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPessoa.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public List<Pessoa> Filhos { get; set; } = new List<Pessoa>();
        public int CarroId { get; set; }
    }
}
