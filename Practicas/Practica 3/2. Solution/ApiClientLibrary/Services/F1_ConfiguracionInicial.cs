using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static ApiClientLibrary.Models.ProductoSIDDTO;

namespace ApiClientLibrary.Services
{
    public class F1_ConfiguracionInicial
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F1_ConfiguracionInicial/";
        private readonly JsonSerializerOptions _jsonOptions;
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

        public async Task<HttpResponseMessage> RegistrarEstadoSID()
        {
            var estado = new EstadoSIDDTO { Estado = "EN_PRUEBAS" };
            var json = JsonSerializer.Serialize(estado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("EstadoSID", content);

            return response;
        }


        public async Task<HttpResponseMessage> RegistrarEstadoSID_invalido()
        {
            var estado = new EstadoSIDDTO { Estado = "" };
            var json = JsonSerializer.Serialize(estado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("EstadoSID", content);

            return response;
        }

        // --------------------------------------------------------------------------
        // Métodos para Prueba SID
        // --------------------------------------------------------------------------

        /// <summary>
        /// Obtener listado de pruebas del SID
        /// </summary>
        /// 
        public async Task<List<PruebaSIDDTO>?> ObtenerPruebasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Prueba");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var pruebas = JsonSerializer.Deserialize<List<PruebaSIDDTO>>(json);
                return pruebas;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la conexión: {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar la respuesta: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Insertar una nueva prueba en el SID
        /// </summary>
        /// 
        public async Task<HttpResponseMessage> AgregarPruebasAsync()
        {
            // Creamos la prueba
            var nuevaPrueba = new
            {
                id = Guid.NewGuid().ToString(),
                nombre = "CID",
                estatus = "ACTIVA",
                tipoPrueba = "ACEPTACION",
                tipoResultado = "VALOR_REFERENCIA",
                fechaRegistro = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(nuevaPrueba, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviamos POST
            var response = await _httpClient.PostAsync("Prueba", content);
            response.EnsureSuccessStatusCode();

            // No deserializamos, solo devolvemos la respuesta
            return response;
        }




        // --------------------------------------------------------------------------
        // Métodos para Producto SID
        // --------------------------------------------------------------------------

        /// <summary>
        /// Obtener listado de productos registrados SID
        /// </summary>
        /// 
        public async Task<List<ProductoSIDDTO>?> ObtenerProductosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Producto"); 
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var producto = JsonSerializer.Deserialize<List<ProductoSIDDTO>>(json, _jsonOptions);
                return producto;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la conexión: {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar la respuesta: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Registrar nuevo producto SID
        /// </summary>
        /// 
        public async Task<HttpResponseMessage> AgregarProductoAsync()
        {
            // Creamos un objeto con todos los campos requeridos
            var nuevoProducto = new
            {
                id = "",
                codigoFabricante = "TTP02",
                descripcion = "Nuevo Transformador - prueba",
                descripcionCorta = "DCC-PRUEBA-02",
                tipoFabricacion = "SERIE",
                unidad = "UND",
                norma = new
                {
                    id = "",
                    clave = "K0000-02",
                    nombre = "Transformadores de Distribución Tipo Poste",
                    edicion = "junio 2025",
                    estatus = "VIGENTE",
                    esCFE = true,
                    fechaRegistro = DateTime.UtcNow
                },
                prototipo = new
                {
                    id = "",
                    numero = "CEP0002-2025",
                    fechaEmision = DateTime.UtcNow,
                    fechaVencimiento = DateTime.UtcNow.AddYears(2),
                    urlArchivo = "https://www.cfe.mx",
                    mD5 = "dummyMD5value1234567890",
                    estatus = "VIGENTE",
                    fechaRegistro = DateTime.UtcNow
                },
                estatus = "ACTIVO",
                fechaRegistro = DateTime.UtcNow,
                pruebas = new List<string> { "687a83d143657ba3e593df9f" } // Ejemplo de ID de prueba existente
            };

            // Serializamos y enviamos POST al endpoint
            var json = JsonSerializer.Serialize(nuevoProducto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Producto", content);

            return response;
        }
        

        /// <summary>
        /// Actualizar un producto registrado SID
        /// </summary>
        /// 

        public async Task<HttpResponseMessage> ActualizarProductoAsync()
        {
            string idProducto = "68a66f9cdf56ae9af3e6db53";

            var productos = await ObtenerProductosAsync();

            if (productos == null || productos.Count == 0)
                throw new Exception("No hay productos disponibles para actualizar.");

            var producto = productos.FirstOrDefault(p => p.Id == idProducto);

            if (producto == null)
                throw new Exception($"No se encontró producto con Id {idProducto}");

            producto.Descripcion = "Transformador actualizado - prueba";
            producto.DescripcionCorta = "DCC-PRUEBA";

            var updateBody = new
            {
                id = producto.Id,
                codigoFabricante = producto.CodigoFabricante,
                descripcion = producto.Descripcion,
                descripcionCorta = producto.DescripcionCorta,
                tipoFabricacion = producto.TipoFabricacion,
                unidad = producto.Unidad,
                norma = producto.Norma,
                prototipo = producto.Prototipo,
                estatus = producto.Estatus,
                fechaRegistro = producto.FechaRegistro,
                pruebas = producto.Pruebas?.Select(p => p.Id).ToList() ?? new List<string>()
            };

            var json = JsonSerializer.Serialize(updateBody, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("Producto", content);

            return response;
        }

    }
}
