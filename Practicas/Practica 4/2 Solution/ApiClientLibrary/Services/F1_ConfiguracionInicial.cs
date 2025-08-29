using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http.Headers;
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

        /// <summary>
        /// Permite cambiar manualmente el token de autorización (ej. para pruebas).
        /// </summary>
        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
        private async Task<HttpResponseMessage> PostAsync<T>(string url, T dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            return response;
        }

        #region EstadoSID
        public async Task<HttpResponseMessage> RegistrarEstadoSID()
        {
            var estado = new EstadoSIDDTO { Estado = "EN_PRUEBAS" };
            HttpResponseMessage response = await PostAsync("EstadoSID", estado);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarEstadoSID_DatosInvalidos()
        {
            var estado = new EstadoSIDDTO { Estado = "" };
            HttpResponseMessage response = await PostAsync("EstadoSID", estado);
            return response;
        }
        #endregion


        #region OtrasPruebasyDocumentos
        public async Task<HttpResponseMessage> RegistrarPruebaODocumento() {
            var obj = new OtrasPruebasYDocumentosDTO { 
            Id="",
            TipoDocumento= "PruebasRutina",
            DescripcionDocumento="Prueba de rutina al equipo",
            UrlArchivo= "https://www.cfe.mx",
            MD5="",
            Estatus="ACTIVO",
            Vigencia=new DateTime(2026,2,9),
            FechaRegistro=DateTime.Now
            };
            HttpResponseMessage response = await PostAsync("OtrasPruebasYDocumentos", obj);
            return response;
        }
        #endregion
    }
}
