using System.Collections.Generic;

namespace WebApp.Models.Pessoa
{
    public class ListarFilhosViewModel
    {
        public List<DadosPessoaViewModel> Pessoas { get; set; }
        public DadosPessoaViewModel Pessoa { get; set; }
        public List<DadosPessoaViewModel> Filhos { get; set; }
    }
}
