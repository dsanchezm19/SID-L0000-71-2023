using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
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


        #region ContratoCFE
        public async Task<HttpResponseMessage> RegistrarContratoCFE()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> RegistrarContratoCFEExistente_NoRegistraContratoCFE()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> RegistrarContratoCFE_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> RegistrarContratoCFE_UrlArchivo_Invalida()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarContratoCFE()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> RegistrarContratoCFEConGarantia()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> RegistrarContratoCFEConGarantia_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarContratoCFE_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarContratoCFEConGarantia()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarContratoCFEConGarantia_DatosInvalidos()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region ContratoParticular
        public async Task<HttpResponseMessage> RegistrarContratoParticular()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> RegistrarContratoParticular_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarContratoParticular()
        {
            throw new NotImplementedException();
        }
        public async Task<HttpResponseMessage> ActualizarContratoParticular_DatosInvalidos()
        {
            throw new NotImplementedException();
        }
        #endregion
        public async Task<HttpResponseMessage> ObtenerContratos(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
