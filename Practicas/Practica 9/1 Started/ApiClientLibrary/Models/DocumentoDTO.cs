using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class DocumentoDTO
    {
        public string Id { get; set; }
        public string NombreDocumento { get; set; }
        public string TipoDocumento { get; set; } // Enum: Política, ManualUsuario, etc.
        public string UrlArchivo { get; set; } // URL o Path al archivo        
    }

}
