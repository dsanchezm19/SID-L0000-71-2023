using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class InstrumentoDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime FechaCalibracion { get; set; }
        public DateTime FechaVencimientoCalibracion { get; set; }
        public string UrlArchivo { get; set; }
        public string MD5 { get; set; }
        public string Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
