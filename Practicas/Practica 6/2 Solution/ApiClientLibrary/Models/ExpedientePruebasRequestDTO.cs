using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ExpedientePruebasRequestDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("claveExpediente")]
        public string ClaveExpediente { get; set; }

        [JsonPropertyName("ordenFabricacion")]
        public string OrdenFabricacion { get; set; }

        [JsonPropertyName("cantidadMuestras")]
        public int CantidadMuestras { get; set; }

        [JsonPropertyName("muestras")]
        public List<string> Muestras { get; set; }
    }
}
