using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class MuestraTests
    {
        private readonly F2_PreparacionFabricacion _servicio;
        public MuestraTests()
        {
            _servicio = new F2_PreparacionFabricacion();
        }

        [Fact(DisplayName = "Agregar muestra al expediente - Caso exitoso")]
        public async Task AgregarMuestraExpediente_Exitoso()
        {
            // Act
            var response = await _servicio.AgregarMuestraExpediente_Exitoso();
            // Assert 1: que haya sido exitoso
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Assert 2: que el body tenga el expediente esperado
            var expediente = await response.Content.ReadFromJsonAsync<ExpedienteDTO>();
            Assert.NotNull(expediente);
            Assert.Equal("EXP-12345", expediente.ClaveExpediente);

            // Assert 3: que la muestra exista en el expediente
            Assert.Contains(expediente.MuestrasExpediente,
                m => m.Identificador == "M06" && m.Estatus == "PENDIENTE_PRUEBAS");
        }

        [Fact(DisplayName = "Agregar muestra al expediente - Muestra duplicada")]
        public async Task AgregarMuestraExpediente_MuestraDuplicada_Error()
        {
            // Act
            var response = await _servicio.AgregarMuestraExpediente_MuestraDuplicada_Error();
            var responseBody = await response.Content.ReadAsStringAsync();

            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("ya existe en el expediente", responseBody);
        }

        [Fact(DisplayName = "Agregar muestra al expediente - No existe expediente")]
        public async Task AgregarMuestraExpediente_NoExisteExpediente()
        {
            // Act
            var response = await _servicio.AgregarMuestraExpediente_NoExisteExpediente();
            var responseBody = await response.Content.ReadAsStringAsync();

            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("No se encuentra el expediente", responseBody);
        }

        [Fact(DisplayName = "Agregar muestra al expediente - Datos inválidos")]
        public async Task AgregarMuestraExpediente_DatosInvalidos()
        {
            // Act
            var response = await _servicio.AgregarMuestraExpediente_DatosInvalidos();

            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Agregar muestra al expediente en pruebas o terminado - No agrega muestra")]
        public async Task AgregarMuestraExpediente_ExpedienteStatusInvalido_NoAgregaMuestra()
        {
            // Act
            var response = await _servicio.AgregarMuestraExpediente_ExpedienteStatusInvalido_NoAgregaMuestra();
            var responseBody = await response.Content.ReadAsStringAsync();
            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("No se pueden agregar muestras al expediente", responseBody);
        }

        [Fact(DisplayName = "Quitar muestra del expediente - Caso exitoso")]
        public async Task QuitarMuestraExpediente_Exitoso()
        {
            // Act
            var response = await _servicio.QuitarMuestraExpediente_Exitoso();

            // Assert 1: que la API responda OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Assert 2: leemos el expediente actualizado
            var expediente = await response.Content.ReadFromJsonAsync<ExpedienteDTO>();
            Assert.NotNull(expediente);

            // Assert 3: validamos que la muestra ya NO exista
            Assert.DoesNotContain(expediente.MuestrasExpediente,
                m => m.Identificador == "M06");
        }

        [Fact(DisplayName = "Quitar muestra del expediente - No existe expediente")]
        public async Task QuitarMuestraExpediente_NoExisteExpediente()
        {
            // Act
            var response = await _servicio.QuitarMuestraExpediente_NoExisteExpediente();
            var responseBody = await response.Content.ReadAsStringAsync();
            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("No se encuentra el expediente", responseBody);
        }

        [Fact(DisplayName = "Quitar muestra del expediente - No existe la muestra")]
        public async Task QuitarMuestraExpediente_NoExisteMuestra()
        {
            // Act
            var response = await _servicio.QuitarMuestraExpediente_NoExisteMuestra();
            var responseBody = await response.Content.ReadAsStringAsync();
            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("No se encuentra la muestra", responseBody);
        }

        [Fact(DisplayName = "Quitar muestra al expediente en pruebas o terminado - No quita muestra")]
        public async Task QuitarMuestraExpediente_ExpedienteStatusInvalido_NoQuitaMuestra()
        {
            // Act
            var response = await _servicio.QuitarMuestraExpediente_ExpedienteStatusInvalido_NoQuitaMuestra();
            var responseBody = await response.Content.ReadAsStringAsync();
            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("No se pueden quitar muestras al expediente", responseBody);
        }
    }
}
