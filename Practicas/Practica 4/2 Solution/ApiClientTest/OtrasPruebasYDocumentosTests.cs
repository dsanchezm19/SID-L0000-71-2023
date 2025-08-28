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
        public async Task RegistrarOtrasPruebas_Exitoso()
        {
            // Act
            //var response = await _servicio.RegistrarOtrasPruebas();

            //// Assert
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
