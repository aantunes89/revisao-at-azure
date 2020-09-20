using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Pessoa
{

    public class CadastrarFilhoViewModel
    {
        public int PessoaId { get; set; }
        public int[] FilhoIds { get; set; }
    }
}
