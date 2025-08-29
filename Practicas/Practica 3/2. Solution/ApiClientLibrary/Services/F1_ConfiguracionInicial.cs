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
                id = "",
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

        /// <summary>
        /// Actualizar una prueba registrado en el SID
        /// </summary>
        /// <returns>prueba</returns>
        public async Task<HttpResponseMessage> ActualizarPruebasAsync()
        { 
            string idPrueba = "68b09fac663d1c38a0647b28";
            var pruebas = await ObtenerPruebasAsync();

            if (pruebas == null || pruebas.Count == 0)
                throw new Exception("No hay pruebas disponibles para actualizar.");

            var prueba = pruebas.FirstOrDefault(p => p.Id == idPrueba);

            if (prueba == null)
                throw new Exception($"No se encontró producto con Id {idPrueba}");
            
            prueba.Nombre = "Resistencia Óhmica 2 - ACTUALIZADA";
            prueba.Estatus = "INACTIVA";

            var updateBody = new
            {
                id = prueba.Id,
                nombre = prueba.Nombre,
                estatus = prueba.Estatus,
                tipoPrueba = prueba.TipoPrueba,
                tipoResultado = prueba.TipoResultado,
                fechaRegistro = prueba.FechaRegistro
            };

            // Serializar la prueba
            var json = JsonSerializer.Serialize(prueba, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("Prueba", content);

            return response;
        }


        // --------------------------------------------------------------------------
        // Métodos para valores de referencia SID
        // --------------------------------------------------------------------------

        /// <summary>
        /// Obtener listado de valores de referencia de pruebas para SID
        /// </summary>
        /// <returns></returns>
        public async Task<List<ValorReferenciaDTO>?> ObtenerValoresReferenciaPruebasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("ValorReferencia");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var valores = JsonSerializer.Deserialize<List<ValorReferenciaDTO>>(json, _jsonOptions);
                return valores;
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
        /// Agregar un nuevo valor de referencia 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> AgregarValorReferenciaAsync()
        {
            string idProducto = "68a66f9cdf56ae9af3e6db53";
            string idPrueba = "68b09fac663d1c38a0647b28";

            var valoresExistentes = await ObtenerValoresReferenciaPruebasAsync();

            // Comprobamos si ya existe un valor para ese producto y prueba
            if (valoresExistentes != null && valoresExistentes.Any(v => v.IdProducto == idProducto && v.IdPrueba == idPrueba))
                throw new Exception($"Ya existe un valor de referencia para el producto {idProducto} y la prueba {idPrueba}");

            // Creamos el objeto que se enviará al endpoint
            var nuevoValor = new ValorReferenciaDTO
            {
                Id = "",
                IdProducto = idProducto,
                IdPrueba = idPrueba,
                Valor = 10,
                Valor2 = 20,
                Unidad = "Ohm",
                Comparacion = "Mayor",
                FechaRegistro = DateTime.Now
            };

            var json = JsonSerializer.Serialize(nuevoValor, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Llamada POST al endpoint
            var response = await _httpClient.PostAsync("ValorReferencia", content);

            return response;

        }

        /// <summary>
        /// Actualiza el valor de referencia de una prueba para un producto en el SID
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ActualizarValorReferenciaAsync()
        {
            string idValor = "68b0e3c0f14a6239975ad50d"; // ID del valor a actualizar

            var valores = await ObtenerValoresReferenciaPruebasAsync();

            if (valores == null || valores.Count == 0)
                throw new Exception("No hay valores de referencia disponibles para actualizar.");
            var valor = valores.FirstOrDefault(v => v.Id == idValor);
            
            if (valor == null)
                throw new Exception($"No se encontró valor de referencia con Id {idValor}");

            valor.Valor = 15; // Nuevo valor
            valor.Valor2 = 25; // Nuevo valor2

            var updateBody = new
            {
                id = valor.Id,
                idProducto = valor.IdProducto,
                idPrueba = valor.IdPrueba,
                valor = valor.Valor,
                valor2 = valor.Valor2,
                unidad = valor.Unidad,
                comparacion = valor.Comparacion,
                fechaRegistro = valor.FechaRegistro
            };
            var json = JsonSerializer.Serialize(updateBody, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("ValorReferencia", content);

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

            // 1️⃣ Crear el nuevo producto (puedes reemplazar con datos dinámicos)
            var nuevoProducto = new ProductoCreateDTO
            {
                Id = "",
                CodigoFabricante = "PT-005",
                Descripcion = "CUCHILLA - 02",
                DescripcionCorta = "PTR-PRUEBA - 02",
                TipoFabricacion = "Estándar",
                Unidad = "Unidad",
                Norma = "687a837243657ba3e593df9e",
                Prototipo = "687a89a7f955dd626c61f5cf",
                Estatus = "ACTIVO",
                FechaRegistro = DateTime.UtcNow,
                Pruebas = new List<string> { "68b0a01e663d1c38a0647b29" }
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
            string idProducto = "68b2021c8f6c1e31ccd35c73";

            // Obtenemos los productos existentes
            var productos = await ObtenerProductosAsync();

            if (productos == null || productos.Count == 0)
                throw new Exception("No hay productos disponibles para actualizar.");

            var producto = productos.FirstOrDefault(p => p.Id == idProducto);

            if (producto == null)
                throw new Exception($"No se encontró producto con Id {idProducto}");

            // Actualizamos los campos que queramos modificar
            producto.Descripcion = "POSTE actualizado - 0001";
            producto.DescripcionCorta = "DCC-PRUEBA-2";
            producto.Estatus = "INACTIVO";

            var updateBody = new
            {
                id = producto.Id,
                codigoFabricante = producto.CodigoFabricante,
                descripcion = producto.Descripcion,
                descripcionCorta = producto.DescripcionCorta,
                tipoFabricacion = producto.TipoFabricacion,
                unidad = producto.Unidad ?? "",
                norma = producto.Norma?.Id ?? "",
                prototipo = producto.Prototipo?.Id ?? "",
                estatus = producto.Estatus,
                fechaRegistro = producto.FechaRegistro,
                pruebas = new List<string> { "68b09fac663d1c38a0647b28", "687a83d143657ba3e593df9f" }
            };


            // Serializamos el body
            var json = JsonSerializer.Serialize(updateBody, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Llamamos al endpoint PUT
            var response = await _httpClient.PutAsync("Producto", content);

            return response;

        }

    }
}
