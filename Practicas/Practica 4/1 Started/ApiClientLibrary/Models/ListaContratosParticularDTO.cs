using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ListaContratosParticularDTO
    {
        public int Total { get; set; }
        public int PaginaActual { get; set; }
        public int TamañoPagina { get; set; }
        public List<ContratoParticularDTO> Contratos { get; set; }
    }
}
