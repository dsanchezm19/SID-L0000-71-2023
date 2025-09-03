using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Markup;

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
        // Métodos para Expedientes de Pruebas
        // --------------------------------------------------------------------------

        /// <summary>
        /// Obtiene el listado de expedientes de pruebas
        /// </summary>
        /// <returns></returns>
        public async Task<ExpedientePruebasSIDDTO?> ObtenerExpedientesPruebasAsync()
        {
            var response = await _httpClient.GetAsync("ExpedientePruebas");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var expediente = JsonSerializer.Deserialize<ExpedientePruebasSIDDTO>(jsonResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return expediente;
            }
            return null;
        }

        /// <summary>
        /// Obtener expediente de pruebas por ID
        /// </summary>
        /// <returns></returns>
        public async Task<ExpedientePruebasSIDDTO> ExpedientePruebasPorIdAsync()
        {
            var idExpediente = "68ae2f67753423c54bfd2fce";
            var response = await _httpClient.GetAsync($"ExpedientePruebas/{idExpediente}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var expediente = JsonSerializer.Deserialize<List<ExpedientePruebasSIDDTO>>(jsonResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Retornamos el primer expediente si existe
                return expediente?.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Agrega un nuevo expediente asociado a una orden de fabricación en el SID
        /// </summary>
        public async Task<HttpResponseMessage> AgregarExpedienteAsync()
        {
            // Definir el nuevo expediente
            var nuevoExpediente = new ExpedientePruebasRequestDTO
            {
                Id = "",
                ClaveExpediente = "EXP-12345",
                OrdenFabricacion = "68b76866291b75b009f5deb2", // id de la orden de fabricación existente
                CantidadMuestras = 5,
                Muestras = new List<string> { "M01", "M02", "M03", "M04", "M05" }
            };

            // Serializar a JSON
            var json = JsonSerializer.Serialize(nuevoExpediente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Llamada POST al endpoint
            var response = await _httpClient.PostAsync("ExpedientePruebas", content);
            return response;
        }

    }
}
