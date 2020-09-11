using System.Collections.Generic;

namespace WebApiCarro.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public List<Carro> Carros { get; set; }
    }
}
