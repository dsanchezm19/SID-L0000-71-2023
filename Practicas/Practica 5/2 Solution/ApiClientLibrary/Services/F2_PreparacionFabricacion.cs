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
        // Métodos para Orden de Fabricación SID
        // --------------------------------------------------------------------------

        /// <summary>
        /// Metodo para obtener el listado de ordenes de fabricacion desde el SID
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrdenFabricacionSIDDTO>?> ObtenerOrdenesFabricacionAsync()
        {
            var idOrden = "68a6639bcd4f08271c35a9ff";
            var response = await _httpClient.GetAsync($"OrdenFabricacion/{idOrden}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var ordenes = JsonSerializer.Deserialize<List<OrdenFabricacionSIDDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return ordenes;
        }

        /// <summary>
        /// Método para agregar una nueva orden de fabricación en el SID
        /// </summary>
        public async Task<HttpResponseMessage> AgregarOrdenFabricacionAsync()
        {
            var nuevaOrden = new OrdenFabricacionRequestDTO
            {
                Id ="",
                ClaveOrdenFabricacion = "OF-12345",
                LoteFabricacion = "Lote-001",
                IdProducto = "68a66f9cdf56ae9af3e6db53",
                DetalleFabricacion = new List<DetalleFabricacionRequestDTO>
                {
                    new DetalleFabricacionRequestDTO
                    {
                        ContratoId = "68afa72f9c0a3f982cfd92bb",
                        TipoContrato = "CFE",
                        PartidaContratoId = "1",
                        DescripcionPartida = "Aviso-001",
                        Unidad = "kg",
                        CantidadOriginalContrato = 100,
                        CantidadAFabricar = 50
                    }
                }
            };
            var json = JsonSerializer.Serialize(nuevaOrden);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("OrdenFabricacion", content);
            return response;
        }

        /// <summary>
        /// Método para actualizar una orden de fabricación en el SID
        /// </summary>
        public async Task<HttpResponseMessage> ActualizarOrdenFabricacionAsync()
        {
            var ordenActualizada = new OrdenFabricacionRequestDTO
            {
                Id = "", // 👈 ID de la orden a modificar
                ClaveOrdenFabricacion = "OF-12345-MOD",
                LoteFabricacion = "Lote-001-EDITADO",
                IdProducto = "68a66f9cdf56ae9af3e6db53",
                DetalleFabricacion = new List<DetalleFabricacionRequestDTO>
        {
            new DetalleFabricacionRequestDTO
            {
                ContratoId = "68afa72f9c0a3f982cfd92bb",
                TipoContrato = "CFE",
                PartidaContratoId = "1",
                DescripcionPartida = "Aviso-001-EDITADO",
                Unidad = "pz",
                CantidadOriginalContrato = 120,
                CantidadAFabricar = 60
            }
        }
            };

            var json = JsonSerializer.Serialize(ordenActualizada);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Usamos PUT en lugar de POST
            var response = await _httpClient.PutAsync("OrdenFabricacion", content);
            return response;
        }
    }
}
