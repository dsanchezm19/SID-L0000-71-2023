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
        
        [Fact(DisplayName = "Actualizar contrato Particular - Caso exitoso con minimo 2 partidas")]
        public async Task ActualizarContratoParticula_Exitoso_DebeTenerMinimoDosPartidasr()
        {
            // Act
            var response = await _servicio.ActualizarContratoParticular();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("actualizado correctamente", responseBody);

            // Buscar el contrato específico
            var responseContratos = await _servicio.ObtenerContratos(1, 150);
            responseContratos.EnsureSuccessStatusCode();

            var responseContratosBody = await responseContratos.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<ListaContratosParticularDTO>(responseContratosBody, opciones);

            var contrato = resultado.Contratos.FirstOrDefault(c =>
                c.TipoContrato == "ContratoParticular" &&
                c.Id == "68b7366eb53b69f1a1caec2e"
            );

            Assert.NotNull(contrato);
            Assert.NotNull(contrato.DetalleContrato);
            Assert.True(contrato.DetalleContrato.Count >= 2, $"El contrato tiene menos de 2 partidas. Tiene {contrato.DetalleContrato.Count}.");
        }

        [Fact(DisplayName = "Actualizar contrato Particular - Datos inválidos")]
        public async Task ActualizarContratoParticular_DatosInvalidos()
        {
            // Act
            var response = await _servicio.ActualizarContratoParticular_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Obtener contratos Particulares")]
        public async Task ObtenerContratosParticulares()
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
            bool existeContrato = resultado.Contratos.Any(c => c.TipoContrato == "ContratoParticular");
            Assert.True(existeContrato, "No se encontró ningún contrato particular");
        }
    }
}
