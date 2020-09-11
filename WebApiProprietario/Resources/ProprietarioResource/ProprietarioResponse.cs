using System;

namespace WebApiProprietario.Resources.ProprietarioResource
{
    public class ProprietarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
    }


}
