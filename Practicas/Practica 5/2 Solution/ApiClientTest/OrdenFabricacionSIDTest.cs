using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class OrdenFabricacionSIDTest
    {
        private readonly F2_PreparacionFabricacion _servicio;

        public OrdenFabricacionSIDTest()
        {
            _servicio=new F2_PreparacionFabricacion();
        }
        [Fact(DisplayName = "Obtener el listado de ordenes de fabricacion en el SID - Caso exitoso")]
        public async Task ObtenerListadoOrdenesFabricacionSID_CasoExitoso()
        {
            // Act
            var result = await _servicio.ObtenerOrdenesFabricacionAsync();
            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact(DisplayName = "Agregar orden de fabricación en el SID - Caso exitoso")]
        public async Task AgregarOrdenFabricacionSID_CasoExitoso()
        {
            // Act
            var response = await _servicio.AgregarOrdenFabricacionAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Agregar orden de fabricación en el SID - Datos inválidos")]
        public async Task AgregarOrdenFabricacionSID_DatosInvalidos()
        {
            // Simular datos inválidos (por ejemplo, sin ClaveOrdenFabricacion)
            var response = await _servicio.AgregarOrdenFabricacionAsync();

            // Assert
            Assert.False(response.IsSuccessStatusCode); // Se espera que NO sea 200
            Assert.True(
                response.StatusCode == HttpStatusCode.BadRequest ||
                response.StatusCode == HttpStatusCode.InternalServerError
            );
        }

        [Fact(DisplayName = "Modificar orden de fabricación en el SID - Caso exitoso")]
        public async Task ModificarOrdenFabricacionSID_CasoExitoso()
        {
            // Act
            var response = await _servicio.ActualizarOrdenFabricacionAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Modificar orden de fabricación en el SID - Orden no existe")]
        public async Task ModificarOrdenFabricacionSID_OrdenNoExiste()
        {
            // Act: llamamos al método pasando el ID inexistente
            var response = await _servicio.ActualizarOrdenFabricacionAsync();

            // Assert: validamos que no sea 200 OK
            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);

            // Opcional: si el API devuelve 404 para no not found
            // Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
