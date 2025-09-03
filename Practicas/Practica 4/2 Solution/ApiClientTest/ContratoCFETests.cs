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

        [Fact(DisplayName = "Obtener contratos CFE")]
        public async Task ObtenerContratosCFE()
        {
            // Act
            var response = await _servicio.ObtenerContratos(1, 50);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ListaContratosDTO>(responseBody, opciones);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("contratos", responseBody);
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado.Contratos);

            // Verificar que exista un contrato de CFE
            bool existeContratoCFE = resultado.Contratos.Any(c => c.TipoContrato == "ContratoCFE");
            Assert.True(existeContratoCFE, "No se encontró ningún contrato de CFE");
        }

        [Fact(DisplayName = "Obtener contrato de CFE - verifica que exista en la lista contrato: 9100026571")]
        public async Task ObtenerContratos_DebeExistirContratoCFE()
        {
           // Act
            var response = await _servicio.ObtenerContratos(1, 50);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ListaContratosDTO>(responseBody, opciones);

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado.Contratos);

            // Verificar que exista un contrato con noContrato = "9100026571"
            bool existeContratoCFE = resultado.Contratos.Any(c => c.TipoContrato == "ContratoCFE" && 
            c.NoContrato == "9100026571");
            Assert.True(existeContratoCFE, "No se encontró ningún contrato con número '9100026571'.");
        }

        [Fact(DisplayName = "Actualizar contrato CFE - Caso exitoso con minimo 3 partidas")]
        public async Task ActualizarContratoCFE_DebeTenerMinimoTresPartidas()
        {
            //Arrange
            var idBuscado = "68b5b4973b7309591c0d829d";
            var noContrato = "9100026571";
            // Act
            var response = await _servicio.ActualizarContratoCFE();
            var responseBody = await response.Content.ReadAsStringAsync();

            // Buscar el contrato específico
            var responseContratos = await _servicio.ObtenerContratos(1, 50);
            responseContratos.EnsureSuccessStatusCode();
            var responseContratosBody = await responseContratos.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ListaContratosDTO>(responseContratosBody, opciones);
            var contrato = resultado.Contratos.FirstOrDefault(c =>
                c.TipoContrato == "ContratoCFE" &&
                c.NoContrato == noContrato && c.Id == idBuscado
            );

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("actualizado correctamente", responseBody);
            Assert.NotNull(contrato);
            Assert.NotNull(contrato.DetalleContrato);
            Assert.True(contrato.DetalleContrato.Count >= 3, $"El contrato '9100026571' tiene menos de 3 partidas. Tiene {contrato.DetalleContrato.Count}.");

        }

        [Fact(DisplayName = "Actualizar contrato CFE - Datos inválidos")]
        public async Task ActualizarContratoCFE_DatosInvalidos()
        {
            // Act
            var response = await _servicio.ActualizarContratoCFE_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
