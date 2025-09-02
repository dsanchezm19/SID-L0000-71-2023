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
    public class ContratoCFEConGarantiaTests
    {
        private readonly F2_PreparacionFabricacion _servicio;
        public ContratoCFEConGarantiaTests()
        {
            _servicio = new F2_PreparacionFabricacion();
        }

        [Fact(DisplayName = "Registrar contrato CFE con garantia - Caso exitoso")]
        public async Task RegistrarContratoCFEConGarantia_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarContratoCFEConGarantia();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.False(string.IsNullOrWhiteSpace(responseBody));
        }

        [Fact(DisplayName = "Registrar contrato CFE con garantia - Datos inválidos")]
        public async Task RegistrarContratoCFEConGarantia_DatosInvalidos()
        {
            // Act
            var response = await _servicio.RegistrarContratoCFEConGarantia_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Actualizar contrato CFE con garantia - Caso exitoso con minimo 2 partidas")]
        public async Task ActualizarContratoCFEConGarantia_Exitoso_DebeTenerMinimoDosPartidas() {
            //Arrange
            var idBuscado = "68b5fc963b7309591c0d829e";
            var noContrato = "9100025605";

            // Act
            var response = await _servicio.ActualizarContratoCFEConGarantia();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Buscar el contrato específico
            var responseContratos = await _servicio.ObtenerContratos(1, 50);
            responseContratos.EnsureSuccessStatusCode();
            var responseContratosBody = await responseContratos.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ListaContratosCFEConGarantiaDTO>(responseContratosBody, opciones);

            var contrato = resultado.Contratos.FirstOrDefault(c =>
                c.TipoContrato == "ContratoCFEConGarantia" &&
                c.NoContrato == noContrato && c.Id == idBuscado
            );

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("actualizado correctamente", responseBody);            
            Assert.NotNull(contrato);
            Assert.True(contrato.PerdidasGarantizadasVacio.Equals(42), $"Las pérdidas garantizadas en vacío no tiene el valor: 42. Tiene {contrato.PerdidasGarantizadasVacio}.");
            Assert.NotNull(contrato.DetalleContrato);
            Assert.True(contrato.DetalleContrato.Count >= 2, $"El contrato '9100025605' tiene menos de 2 partidas. Tiene {contrato.DetalleContrato.Count}.");
        }

        [Fact(DisplayName = "Actualizar contrato CFE con garantia - Datos inválidos")]
        public async Task ActualizarContratoCFEConGarantia_DatosInvalidos()
        {
            // Act
            var response = await _servicio.ActualizarContratoCFEConGarantia_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Obtener contrato de CFE con garantia - verifica que exista en la lista contrato: 9100025605")]
        public async Task ObtenerContratos_DebeExistirContratoCFEConGarantia()
        {
            // Act
            var response = await _servicio.ObtenerContratos(1, 50);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ListaContratosCFEConGarantiaDTO>(responseBody, opciones);

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado.Contratos);

            // Verificar que exista un contrato con noContrato = "9100026571"
            bool existeContratoCFE = resultado.Contratos.Any(c => c.TipoContrato == "ContratoCFEConGarantia" &&
            c.NoContrato == "9100025605");
            Assert.True(existeContratoCFE, "No se encontró ningún contrato CFE con garantía con número '9100025605'.");
        }

        [Fact(DisplayName = "Obtener contratos CFE con garantia")]
        public async Task ObtenerContratosCFEConGarantia()
        {
            // Act
            var response = await _servicio.ObtenerContratos(1, 150);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ListaContratosParticularDTO>(responseBody, opciones);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("contratos", responseBody);
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado.Contratos);

            // Verificar que exista un contrato particular
            bool existeContrato = resultado.Contratos.Any(c => c.TipoContrato == "ContratoCFEConGarantia");
            Assert.True(existeContrato, "No se encontró ningún contrato cfe con garantia");
        }

    }
}
