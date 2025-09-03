using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ExpedientePruebasSIDDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("claveExpediente")]
        public string ClaveExpediente { get; set; }

        [JsonPropertyName("muestrasExpediente")]
        public List<MuestraExpedienteSIDDTO> MuestrasExpediente { get; set; }

        [JsonPropertyName("tamanioMuestra")]
        public int TamanioMuestra { get; set; }

        [JsonPropertyName("resultadosPruebas")]
        public object ResultadosPruebas { get; set; }

        [JsonPropertyName("ordenFabricacion")]
        public OrdenFabricacionExpedienteDTO OrdenFabricacion { get; set; }

        [JsonPropertyName("avisosPrueba")]
        public List<object> AvisosPrueba { get; set; }

        [JsonPropertyName("estatusPruebas")]
        public string EstatusPruebas { get; set; }

        [JsonPropertyName("resultadoExpediente")]
        public object ResultadoExpediente { get; set; }

        [JsonPropertyName("inicioPruebas")]
        public DateTime InicioPruebas { get; set; }

        [JsonPropertyName("finPruebas")]
        public DateTime FinPruebas { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }
    }

    public class MuestraExpedienteSIDDTO
    {
        [JsonPropertyName("identificador")]
        public string Identificador { get; set; }

        [JsonPropertyName("estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("resultadosPruebas")]
        public List<object> ResultadosPruebas { get; set; }
    }

    public class OrdenFabricacionExpedienteDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("claveOrdenFabricacion")]
        public string ClaveOrdenFabricacion { get; set; }

        [JsonPropertyName("loteFabricacion")]
        public string LoteFabricacion { get; set; }

        [JsonPropertyName("idProducto")]
        public string IdProducto { get; set; }

        [JsonPropertyName("detalleFabricacion")]
        public List<DetalleFabricacionExpedienteDTO> DetalleFabricacion { get; set; }
    }

    public class DetalleFabricacionExpedienteDTO
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
