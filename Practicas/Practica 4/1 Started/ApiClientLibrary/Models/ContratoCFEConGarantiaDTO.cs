using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ContratoCFEConGarantiaDTO
    {
        [JsonPropertyName("$Tipo")]
        public string Tipo { get; set; }
        public string Id { get; set; }
        public string TipoContrato { get; set; }
        public string NoContrato { get; set; }
        public string Estatus { get; set; }
        public List<DetalleContratoDTO> DetalleContrato { get; set; }
        public string UrlArchivo { get; set; }
        public string MD5 { get; set; }
        public DateTime FechaEntregaCFE { get; set; }
        public decimal PerdidasGarantizadasVacio { get; set; }
        public decimal PerdidasGarantizadasCarga { get; set; }
    }
}
