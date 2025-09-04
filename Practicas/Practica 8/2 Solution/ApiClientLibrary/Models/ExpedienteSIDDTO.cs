using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ExpedienteSIDDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("claveExpediente")]
        public string ClaveExpediente { get; set; }

        [JsonPropertyName("muestrasExpediente")]
        public List<MuestraExpedienteDTO> MuestrasExpediente { get; set; }

        [JsonPropertyName("tamanioMuestra")]
        public int TamanioMuestra { get; set; }

        [JsonPropertyName("ordenFabricacion")]
        public OrdenFabricacionDTO OrdenFabricacion { get; set; }

        [JsonPropertyName("avisosPrueba")]
        public List<object> AvisosPrueba { get; set; }

        [JsonPropertyName("estatusPruebas")]
        public string EstatusPruebas { get; set; }

        [JsonPropertyName("resultadoExpediente")]
        public string ResultadoExpediente { get; set; }

        [JsonPropertyName("inicioPruebas")]
        public DateTime InicioPruebas { get; set; }

        [JsonPropertyName("finPruebas")]
        public DateTime FinPruebas { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }
    }

    public class MuestraExpedienteDTO
    {
        [JsonPropertyName("identificador")]
        public string Identificador { get; set; }

        [JsonPropertyName("estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("resultadosPruebas")]
        public List<ResultadoPruebaRequestDTO> ResultadosPruebas { get; set; }
    }

    public class ResultadoPruebaRequestDTO
    {
        [JsonPropertyName("prueba")]
        public PruebaDTO Prueba { get; set; }

        [JsonPropertyName("valorReferencia")]
        public ValorReferenciaDTO ValorReferencia { get; set; }

        [JsonPropertyName("fechaPrueba")]
        public DateTime FechaPrueba { get; set; }

        [JsonPropertyName("operadorPrueba")]
        public string OperadorPrueba { get; set; }

        [JsonPropertyName("instrumentoMedicion")]
        public InstrumentoMedicionDTO InstrumentoMedicion { get; set; }

        [JsonPropertyName("valorMedido")]
        public decimal ValorMedido { get; set; }

        [JsonPropertyName("resultado")]
        public string Resultado { get; set; }

        [JsonPropertyName("numeroIntento")]
        public int NumeroIntento { get; set; }
    }

    public class PruebaDTO
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

    public class InstrumentoMedicionDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("numeroSerie")]
        public string NumeroSerie { get; set; }

        [JsonPropertyName("fechaCalibracion")]
        public DateTime FechaCalibracion { get; set; }

        [JsonPropertyName("fechaVencimientoCalibracion")]
        public DateTime FechaVencimientoCalibracion { get; set; }

        [JsonPropertyName("urlArchivo")]
        public string UrlArchivo { get; set; }

        [JsonPropertyName("mD5")]
        public string Md5 { get; set; }

        [JsonPropertyName("estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }
    }

    public class OrdenFabricacionDTO
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
