using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Proprietario;

namespace WebApp.ApiServices
{
    public interface IProprietarioApi
    {
        Task<CriarProprietarioViewModel> PostAsync(CriarProprietarioViewModel criarProprietarioViewModel);
        Task<List<ListarProprietarioViewModel>> GetAsync();
    }
}
