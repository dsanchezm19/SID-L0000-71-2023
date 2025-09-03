using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class ExpedientePruebasSIDDTOTests
    {
        private readonly F2_PreparacionFabricacion _servicio;

        public ExpedientePruebasSIDDTOTests()
        {
            _servicio=new F2_PreparacionFabricacion();
        }
        [Fact(DisplayName = "Obtener el listado de expedientes de prueba en el SID - Caso exitoso")]
        public async Task ObtenerListadoExpedientesDePrueba_CasoExitoso()
        {
            // Act
            var result = await _servicio.ObtenerExpedientesPruebasAsync();
            // Assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Obtener expediente de prueba por ID en el SID - Caso exitoso")]
        public async Task ObtenerListadoExpedientesDePruebaPorId_CasoExitoso()
        {
            // Act
            var result = await _servicio.ExpedientePruebasPorIdAsync();
            // Assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Agregar expediente de prueba en el SID - Caso exitoso")]
        public async Task AgregarExpedienteDePrueba_CasoExitoso()
        {
            // Act
            var result = await _servicio.AgregarExpedienteAsync();
            // Assert
            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact(DisplayName = "Agregar expediente de prueba en el SID - Datos inválidos")]
        public async Task AgregarExpedienteDePrueba_DatosInvalidos() {
            // Act
            var result = await _servicio.AgregarExpedienteAsync();
            // Assert
            Assert.False(result.IsSuccessStatusCode); // Se espera que NO sea 200
            Assert.True(
                result.StatusCode == HttpStatusCode.BadRequest ||
                result.StatusCode == HttpStatusCode.InternalServerError
            );

        }
    }
}
