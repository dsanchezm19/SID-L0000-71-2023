using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class AgregaMuestraTests
    {
        private readonly F2_PreparacionFabricacion _servicio;
        public AgregaMuestraTests()
        {
            _servicio = new F2_PreparacionFabricacion();
        }

        [Fact(DisplayName = "Agregar muestra al expediente - Caso exitoso")]
        public async Task AgregarMuestraExpediente_Exitoso()
        {
            // Act
            var response = await _servicio.AgregarMuestraExpediente_Exitoso();

            //// Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact(DisplayName = "Agregar muestra al expediente - Datos inválidos")]
        public async Task AgregarMuestraExpediente_DatosInvalidos()
        {
            // Act
            var response = await _servicio.AgregarMuestraExpediente_DatosInvalidos();

            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Quitar muestra del expediente - Caso exitoso")]
        public async Task QuitarMuestraExpediente_Exitoso()
        {
            // Act
            var response = await _servicio.QuitarMuestraExpediente_Exitoso();

            //// Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Quitar muestra del expediente - Error")]
        public async Task QuitarMuestraExpediente_Error()
        {
            // Act
            var response = await _servicio.QuitarMuestraExpediente_Error();

            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
