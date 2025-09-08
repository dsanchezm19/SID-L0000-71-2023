using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class AplicacionDTO
    {
        public string Id { get; set; }
        public string NombreAplicacion { get; set; } // Nombre del software, formato, página
        public string Modulo { get; set; }
        public string Version { get; set; }  //Versión aprobada en producción
        public string? Comentarios { get; set; }
        public IList<DocumentoAplicacionDTO> Documentos { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaEnProduccion { get; set; }
    }

    public class DocumentoAplicacionDTO()
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlArchivo { get; set; } // URL o Path al archivo
    }
}
