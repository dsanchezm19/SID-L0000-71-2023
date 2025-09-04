using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class PruebasSIDTests
    {
        private readonly F3_Pruebas _servicio;

        public PruebasSIDTests()
        {
            _servicio = new F3_Pruebas();
        }
        [Fact(DisplayName = "Consultar estado de pruebas por clave de expediente - Caso exitoso")]
        public async Task ConsultarEstadoExpedienteSID_Exitoso()
        {
            // Act
            var response = await _servicio.ObtenerExpedientePorClaveSID();

            // Assert
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Consultar expediente no encontrado - Retorna null")]
        public async Task ConsultarEstadoExpedienteSID_NoEncontrado()
        {
            // Act
            var response = await _servicio.ObtenerExpedientePorClaveSID();

            // Assert
            Assert.Null(response);
        }

        [Fact(DisplayName = "Consultar expediente pruebas no satisfactorias  por clave de expediente - Caso exitoso")]
        public async Task ConsultaExpedienteDePruebasNoSatisfactoriasPorClaveSID()
        {
            // Act
            var response = await _servicio.ObtenerExpedienteDePruebasNoSatisfactoriasPorClaveSID();

            // Assert
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Agregar resultado de prueba a una muestra - Caso exitoso")]
        public async Task AgregarResultadoPrueba_Exitoso()
        {   // Act
            var result = await _servicio.AgregarResultadoPruebaAsync();
            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Indicar que las pruebas de un expediente en el SID fueron satisfactorias - Caso exitoso")]
        public async Task IndicarConclusionDePruebasSID_Exitoso()
        {   // Act
            var result = await _servicio.IndicarResultadoSatisfactorioPruebasSIDAsync();
            // Assert
            Assert.NotNull(result);
        }

    }
}
