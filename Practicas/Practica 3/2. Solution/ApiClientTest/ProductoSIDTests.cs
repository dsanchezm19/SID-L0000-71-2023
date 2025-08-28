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
            // Act
            var response = await _servicio.AgregarProductoAsync();

            // Assert: verificamos que la respuesta sea exitosa
            Assert.True(response.IsSuccessStatusCode, $"La respuesta no fue exitosa: {response.StatusCode}");

            // Opcional: si el API devuelve el producto creado, podemos validar algunas propiedades
            var json = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrEmpty(json), "El cuerpo de la respuesta está vacío");

            // Si quieres deserializarlo para validar campos específicos:
            var productoCreado = JsonSerializer.Deserialize<ProductoSIDDTO>(json, _jsonOptions);
            Assert.NotNull(productoCreado);
            Assert.Equal("Nuevo Transformador - prueba", productoCreado.Descripcion);
            Assert.Equal("DCC-PRUEBA-02", productoCreado.DescripcionCorta);
        }

        [Fact(DisplayName = "Actualizar producto SID - Caso exitoso")]
        public async Task ActualizarProductosSID_Exitoso()
        {
            // Act
            var response = await _servicio.ActualizarProductoAsync();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
