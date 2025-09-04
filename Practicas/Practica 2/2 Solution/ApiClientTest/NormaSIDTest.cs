using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class NormaSIDTest
    {
        private readonly F1_ConfiguracionInicial _servicio;
        public NormaSIDTest()
        {
            _servicio = new F1_ConfiguracionInicial();
        }

        [Fact(DisplayName = "Obtener el listado de normas SID - Caso exitoso")]
        public async Task ObtenerListadoProductosSID_Exitoso()
        {
            // Act
            var resultado = await _servicio.ObtenerNormasAsync();

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }

        [Fact(DisplayName = "Registrar Norma SID - Caso exitoso")]
        public async Task RegistrarNormaSID_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarNormaSID();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
