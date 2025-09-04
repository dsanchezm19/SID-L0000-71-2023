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
        public int TamanioMuestra { get; set; }
        public string EstatusPruebas { get; set; }
        public List<MuestraDTO> MuestrasExpediente { get; set; }
    }
}
