using ApiStarWar.Interface;
using ApiStarWar.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiStarWar.ServiceClient
{
    public class ClientGet : IRequetMethods
    {
        private readonly HttpClient _httpClient;

        public ClientGet(HttpClient http)
        {
            _httpClient = http; 
        }

        public async Task<Filmes> GetFilmes(int pagina)
        {
            //_httpClient.BaseAddress = new Uri($"https://swapi.dev/api/films/{pagina}/");
            var result = await _httpClient.GetStringAsync($"https://swapi.dev/api/films/{pagina}/");
            var jsonSerealizer = JsonConvert.DeserializeObject<Filmes>(result);
            return jsonSerealizer;
        }

        public async Task<Planetas> GetPlaneta(int pagina)
        {
            //_httpClient.BaseAddress = new Uri($"https://swapi.dev/api/films/{pagina}/");
            var result = await _httpClient.GetStringAsync($"https://swapi.dev/api/people/{pagina}/");
            var jsonSerealizer = JsonConvert.DeserializeObject<Planetas>(result);
            return jsonSerealizer;
        }

        public async Task<Species> GetSpecies(int pagina)
        {
            //_httpClient.BaseAddress = new Uri($"https://swapi.dev/api/films/{pagina}/");
            var result = await _httpClient.GetStringAsync($"https://swapi.dev/api/species/{pagina}/");
            var jsonSerealizer = JsonConvert.DeserializeObject<Species>(result);
            return jsonSerealizer;
        }

        public async Task<Veiculo> GetVeiculo(int pagina)
        {
            var result = await _httpClient.GetStringAsync($"https://swapi.dev/api/vehicles/{pagina}/");
            var jsonSerealizer = JsonConvert.DeserializeObject<Veiculo>(result);
            return jsonSerealizer;
        }
    }
}
