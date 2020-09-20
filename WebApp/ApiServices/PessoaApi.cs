using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Pessoa;

namespace WebApp.ApiServices
{
    public class PessoaApi : IPessoaApi
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly ICarroApi carroApi;

        public PessoaApi(ICarroApi carroApi)
        {
            this.carroApi = carroApi;
        }

        public async Task<List<DadosPessoaViewModel>> GetFilhos(int id)
        {
            var response = await httpClient.GetAsync($"https://localhost:44301/api/pessoas/{id}/filhos");

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<List<DadosPessoaViewModel>>(content);

            return viewModel;
        }

        public async Task<List<DadosPessoaViewModel>> GetPessoas()
        {
            var response = await httpClient.GetAsync($"https://localhost:44301/api/pessoas");

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<List<DadosPessoaViewModel>>(content);

            return viewModel;
        }

        public async Task<DadosPessoaViewModel> GetPessoa(int id)
        {
            var response = await httpClient.GetAsync($"https://localhost:44301/api/pessoas/" + id);

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<DadosPessoaViewModel>(content);

            viewModel.Carro = await carroApi.GetCarro(viewModel.CarroId);

            return viewModel;
        }

        public Task PostFilhos(int pessoaId, int[] ids)
        {
            var idsAsJson = JsonConvert.SerializeObject(new { ids });

            var content = new StringContent(idsAsJson, Encoding.UTF8, "application/json");

            httpClient.PostAsync($"https://localhost:44301/api/pessoas/{pessoaId}/filhos", content);

            return Task.CompletedTask;
        }

        public Task PostPessoa(CriarPessoaViewModel form)
        {
            var json = JsonConvert.SerializeObject(form);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            httpClient.PostAsync($"https://localhost:44301/api/pessoas", content);

            return Task.CompletedTask;
        }
    }
}
