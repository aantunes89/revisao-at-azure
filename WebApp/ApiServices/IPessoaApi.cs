using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Pessoa;

namespace WebApp.ApiServices
{
    public interface IPessoaApi
    {
        Task PostPessoa(CriarPessoaViewModel form);
        Task PostFilhos(int pessoaId, int[] ids);
        Task<List<DadosPessoaViewModel>> GetPessoas();
        Task<DadosPessoaViewModel> GetPessoa(int id);
        Task<List<DadosPessoaViewModel>> GetFilhos(int id);
    }
}
