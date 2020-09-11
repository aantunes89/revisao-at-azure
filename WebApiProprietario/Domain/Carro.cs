using System;

namespace WebApiProprietario.Domain
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public Guid ProprietarioId { get; set; }
    }
}
