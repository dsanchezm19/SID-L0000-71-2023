using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System.Net;

namespace ApiClientTest
{
    public class EstadoSIDTests
    {
        private readonly F3_Pruebas _servicio;
        public EstadoSIDTests()
        {
            _servicio = new F3_Pruebas();
        }

        [Fact(DisplayName = "Registrar Estado SID - Caso exitoso")]
        public async Task RegistrarEstadoSID_Exitoso()
        {
            // Act
            var response = await _servicio.RegistrarEstadoSID();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Estado SID - Token inválido")]
        public async Task RegistrarEstadoSID_TokenInvalido()
        {          
            // Act
            // Forzamos un token inválido
            var apiClient = new F3_Pruebas();
            apiClient.SetToken("token_invalido");
            var response = await apiClient.RegistrarEstadoSID();
            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Estado SID - Datos inválidos")]
        public async Task RegistrarEstadoSID_DatosInvalidos()
        {
            // Arrange
            var estado = new EstadoSIDDTO {Estado = ""};
            // Act
            var response = await _servicio.RegistrarEstadoSID_DatosInvalidos();
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Registrar Estado SID - Token expirado")]
        public async Task RegistrarEstadoSID_TokenExpirado()
        {
            // Creamos un token expirado
            var expiredToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJDQVJMT1MgQUxCRVJUTyBTT0xJUyBNQURSSUdBTCIsImZ1bGxOYW1lIjoiQ0FSTE9TIEFMQkVSVE8gU09MSVMgTUFEUklHQUwiLCJ1c2VybmFtZSI6IjlBSkFYIiwicmZjIjoiQ0ZFMzcwODE0UUkwIiwiZW1wcmVzYSI6IkNPTUlTSU9OIEZFREVSQUwgREUgRUxFQ1RSSUNJREFEIiwiSWRFbXByZXNhIjoiMSIsInJvbGUiOiJVc2VyX1NJRCIsImp0aSI6IjkzMjE5YWNkLWY3NDEtNDdkMS04ODJiLTc1M2MyNzQ1NzQ2OSIsIm5iZiI6MTc1NTgxOTA1MCwiZXhwIjoxNzU1OTA1NDUwLCJpYXQiOjE3NTU4MTkwNTAsImlzcyI6Imh0dHBzOi8vbGFwZW0uY2ZlLmdvYi5teC9zaWQvIiwiYXVkIjoiaHR0cHM6Ly9sYXBlbS5jZmUuZ29iLm14L3NpZC8ifQ.AQUhP4CP-UcxoBk1VK6J6-fuChcWbEqX7fkRZ3l-bII";
            _servicio.SetToken(expiredToken);

            // Act
            var response = await _servicio.RegistrarEstadoSID();

            // Obtenemos el encabezado
            var authHeader = response.Headers.WwwAuthenticate.FirstOrDefault();
            var parameter = authHeader?.Parameter ?? "";

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Contains("The token expired", parameter, StringComparison.OrdinalIgnoreCase);
        }
    }
}
