using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows.Markup;

namespace ApiClientLibrary.Services
{
    public class F3_Pruebas
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F3_Pruebas/";
        public F3_Pruebas()
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

        private async Task<HttpResponseMessage> PostAsync(EstadoSIDDTO estado)
        {
            var json = JsonSerializer.Serialize(estado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("EstadoSID", content);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarEstadoSID()
        {
            var estado = new EstadoSIDDTO { Estado = "EN_PRUEBAS" };
            HttpResponseMessage response = await PostAsync(estado);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarEstadoSID_DatosInvalidos()
        {
            var estado = new EstadoSIDDTO { Estado = "" };
            HttpResponseMessage response = await PostAsync(estado);
            return response;
        }

        // --------------------------------------------------------------------------
        // Métodos para pruebas del SID
        // --------------------------------------------------------------------------

        /// <summary>
        ///  Obtener el expediente por su clave en el SID.
        /// </summary>
        /// <returns></returns>
        public async Task<ExpedienteSIDDTO> ObtenerExpedientePorClaveSID()
        {
            var claveExpediente = "EXP-01";
            var response = await _httpClient.GetAsync($"ConsultaExpediente/{claveExpediente}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var expedientes = JsonSerializer.Deserialize<List<ExpedienteSIDDTO>>(jsonResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Como solo esperas uno, regresamos el primero
                return expedientes?.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Agregar un resultado de prueba a una muestra en el SID.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AgregarResultadoPruebaAsync() {
            var claveExpediente = "EXP-02";
            var idMuestra = "M01";

            // Creamos el body con ejemplo de datos
            var resultado = new ResultadoPruebaRequestSIDDTO
            {
                IdPrueba = "687a83d143657ba3e593df9f",
                IdValorReferencia = "687a8ed79a031ead55f89972",
                FechaPrueba = DateTime.Parse("2025-09-03T19:40:08.582Z"),
                OperadorPrueba = "Operador01",
                IdInstrumentoMedicion = "68a77eb9be14ddad3f158293",
                ValorMedido = 105,
                Resultado = "SATISFACTORIO",
                NumeroIntento = 1
            };

            var jsonContent = JsonContent.Create(resultado);

            var response = await _httpClient.PutAsync($"AgregaResultadoPrueba?expediente={claveExpediente}&muestra={idMuestra}",jsonContent);
            // Retornamos true si fue exitoso, false si no
            return response.IsSuccessStatusCode;

        }

        /// <summary>
        /// Indicar que las pruebas de un expediente en el SID fueron satisfactorias.
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> IndicarResultadoSatisfactorioPruebasSIDAsync() { 
            var claveExpediente = "EXP-02";

            var response = await _httpClient.PutAsync($"TerminarPruebasExpediente/{claveExpediente}");
            // Retornamos true si fue exitoso, false si no
            return response.IsSuccessStatusCode;
        }

    }
}
