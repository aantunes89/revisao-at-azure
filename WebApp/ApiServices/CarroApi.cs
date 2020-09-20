using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models.Pessoa;

namespace WebApp.ApiServices
{
    public class CarroApi : ICarroApi
    {
        private readonly HttpClient httpClient;

        public CarroApi()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44351");
        }

        public async Task<CarroViewModel> GetCarro(int id)
        {
            var response = await httpClient.GetAsync($"api/carros/" + id);

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<CarroViewModel>(content);

            return viewModel;
        }

        public async Task<List<CarroViewModel>> GetCarros()
        {
            var response = await httpClient.GetAsync($"api/carros");

            var content = await response.Content.ReadAsStringAsync();

            var viewModel = JsonConvert.DeserializeObject<List<CarroViewModel>>(content);

            return viewModel;
        }
    }
}
