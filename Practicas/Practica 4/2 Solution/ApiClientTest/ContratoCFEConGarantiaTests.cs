using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class ContratoCFEConGarantiaTests
    {
        private readonly F2_PreparacionFabricacion _servicio;
        public ContratoCFEConGarantiaTests()
        {
            _servicio = new F2_PreparacionFabricacion();
        }

        [Fact(DisplayName = "Registrar contrato CFE con garantia - Caso exitoso")]
        public async Task RegistrarContratoCFEConGarantia_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarContratoCFEConGarantia();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.False(string.IsNullOrWhiteSpace(responseBody));
        }

        [Fact(DisplayName = "Registrar contrato CFE con garantia - Datos inválidos")]
        public async Task RegistrarContratoCFEConGarantia_DatosInvalidos()
        {
            // Act
            var response = await _servicio.RegistrarContratoCFEConGarantia_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
