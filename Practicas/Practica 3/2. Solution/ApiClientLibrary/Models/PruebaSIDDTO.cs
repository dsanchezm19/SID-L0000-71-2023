using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class PruebaSIDDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("tipoPrueba")]
        public string TipoPrueba { get; set; } 

        [JsonPropertyName("tipoResultado")]
        public string TipoResultado { get; set; } 

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }
    }
}
