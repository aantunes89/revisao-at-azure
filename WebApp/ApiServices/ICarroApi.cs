using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Pessoa;

namespace WebApp.ApiServices
{
    public interface ICarroApi
    {
        Task<List<CarroViewModel>> GetCarros();
        Task<CarroViewModel> GetCarro(int id);
    }
}
