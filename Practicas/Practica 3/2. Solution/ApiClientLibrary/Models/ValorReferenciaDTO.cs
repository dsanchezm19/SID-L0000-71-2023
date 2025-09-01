using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ValorReferenciaDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("idProducto")]
        public string IdProducto { get; set; }

        [JsonPropertyName("idPrueba")]
        public string IdPrueba { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }

        [JsonPropertyName("valor2")]
        public decimal Valor2 { get; set; }

        [JsonPropertyName("unidad")]
        public string Unidad { get; set; }

        [JsonPropertyName("comparacion")]
        public string Comparacion { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }
    }
}
