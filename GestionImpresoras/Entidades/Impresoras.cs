using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionImpresoras.Entidades
{
    public class Impresoras
    {
        
        public string UBICACION { get; set; }
        public string MODELO { get; set; }
        public string NSERIE { get; set; } // Clave Primaria
        public string IP { get; set; }
        public string OBSERVACIONES { get; set; }
        public int? GRUPO { get; set; }
    }
}
