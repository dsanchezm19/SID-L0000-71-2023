using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ProductoCreateDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("codigoFabricante")]
        public string CodigoFabricante { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("descripcionCorta")]
        public string DescripcionCorta { get; set; }

        [JsonPropertyName("tipoFabricacion")]
        public string TipoFabricacion { get; set; }

        [JsonPropertyName("unidad")]
        public string Unidad { get; set; }

        [JsonPropertyName("norma")]
        public string Norma { get; set; }

        [JsonPropertyName("prototipo")]
        public string Prototipo { get; set; }

        [JsonPropertyName("estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        [JsonPropertyName("pruebas")]
        public List<string> Pruebas { get; set; } = new();
    }
}
