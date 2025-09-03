using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class OrdenFabricacionSIDDTO
    {
        [JsonPropertyName("claveOrdenFabricacion")]
        public string ClaveOrdenFabricacion { get; set; }

        [JsonPropertyName("loteFabricacion")]
        public string LoteFabricacion { get; set; }

        [JsonPropertyName("idProducto")]
        public string IdProducto { get; set; }

        [JsonPropertyName("detalleFabricacion")]
        public List<DetalleFabricacionDTO> DetalleFabricacion { get; set; }
    }
    public class DetalleFabricacionDTO
    {
        [JsonPropertyName("contratoId")]
        public string ContratoId { get; set; }

        [JsonPropertyName("tipoContrato")]
        public string TipoContrato { get; set; }

        [JsonPropertyName("partidaContratoId")]
        public string PartidaContratoId { get; set; }

        [JsonPropertyName("descripcionPartida")]
        public string DescripcionPartida { get; set; }

        [JsonPropertyName("unidad")]
        public string Unidad { get; set; }

        [JsonPropertyName("cantidadOriginalContrato")]
        public int CantidadOriginalContrato { get; set; }

        [JsonPropertyName("cantidadAFabricar")]
        public int CantidadAFabricar { get; set; }
    }
}
