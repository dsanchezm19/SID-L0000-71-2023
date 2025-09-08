using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class AplicacionTests
    {
        private readonly Servicios_Soporte _servicio;
        public AplicacionTests()
        {
            _servicio = new Servicios_Soporte();
        }

        [Fact(DisplayName = "POST - Debe agregar una aplicación correctamente")]
        public async Task Post_AgregarAplicacion_ReturnsOk()
        {
            // Act
            var response = await _servicio.AgregarAplicacion();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "PUT - Debe actualizar una aplicación correctamente")]
        public async Task Put_ActualizarAplicacion_ReturnsOk()
        {
            var response = await _servicio.ActualizarAplicacion();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "PUT - Actualizar una aplicación regresa BadRequest")]
        public async Task Put_ActualizarAplicacion_ReturnsBadRequest()
        {
            var response = await _servicio.ActualizarAplicacion_BadRequest();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "GET - Debe obtener todas las aplicaciones")]
        public async Task Get_ObtenerAplicaciones_ReturnsOk()
        {
            // Act
            var response = await _servicio.ObtenerAplicaciones();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "DELETE - Debe eliminar la aplicación")]
        public async Task Delete_Aplicacion_ReturnsOk()
        {
            // Act
            var response = await _servicio.EliminarAplicacion();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
