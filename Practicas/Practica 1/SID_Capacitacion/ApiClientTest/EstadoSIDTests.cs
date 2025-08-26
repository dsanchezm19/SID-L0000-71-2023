using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System.Net;

namespace ApiClientTest
{
    public class EstadoSIDTests
    {
        private readonly  F1_ConfiguracionInicial _apiClient;
        public EstadoSIDTests()
        {
            _apiClient = new F1_ConfiguracionInicial();
        }

        [Fact(DisplayName = "Registrar Estado SID - Caso exitoso")]
        public async Task RegistrarEstadoSID_Exitoso()
        {
            var estado = new EstadoSIDDTO
            {
                Estado = "EN_PRUEBAS"
            };
            var response = await _apiClient.RegistrarEstadoSID(estado);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Estado SID - Token inválido")]
        public async Task RegistrarEstadoSID_TokenInvalido()
        {
            var estado = new EstadoSIDDTO
            {
                Estado = "EN_PRUEBAS"
            };
            // Forzamos un token inválido
            var apiClient = new F1_ConfiguracionInicial("TOKEN_INVALIDO_123");
            var response = await apiClient.RegistrarEstadoSID(estado);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Estado SID - Datos inválidos")]
        public async Task RegistrarEstadoSID_DatosInvalidos()
        {
            var estado = new EstadoSIDDTO
            {
                Estado = ""
            };
            var response = await _apiClient.RegistrarEstadoSID(estado);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
       
        [Fact(DisplayName = "Registrar Estado SID - Token expirado")]
        public async Task RegistrarEstadoSID_TokenExpirado()
        {
            var estado = new EstadoSIDDTO
            {
                Estado = "EN_PRUEBAS"
            };
            var response = await _apiClient.RegistrarEstadoSID(estado);
            var authHeader = response.Headers.WwwAuthenticate.FirstOrDefault();
            var parameter = authHeader?.Parameter ?? "";

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.True(parameter.Contains("The token expired"));
        }
    }
}
