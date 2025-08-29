using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class OtrasPruebasYDocumentosDTO
    {
        public string Id { get; set; }
        /// <summary>
        /// Tipos permitidos: CertificadoMaterial | Prueba Rutina | Otro
        /// </summary>
        public string TipoDocumento { get; set; }
        public string DescripcionDocumento { get; set; }
        public string UrlArchivo { get; set; }
        public string MD5 { get; set; }
        public string Estatus { get; set; }
        public DateTime Vigencia { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
