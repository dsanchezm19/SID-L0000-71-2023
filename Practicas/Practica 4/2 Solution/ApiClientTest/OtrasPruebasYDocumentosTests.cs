using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

        [Fact(DisplayName = "Registrar Otras pruebas o documento - Caso exitoso")]
        public async Task RegistrarPruebaODocumento_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarPruebaODocumento();

            //// Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Otras pruebas o documento - Tipo de documento inválido")]
        public async Task RegistrarPruebaODocumento_TipoDocumentoInvalido()
        {
            // Act
            var response = await _servicio.RegistrarPruebaODocumento_TipoDocumentoInvalido();
            // Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Otras pruebas o documento - URLArchivo inválida")]
        public async Task RegistrarPruebaODocumento_URLArchivoInvalida()
        {
            // Act
            var response = await _servicio.RegistrarPruebaODocumento_URLArchivoInvalida();

            //// Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Actualizar Otras pruebas o documento - cambiar URLArchivo - Caso exitoso ")]
        public async Task ActualizarPruebaODocumento_URLArchivo_Exitoso()
        {
            // Arrange            
            var idBuscado = "68b74b041508cbf69f2cd733";
            var urlEsperada = "https://www.cfe.gob.mx/transparencia_etica/Pages/default.aspx";

            // Act
            var response = await _servicio.ActualizarPruebaODocumento_URLArchivo_Exitoso();
            var responseBody = await response.Content.ReadAsStringAsync();

            // Buscar el documento 
            var responseDocumentos = await _servicio.ObtenerPruebaODocumentos();            
            responseDocumentos.EnsureSuccessStatusCode();
            var listadoDoctos = await responseDocumentos.Content.ReadFromJsonAsync<List<OtrasPruebasYDocumentosDTO>>();
            var documento = listadoDoctos.FirstOrDefault(x => x.Id == idBuscado);

            //// Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("actualizada correctamente", responseBody);
            Assert.NotNull(documento);
            Assert.Equal(urlEsperada, documento.UrlArchivo);

        }

        [Fact(DisplayName = "Actualizar Otras pruebas o documento - Datos inválidos")]
        public async Task ActualizarPruebaODocumento_DatosInválidos()
        {
            // Act
            var response = await _servicio.ActualizarPruebaODocumento_DatosInvalidos();

            //// Assert
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [Fact(DisplayName = "Obtener otras pruebas o documentos")]
        public async Task ObtenerPruebaODocumento()
        {
            // Act
            var response = await _servicio.ObtenerPruebaODocumentos();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
