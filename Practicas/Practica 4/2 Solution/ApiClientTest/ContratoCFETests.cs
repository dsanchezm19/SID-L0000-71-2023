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
    public class ContratoCFETests
    {
        private readonly F2_PreparacionFabricacion _servicio;
        public ContratoCFETests()
        {
            _servicio = new F2_PreparacionFabricacion();
        }

        [Fact(DisplayName = "Registrar contrato CFE - Caso exitoso")]
        public async Task RegistrarContratoCFE_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarContratoCFE();            
            string responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);            
            Assert.False(string.IsNullOrWhiteSpace(responseBody));
        }

        [Fact(DisplayName = "Registrar contrato CFE - Datos inválidos")]
        public async Task RegistrarContratoCFE_DatosInvalidos()
        {
            // Act
            var response = await _servicio.RegistrarContratoCFE_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar contrato CFE - UrlArchivo incorrecta ")]
        public async Task RegistrarContratoCFE_UrlArchivo_incorrecta()
        {
            // Act
            var response = await _servicio.RegistrarContratoCFE_UrlArchivo_Invalida();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
