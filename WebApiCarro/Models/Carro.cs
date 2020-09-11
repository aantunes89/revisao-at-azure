using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCarro.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Foto { get; set; }
    }
}
