using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F1_ConfiguracionInicial
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;        
        public F1_ConfiguracionInicial()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"])
            };

            var token = _configuration["ApiSettings:Token"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public F1_ConfiguracionInicial(string token)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"])
            };

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

        }


        public async Task<HttpResponseMessage> RegistrarEstadoSID(EstadoSIDDTO estado)
        {
            var json = JsonSerializer.Serialize(estado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("EstadoSID", content);

            return response;
        }
    }
}
