using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ListaContratosDTO
    {
        public int Total { get; set; }
        public int PaginaActual { get; set; }
        public int TamañoPagina { get; set; }
        public List<ContratoCFEDTO> Contratos { get; set; }
    }
}
