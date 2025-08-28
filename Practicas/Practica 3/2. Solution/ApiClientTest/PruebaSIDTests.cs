using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class PruebaSIDTests
    {
        private readonly F1_ConfiguracionInicial _servicio;
        public PruebaSIDTests()
        {
            _servicio = new F1_ConfiguracionInicial();
        }

        [Fact(DisplayName = "Obtener el listado de pruebas SID - Caso exitoso")]
        public async Task ObtenerPruebasSID_Exito()
        {
            // Act
            var resultado = await _servicio.ObtenerPruebasAsync();
            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }


        [Fact(DisplayName = "Agregar prueba SID - Caso exitoso")]
        public async Task AltaPruebasSID_Exito()
        {
            // Act: llamamos al método para agregar la prueba
            var resultado = await _servicio.AgregarPruebasAsync();

            // Assert: verificamos que la lista no sea nula ni esté vacía
            Assert.Equal(System.Net.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact(DisplayName = "Agregar prueba SID - Caso conflicto (409)")]
        public async Task AltaPruebaSID_Conflicto()
        {
            // Act & Assert
            var ex = await Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _servicio.AgregarPruebasAsync();
            });

            // Verificamos que el mensaje contenga el 409 Conflict
            Assert.Contains("409", ex.Message);

        }

        public async Task ActualizarPruebasSID()
        { 
        }

        }
}
