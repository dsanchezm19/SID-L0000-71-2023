using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public async Task<HttpResponseMessage> RegistrarEstadoSID(EstadoSIDDTO estado)
        {
            throw new NotImplementedException();
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
        // Registrar Instrumento -- caso exitoso 
        public async Task<HttpResponseMessage> RegistrarInstrumentoSID()
        {
            var instrumento = new InstrumentoDTO
            {
                Id = "025",
                Nombre = "Bernier",
                NumeroSerie="25452121",
                FechaCalibracion= new DateTime(2025, 8, 28),
                FechaVencimientoCalibracion= new DateTime(2027, 8, 28),
                UrlArchivo="https://www.cfe.mx",
                MD5="",
                Estatus="VIGENTE",
                FechaRegistro= new DateTime(2027, 9, 02)
            };
            HttpResponseMessage response = await PostAsync("Instrumento", instrumento);
            return response;
        }
        public async Task<HttpResponseMessage> RegistrarNormaSID()
        {
            var norma = new NormaDTO
            {
                Id="025",
                Clave="NMX-17025-IMNC",
                Nombre="Competencia de laboratorios de ensayo",
                Edicion="2025",
                Estatus="VIGENTE",
                EsCFE=true,
                FechaRegistro=new DateTime(2027, 9, 03)
            };
            HttpResponseMessage response = await PostAsync("Norma", norma);
            return response;
        }
        public async Task<HttpResponseMessage> RegistrarPrototipoSID()
        {
            var prototipo = new PrototipoDTO
            {
              Id="2100",
              Numero="541252",
              FechaEmision=new DateTime(2024 ,9, 25),
              FechaVencimiento=new DateTime(2027 ,9, 25),
              UrlArchivo= "https://www.cfe.mx",
              MD5=null,
              Estatus="VIGENTE",
              FechaRegistro=new DateTime(2025, 9, 3)
            };
            HttpResponseMessage response = await PostAsync("Prototipo", prototipo);
            return response;
        }
        //Actualizar Instrumento Caso exitoso
        public async Task<HttpResponseMessage> ActualizarInstrumentoSID()
        {
            var instrumento = new InstrumentoDTO
            {
                Id= "68b73b8f31182e4d37ac4ebe",
                Nombre = "pie de rey",
                NumeroSerie = "25452121",
                FechaCalibracion = new DateTime(2025, 8, 28),
                FechaVencimientoCalibracion = new DateTime(2027, 8, 28),
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                Estatus = "VIGENTE",
                FechaRegistro = new DateTime(2027, 9, 02)
            };
            HttpResponseMessage response = await PutAsJsonAsync("Instrumento", instrumento);
            return response;
        }
        public async Task<HttpResponseMessage> ObtenerInstrumentos()
        {
            var url = "Instrumento";
            var response = await _httpClient.GetAsync(url);
            return response;
        }

        public async Task<HttpResponseMessage> ActualizarPrototipoSID()
        {
            var prototipo = new PrototipoDTO
            {
                Id = "2100", // debe existir en la BD para actualizar
                Numero = "541252-ACT",
                FechaEmision = new DateTime(2024, 9, 25),
                FechaVencimiento = new DateTime(2028, 9, 25),
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "1234567890ABCDEF",
                Estatus = "RENOVADO",
                FechaRegistro = DateTime.Now

            };
            HttpResponseMessage response = await PutAsJsonAsync("Prototipo", prototipo);
            return response;
        }
    }
}
