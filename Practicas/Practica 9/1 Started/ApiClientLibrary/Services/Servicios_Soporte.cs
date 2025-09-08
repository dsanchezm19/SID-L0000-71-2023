using ApiClientLibrary.Models;
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
    public class Servicios_Soporte
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "Servicios_Soporte/";
        public Servicios_Soporte()
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

        

        #region Documentos
        public async Task<HttpResponseMessage> AgregarDocumento()
        {
          throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> ObtenerDocumentos()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> ActualizarDocumento()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> EliminarDocumento() {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> AgregarDocumento_DatosInvalidos()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> ActualizarDocumento_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Aplicacion
        public async Task<HttpResponseMessage> AgregarAplicacion()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> ObtenerAplicaciones()
        {
            throw new NotImplementedException();

        }

        public async Task<HttpResponseMessage> ActualizarAplicacion()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> ActualizarAplicacion_BadRequest()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> EliminarAplicacion()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
