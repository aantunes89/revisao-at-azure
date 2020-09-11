using System.Collections.Generic;

namespace WebApiProprietario.Resources.ProprietarioResource
{
    public class ProprietarioRequest
    {
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public List<string> Erros()
        {
            var list = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome))
                list.Add("Nome é obrigatório");

            return list;
        }
    }


}
