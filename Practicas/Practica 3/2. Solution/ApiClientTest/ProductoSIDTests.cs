using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class ProductoSIDTests
    {
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly F1_ConfiguracionInicial _servicio;
        public ProductoSIDTests()
        {
            _servicio = new F1_ConfiguracionInicial();
        }

        [Fact(DisplayName = "Obtener el listado de productos SID - Caso exitoso")]
        public async Task ObtenerListadoProductosSID_Exitoso()
        {
            // Act
            var resultado = await _servicio.ObtenerProductosAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }

        [Fact(DisplayName = "Agregar productos SID - Caso exitoso")]
        public async Task AgregarProductosSID_Exitoso()
        {
            // Act: llamamos al método para agregar el producto
            var response = await _servicio.AgregarProductoAsync();

            // Assert: verificamos que el código de estado HTTP sea 200 OK
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Agregar productos SID - Caso conflicto")]
        public async Task AgregarProductosSinNormaOProductoSID_Exitoso()
        {
            // Act: llamamos al método para agregar el producto
            var response = await _servicio.AgregarProductoAsync();

            // Assert: verificamos que el código de estado HTTP sea 400 BadRequest
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Agregar productos SID - Caso conflicto (409)")]
        public async Task AgregarProductosSID_Conflicto()
        {
            // Act & Assert
            var ex = await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _servicio.AgregarProductoAsync(); // Intentamos agregar el mismo producto nuevamente
            });

            // Verificamos que el mensaje contenga el 409 Conflict
            Assert.Contains("409", ex.Message);
        }

        [Fact(DisplayName = "Actualizar producto SID - Caso exitoso")]
        public async Task ActualizarProductosSID_Exitoso()
        {
            // Act
            var response = await _servicio.ActualizarProductoAsync();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Actualizar producto SID - Error cuando alguna prueba no existe")]
        public async Task ActualizarProductosSID_ErrorPruebaNoExiste()
        {
            // Act
            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _servicio.ActualizarProductoAsync()
            );

            // Assert
            Assert.Contains("Prueba no encontrada", ex.Message);
        }
    }
}
