using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class InstrumentoSIDTest
    {
        private readonly F1_ConfiguracionInicial _servicio;
        public InstrumentoSIDTest()
        {
            _servicio = new F1_ConfiguracionInicial();
        }
        [Fact(DisplayName = "Obtener el listado de Instrumentos para SID - Caso exitoso")]
        public async Task ObtenerInstrumentosPruebasAsync()
        {
            // Act
            var resultado = await _servicio.ObtenerInstrumentosPruebasAsync();
            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }
        [Fact(DisplayName = "Registrar Intrumento SID - Caso exitoso")]
        public async Task RegistrarInstrumentoSID_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarInstrumentoSID();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact(DisplayName = "Actualizar Intrumento SID - Caso exitoso")]
        public async Task ActualizarInstrumentoSID_Exitoso()
        {
            // Act
            var response = await _servicio.ActualizarInstrumentoSID();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
          

            //Buscar el instrumento especifico
            var responseIntrumentos = await _servicio.ObtenerInstrumentos();
            responseIntrumentos.EnsureSuccessStatusCode();

            var responseIntrumentosBody = await responseIntrumentos.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<List<InstrumentoDTO>>(responseIntrumentosBody, opciones);

            var instrumento = resultado.FirstOrDefault(i => i.Id == "68b73b8f31182e4d37ac4ebe");
            Assert.NotNull(instrumento);
            Assert.Equal("pie de rey", instrumento.Nombre);
        }
        [Fact(DisplayName = "Agregar productos SID - Caso conflicto")]
        public async Task AgregarInstrumentoInvalidSID_Exitoso()
        {
            // Act: llamamos al método para agregar el producto
            var response = await _servicio.AgregarInstrumentoAsync();

            // Assert: verificamos que el código de estado HTTP sea 400 BadRequest
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }


    }
}
