using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Proprietario;

namespace WebApp.ApiServices
{
    public class ProprietarioApi : IProprietarioApi
    {
        private readonly HttpClient _httpClient;

        public ProprietarioApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("http://localhost:53964/");
        }

        public async Task<CriarProprietarioViewModel> PostAsync(CriarProprietarioViewModel criarProprietarioViewModel)
        {
            var criarProprietarioViewModelJson = JsonConvert.SerializeObject(criarProprietarioViewModel);

            var conteudo = new StringContent(criarProprietarioViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/proprietarios", conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarProprietarioViewModel;
            }
            else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                criarProprietarioViewModel.Erros = erros;
            }

            return criarProprietarioViewModel;
        }

        public async Task<List<ListarProprietarioViewModel>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/proprietarios");

            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<ListarProprietarioViewModel>>(responseContent);

            return list;
        }
    }
}
