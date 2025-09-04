using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class PrototipoSIDTest
    {
        private readonly F1_ConfiguracionInicial _servicio;
        public PrototipoSIDTest()
        {
            _servicio = new F1_ConfiguracionInicial();
        }
        [Fact(DisplayName = "Registrar Prototipo SID - Caso exitoso")]
        public async Task RegistrarPrototipoSID_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarPrototipoSID();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact(DisplayName = "Actualizar Prototipo SID - Caso exitoso")]
        public async Task ActualizarPrototipoSID_Exitoso()
        {
            // Act
            var response = await _servicio.ActualizarPrototipoSID();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Debug en caso de falla
            Console.WriteLine($"StatusCode: {response.StatusCode}");
            Console.WriteLine($"ResponseBody: {responseBody}");

            // Assert principal
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
