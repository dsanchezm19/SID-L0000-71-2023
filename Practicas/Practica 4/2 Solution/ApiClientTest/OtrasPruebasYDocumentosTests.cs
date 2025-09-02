using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class OtrasPruebasYDocumentosTests
    {
        private readonly F1_ConfiguracionInicial _servicio;
        public OtrasPruebasYDocumentosTests()
        {
            _servicio = new F1_ConfiguracionInicial();
        }

        [Fact(DisplayName = "Registrar Otras pruebas - Caso exitoso")]
        public async Task RegistrarPruebaODocumento_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarPruebaODocumento();

            //// Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Otras pruebas - Tipo de documento inválido")]
        public async Task RegistrarContratoParticular_TipoDocumentoInvalido()
        {
            // Act
            var response = await _servicio.RegistrarPruebaODocumento_TipoDocumentoInvalido();
            // Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Otras pruebas - URLArchivo inválida")]
        public async Task RegistrarPruebaODocumento_URLArchivoInvalida()
        {
            // Act
            var response = await _servicio.RegistrarPruebaODocumento_URLArchivoInvalida();

            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
