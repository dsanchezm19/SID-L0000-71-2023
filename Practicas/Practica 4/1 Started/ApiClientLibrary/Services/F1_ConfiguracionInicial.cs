using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F1_ConfiguracionInicial
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F1_ConfiguracionInicial/";
        public F1_ConfiguracionInicial()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{_configuration["ApiSettings:BaseUrl"]}{_basePath}")
            };

            var token = _configuration["ApiSettings:Token"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
        
        private async Task<HttpResponseMessage> PutAsJsonAsync<T>(string url, T dto)
        {
            throw new NotImplementedException();
        }

        #region OtrasPruebasyDocumentos
        public async Task<HttpResponseMessage> RegistrarPruebaODocumento() {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> RegistrarPruebaODocumento_TipoDocumentoInvalido()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> RegistrarPruebaODocumento_URLArchivoInvalida()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarPruebaODocumento_URLArchivo_Exitoso()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarPruebaODocumento_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ObtenerPruebaODocumentos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
