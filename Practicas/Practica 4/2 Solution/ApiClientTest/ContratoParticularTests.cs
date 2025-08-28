using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class ContratoParticularTests
    {
        private readonly F2_PreparacionFabricacion _servicio;
        public ContratoParticularTests()
        {
            _servicio = new F2_PreparacionFabricacion();
        }

        [Fact(DisplayName = "Registrar contrato Particular - Caso exitoso")]
        public async Task RegistrarContratoParticular_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarContratoParticular();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.False(string.IsNullOrWhiteSpace(responseBody));
        }
        
        [Fact(DisplayName = "Registrar contrato Particular - Datos inválidos")]
        public async Task RegistrarContratoParticular_DatosInvalidos()
        {
            // Act
            var response = await _servicio.RegistrarContratoParticular_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar contrato Particular - UrlArchivo incorrecta ")]
        public async Task RegistrarContratoParticular_UrlArchivo_incorrecta()
        {
            // Act
            var response = await _servicio.RegistrarContratoParticular_UrlArchivo_Invalida();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Fact(DisplayName = "Actualizar contrato Particular - Caso exitoso")]
        public async Task ActualizarContratoParticular()
        {
            // Act
            var response = await _servicio.ActualizarContratoParticular();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("actualizado correctamente", responseBody);
        }

        [Fact(DisplayName = "Actualizar contrato Particular - Datos inválidos")]
        public async Task ActualizarContratoParticular_DatosInvalidos()
        {
            // Act
            var response = await _servicio.ActualizarContratoParticular_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
