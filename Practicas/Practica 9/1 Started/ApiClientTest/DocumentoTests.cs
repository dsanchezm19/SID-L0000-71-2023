using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class DocumentoTests
    {
        private readonly Servicios_Soporte _servicio;
        public DocumentoTests()
        {
            _servicio = new Servicios_Soporte();
        }

        [Fact(DisplayName = "Registrar Documento - Caso exitoso")]
        public async Task AgregarDocumento_DeberiaRetornarOk()
        {   
            // Act
            var response = await _servicio.AgregarDocumento();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Obtener todos los documentos")]
        public async Task ObtieneDocumentos_DeberiaRetornarLista()
        { 
            // Act
            var response = await _servicio.ObtenerDocumentos();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact(DisplayName = "Actualizar documento - caso exitoso")]
        public async Task ActualizarDocumento_DeberiaRetornarDocumentoActualizado()
        {
            // Act
            var response = await  _servicio.ActualizarDocumento();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Eliminar documento - caso exitoso")]
        public async Task EliminarDocumento_DeberiaRetornarOk()
        {
            // Act
            var response = await _servicio.EliminarDocumento();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Agregar documento - Datos inválidos")]
        public async Task AgregarDocumento_DeberiaRetornarBadRequest_SiFalla()
        {
           // Act
            var response = await _servicio.AgregarDocumento_DatosInvalidos();
            var responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("no es válido", responseBody);
        }

        [Fact(DisplayName = "Actualizar documento - DatosInvalidos")]
        public async Task ActualizarDocumento_DeberiaRetornarBadRequest_SiFalla()
        {
            // Act
            var response = await _servicio.ActualizarDocumento_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
