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
        private async Task<HttpResponseMessage> PostAsync<T>(string url, T dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            return response;
        }

        private async Task<HttpResponseMessage> PutAsJsonAsync<T>(string url, T dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsJsonAsync(url, dto);
            return response;
        }

        #region OtrasPruebasyDocumentos
        public async Task<HttpResponseMessage> RegistrarPruebaODocumento() {
            var obj = new OtrasPruebasYDocumentosDTO { 
            Id="",
            TipoDocumento= "Prueba Rutina",
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
        public async Task<HttpResponseMessage> RegistrarPruebaODocumento_TipoDocumentoInvalido()
        {
            var obj = new OtrasPruebasYDocumentosDTO
            {
                Id = "",
                TipoDocumento = "PruebaDeRutina",
                DescripcionDocumento = "Prueba de rutina al equipo",
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                Estatus = "ACTIVO",
                Vigencia = new DateTime(2026, 2, 9),
                FechaRegistro = DateTime.Now
            };
            HttpResponseMessage response = await PostAsync("OtrasPruebasYDocumentos", obj);
            return response;
        }
        public async Task<HttpResponseMessage> RegistrarPruebaODocumento_URLArchivoInvalida()
        {
            var obj = new OtrasPruebasYDocumentosDTO
            {
                Id = "",
                TipoDocumento = "PruebaDeRutina",
                DescripcionDocumento = "Prueba de rutina al equipo",
                UrlArchivo = "C:/MisDocumentos",
                MD5 = "",
                Estatus = "ACTIVO",
                Vigencia = new DateTime(2026, 2, 9),
                FechaRegistro = DateTime.Now
            };
            HttpResponseMessage response = await PostAsync("OtrasPruebasYDocumentos", obj);
            return response;
        }
        public async Task<HttpResponseMessage> ActualizarPruebaODocumento_URLArchivo_Exitoso()
        {
            var obj = new OtrasPruebasYDocumentosDTO
            {
                Id = "68b74b041508cbf69f2cd733",
                TipoDocumento = "Prueba Rutina",
                DescripcionDocumento = "Prueba de rutina",
                UrlArchivo = "https://www.cfe.gob.mx/transparencia_etica/Pages/default.aspx",
                MD5 = "",
                Estatus = "ACTIVO",
                Vigencia = new DateTime(2026, 2, 9),
                FechaRegistro = DateTime.Now
            };
            HttpResponseMessage response = await PutAsJsonAsync("OtrasPruebasYDocumentos", obj);
            return response;
        }
        public async Task<HttpResponseMessage> ActualizarPruebaODocumento_DatosInvalidos()
        {
            var obj = new OtrasPruebasYDocumentosDTO
            {
                Id = "",
                TipoDocumento = "PruebaRutina",
                DescripcionDocumento = "CertificadoMaterial",
                UrlArchivo = "https://www.cfe.gob.mx",
                MD5 = "",
                Estatus = "ACTIVO",
                Vigencia = new DateTime(2026, 2, 9),
                FechaRegistro = DateTime.Now
            };
            HttpResponseMessage response = await PutAsJsonAsync("OtrasPruebasYDocumentos", obj);
            return response;
        }
        public async Task<HttpResponseMessage> ObtenerPruebaODocumentos()
        {   
            var response = await _httpClient.GetAsync("OtrasPruebasYDocumentos");
            return response;
        }
        #endregion
    }
}
