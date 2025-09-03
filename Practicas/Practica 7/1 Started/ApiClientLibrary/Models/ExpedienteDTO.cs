using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ExpedienteDTO
    {
        public string Id { get; set; }
        public string ClaveExpediente { get; set; }
        public IList<MuestraDTO> MuestrasExpediente { get; set; }
        public int TamanioMuestra { get; set; }
        //public IList<ResultadoPruebaDTO> ResultadosPruebas { get; set; }
        //public OrdenFabricacionDTO OrdenFabricacion { get; set; }
        public IList<string> AvisosPrueba { get; set; }
        public string EstatusPruebas { get; set; }
        public string ResultadoExpediente { get; set; }
        public DateTime InicioPruebas { get; set; }
        public DateTime FinPruebas { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
