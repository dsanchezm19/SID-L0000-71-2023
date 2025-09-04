using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ResultadoPruebaRequestSIDDTO
    {
        [JsonPropertyName("idPrueba")]
        public string IdPrueba { get; set; }

        [JsonPropertyName("idValorReferencia")]
        public string IdValorReferencia { get; set; }

        [JsonPropertyName("fechaPrueba")]
        public DateTime FechaPrueba { get; set; }

        [JsonPropertyName("operadorPrueba")]
        public string OperadorPrueba { get; set; }

        [JsonPropertyName("idInstrumentoMedicion")]
        public string IdInstrumentoMedicion { get; set; }

        [JsonPropertyName("valorMedido")]
        public decimal ValorMedido { get; set; }

        [JsonPropertyName("resultado")]
        public string Resultado { get; set; }

        [JsonPropertyName("numeroIntento")]
        public int NumeroIntento { get; set; }
    }
}
