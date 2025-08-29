using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ContratoParticularDTO
    {
        
        [JsonPropertyName("$Tipo")]
        public string Tipo { get; set; }
        public string Id { get; set; }
        public string TipoContrato { get; set; }
        public string NoContrato { get; set; }
        public string Estatus { get; set; }
        public IList<PartidaContratoParticularDTO> DetalleContrato { get; set; }
    }
  
    public class PartidaContratoParticularDTO
    {
        public string PartidaContrato { get; set; }
        public string DescripcionAviso { get; set; }
        public decimal Cantidad { get; set; }
        /// <summary>
        /// Pieza, Metro, Tramo, Kilo
        /// </summary>
        public string Unidad { get; set; }
        public decimal ImporteTotal { get; set; }
    }
}
