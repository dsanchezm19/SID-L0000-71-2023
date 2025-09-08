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

        #region Documentos
        public async Task<HttpResponseMessage> AgregarDocumento()
        {
            var documento = new DocumentoDTO
            {
                Id="",
                NombreDocumento = "Manual de Usuario",
                TipoDocumento = "ManualUsuario",
                UrlArchivo = "https://www.cfe.mx"
            };
            HttpResponseMessage response = await PostAsync("Documento", documento);
            return response;
        }

        public async Task<HttpResponseMessage> ObtenerDocumentos()
        {
            var response = await _httpClient.GetAsync("Documento");
            return response;
        }

        public async Task<HttpResponseMessage> ActualizarDocumento()
        {
            // Arrange
            var documento = new DocumentoDTO 
            { Id = "68add176f23bbc68da2cd371", NombreDocumento = "Nuevo manual de usuario", 
             TipoDocumento = "ManualUsuario", UrlArchivo = "https://www.cfe.mx"
            };

            HttpResponseMessage response = await PutAsJsonAsync("Documento", documento);
            return response;
        }

        public async Task<HttpResponseMessage> EliminarDocumento() {
            var id = "68add600f23bbc68da2cd372";
            HttpResponseMessage response = await _httpClient.DeleteAsync("Documento/" + id);
            return response;
        }

        public async Task<HttpResponseMessage> AgregarDocumento_DatosInvalidos()
        {
            var documento = new DocumentoDTO
            {
                Id = "",
                NombreDocumento = "Manual de Usuario",
                TipoDocumento = "Manual Usuario",
                UrlArchivo = "https://www.cfe.mx"
            };
            HttpResponseMessage response = await PostAsync("Documento", documento);
            return response;
        }

        public async Task<HttpResponseMessage> ActualizarDocumento_DatosInvalidos()
        {
            // Arrange
            var documento = new DocumentoDTO
            {
                Id = "",
                NombreDocumento = "Nuevo manual de usuario",
                TipoDocumento = "ManualUsuario",
                UrlArchivo = "https://www.cfe.mx"
            };

            HttpResponseMessage response = await PutAsJsonAsync("Documento", documento);
            return response;
        }
        #endregion

        #region Aplicacion
        public async Task<HttpResponseMessage> AgregarAplicacion()
        {
            var nuevaApp = new AplicacionDTO
            {
                Id="",
                NombreAplicacion = "Sistema Contable",
                Modulo = "Finanzas",
                Version = "1.0.0",
                Comentarios = "Primera versión liberada",
                Documentos = new List<DocumentoAplicacionDTO>
                {
                    new DocumentoAplicacionDTO
                    {
                        Nombre = "Manual de Usuario",
                        Descripcion = "Guía básica de uso",
                        UrlArchivo = "https://cfe.mx"
                    }
                },
                FechaAprobacion = new DateTime(2025,02,02),
                FechaEnProduccion = new DateTime(2025, 02, 04)
            };
            HttpResponseMessage response = await PostAsync("Aplicacion", nuevaApp);
            return response;
        }

        public async Task<HttpResponseMessage> ObtenerAplicaciones()
        {
            var response = await _httpClient.GetAsync("Aplicacion");
            return response;
        }

        public async Task<HttpResponseMessage> ActualizarAplicacion()
        {
            var appActualizada = new AplicacionDTO
            {
                Id = "68be6dea7650e130187eaa33",
                NombreAplicacion = "Sistema Contable",
                Modulo = "Finanzas",
                Version = "1.1.0",
                Comentarios = "Se corrigieron errores y se agregó nuevo reporte",
                Documentos = new List<DocumentoAplicacionDTO>
                {
                    new DocumentoAplicacionDTO
                    {
                        Nombre = "Manual Actualizado",
                        Descripcion = "Versión extendida con reportes",
                        UrlArchivo = "http://servidor/archivos/manual_v2.pdf"
                    }
                },
                FechaAprobacion = new DateTime(2025, 02, 05),
                FechaEnProduccion = new DateTime(2025, 02, 06)
            };
            HttpResponseMessage response = await PutAsJsonAsync("Aplicacion", appActualizada);
            return response;
        }

        public async Task<HttpResponseMessage> ActualizarAplicacion_BadRequest()
        {
            var appActualizada = new AplicacionDTO
            {
                Id = "",
                NombreAplicacion = "Sistema Contable",
                Modulo = "Finanzas",
                Version = "1.1.0",
                Comentarios = "Se corrigieron errores y se agregó nuevo reporte",
                Documentos = new List<DocumentoAplicacionDTO>
                {
                    new DocumentoAplicacionDTO
                    {
                        Nombre = "Manual Actualizado",
                        Descripcion = "Versión extendida con reportes",
                        UrlArchivo = "http://servidor/archivos/manual_v2.pdf"
                    }
                },
                FechaAprobacion = new DateTime(2025, 02, 05),
                FechaEnProduccion = new DateTime(2025, 02, 06)
            };
            HttpResponseMessage response = await PutAsJsonAsync("Aplicacion", appActualizada);
            return response;
        }

        public async Task<HttpResponseMessage> EliminarAplicacion()
        {
            var id = "68accc26fb4f79378d4de22f";
            HttpResponseMessage response = await _httpClient.DeleteAsync("Aplicacion/" + id);
            return response;
        }
        #endregion
    }
}
