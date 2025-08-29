using ApiClientLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    public class ValoresReferenciaTests
    {
        private readonly F1_ConfiguracionInicial _servicio;

        public ValoresReferenciaTests()
        {
            _servicio = new F1_ConfiguracionInicial();
        }

        [Fact(DisplayName = "Obtener el listado de valores de referencia de pruebas para SID - Caso exitoso")]
        public async Task ObtenerValoresReferenciaPruebasSID_Exito()
        {
            // Act
            var resultado = await _servicio.ObtenerValoresReferenciaPruebasAsync();
            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }

        [Fact(DisplayName = "Agregar nuevo valor de referencia de pruebas para SID - Caso exitoso")]
        public async Task AgregarValoresReferenciaPruebasSID_Exito()
        {
            // Act: llamamos al método para agregar el valor de referencia
            var resultado = await _servicio.AgregarValorReferenciaAsync();
            // Assert: verificamos que la lista no sea nula ni esté vacía
            Assert.Equal(System.Net.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact(DisplayName = "Agregar nuevo valor de referencia de pruebas de un producto para SID - Caso exitoso")]
        public async Task ActualizarValoresReferenciaAsync() 
        {
            // Act
            var response = await _servicio.ActualizarValorReferenciaAsync();
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

}
}
