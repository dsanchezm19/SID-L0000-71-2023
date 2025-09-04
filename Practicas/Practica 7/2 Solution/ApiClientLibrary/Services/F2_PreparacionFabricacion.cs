using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
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
  
        private async Task<HttpResponseMessage> PutAsJsonAsync<T>(string url, T dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsJsonAsync(url, dto);
            return response;
        }

        public async Task<HttpResponseMessage> ConsultarTodosLosExpedientes(int pageNumber, int pageSize)
        {
            var url = $"ExpedientePruebas?pageNumber={pageNumber}&pageSize={pageSize}";
            var response = await _httpClient.GetAsync(url);
            return response;
        }

        public async Task<HttpResponseMessage> AgregarMuestraExpediente_Exitoso()
        {
            var Expediente = "EXP-12345";
            var muestra = new 
            {
                Identificador = "M06",
                Estatus = ""
            };
            HttpResponseMessage response = await PutAsJsonAsync($"AgregaMuestraExpediente/{Expediente}", muestra);
            return response;
        }

        public async Task<HttpResponseMessage> ConsultarMuestraExpediente()
        {
            
            var Expediente = "EXP-12345";
            var response = await _httpClient.GetAsync($"ConsultaExpediente/{Expediente}");            
            return response;
        }

        public async Task<HttpResponseMessage> AgregarMuestraExpediente_MuestraDuplicada_Error() {
            var Expediente = "EXP-12345";
            var muestra = new
            {
                Identificador = "M06",
                Estatus = "PENDIENTE_PRUEBAS"
            };
            HttpResponseMessage response = await PutAsJsonAsync($"AgregaMuestraExpediente/{Expediente}", muestra);
            return response;
        }
        public async Task<HttpResponseMessage> AgregarMuestraExpediente_NoExisteExpediente()
        {
            var Expediente = "EXP-";
            var muestra = new
            {
                Identificador = "M1",
                Estatus = ""
            };
            HttpResponseMessage response = await PutAsJsonAsync($"AgregaMuestraExpediente/{Expediente}", muestra);            
            return response;
        }

        public async Task<HttpResponseMessage> AgregarMuestraExpediente_DatosInvalidos()
        {
            var Expediente = "EXP-12345";
            var muestra = new
            {
                Identificador = "Mx",
                Estatus = "CANCELADO"
            };
            HttpResponseMessage response = await PutAsJsonAsync($"AgregaMuestraExpediente/{Expediente}", muestra);
            return response;
        }

        public async Task<HttpResponseMessage> AgregarMuestraExpediente_ExpedienteStatusInvalido_NoAgregaMuestra()
        {
            var Expediente = "EXP-02";
            var muestra = new
            {
                Identificador = "M8",
                Estatus = "PENDIENTE_PRUEBAS"
            };
            HttpResponseMessage response = await PutAsJsonAsync($"AgregaMuestraExpediente/{Expediente}", muestra);
            return response;
        }

        public async Task<HttpResponseMessage> QuitarMuestraExpediente_Exitoso()
        {
            var expediente = "EXP-12345";
            var muestra = "M06";          
            var content = new StringContent(string.Empty);
            HttpResponseMessage response = await PutAsJsonAsync($"QuitarMuestraExpediente/{expediente}/{muestra}",content);            
            return response;
        }

        public async Task<HttpResponseMessage> QuitarMuestraExpediente_NoExisteExpediente()
        {
            var expediente = "E";
            var muestra = "M06";
            var content = new StringContent(string.Empty);
            HttpResponseMessage response = await PutAsJsonAsync($"QuitarMuestraExpediente/{expediente}/{muestra}", content);
            return response;
        }

        public async Task<HttpResponseMessage> QuitarMuestraExpediente_NoExisteMuestra()
        {
            var expediente = "EXP-12345";
            var muestra = "MX";
            var content = new StringContent(string.Empty);
            HttpResponseMessage response = await PutAsJsonAsync($"QuitarMuestraExpediente/{expediente}/{muestra}", content);
            return response;
        }

        public async Task<HttpResponseMessage> QuitarMuestraExpediente_ExpedienteStatusInvalido_NoQuitaMuestra()
        {
            var expediente = "EXP-02";
            var muestra = "M01";
            var content = new StringContent(string.Empty);
            HttpResponseMessage response = await PutAsJsonAsync($"QuitarMuestraExpediente/{expediente}/{muestra}", content);
            return response;
        }
    }
}
