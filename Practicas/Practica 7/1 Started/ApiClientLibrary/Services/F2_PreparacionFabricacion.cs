using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClientLibrary.Services
{
    public class F2_PreparacionFabricacion
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F2_PreparacionFabricacion/";
        public F2_PreparacionFabricacion()
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

        public async Task<HttpResponseMessage> AgregarMuestraExpediente_Exitoso()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> AgregarMuestraExpediente_MuestraDuplicada_Error()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> AgregarMuestraExpediente_NoExisteExpediente()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> AgregarMuestraExpediente_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> QuitarMuestraExpediente_Exitoso()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> QuitarMuestraExpediente_NoExisteExpediente()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> QuitarMuestraExpediente_NoExisteMuestra()
        {
            throw new NotImplementedException();
        }
    }
}
