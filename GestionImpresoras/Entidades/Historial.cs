using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionImpresoras.Entidades
{
    public class Consumible
    {
        public string MODELO { get; set; }
        public string NSERIE { get; set; }
        public string UBICACION { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA { get; set; }
    }
}
