using System;
using System.Collections.Generic;

namespace WebApiProprietario.Domain
{
    public class Proprietario
    {
        public Guid Id { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public virtual List<Carro> Carros { get; set; }
    }
}
