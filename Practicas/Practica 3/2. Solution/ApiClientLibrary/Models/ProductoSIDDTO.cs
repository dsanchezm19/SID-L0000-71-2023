using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ProductoSIDDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("codigoFabricante")]
        public string CodigoFabricante { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("descripcionCorta")]
        public string DescripcionCorta { get; set; }

        [JsonPropertyName("tipoFabricacion")]
        public string TipoFabricacion { get; set; }

        [JsonPropertyName("unidad")]
        public string? Unidad { get; set; }

        [JsonPropertyName("norma")]
        public NormaDto Norma { get; set; }

        [JsonPropertyName("prototipo")]
        public PrototipoDto Prototipo { get; set; }

        [JsonPropertyName("estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        [JsonPropertyName("pruebas")]
        public List<PruebaDto> Pruebas { get; set; }

        public class NormaDto
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("clave")]
            public string Clave { get; set; }

            [JsonPropertyName("nombre")]
            public string Nombre { get; set; }

            [JsonPropertyName("edicion")]
            public string Edicion { get; set; }

            [JsonPropertyName("estatus")]
            public string Estatus { get; set; }

            [JsonPropertyName("esCFE")]
            public bool EsCFE { get; set; }

            [JsonPropertyName("fechaRegistro")]
            public DateTime FechaRegistro { get; set; }
        }

        public class PrototipoDto
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("numero")]
            public string Numero { get; set; }

            [JsonPropertyName("fechaEmision")]
            public DateTime FechaEmision { get; set; }

            [JsonPropertyName("fechaVencimiento")]
            public DateTime FechaVencimiento { get; set; }

            [JsonPropertyName("urlArchivo")]
            public string UrlArchivo { get; set; }

            [JsonPropertyName("mD5")]
            public string MD5 { get; set; }

            [JsonPropertyName("estatus")]
            public string Estatus { get; set; }

            [JsonPropertyName("fechaRegistro")]
            public DateTime FechaRegistro { get; set; }
        }

        public class PruebaDto
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


}



