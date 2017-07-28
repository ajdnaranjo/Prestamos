using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Modelos
{
    [Serializable]
    public  class PrestamosDTO
    {
        public string Nombre { get; set; }
        public long Documento { get; set; }
        public int NoPrestamo { get; set; } 
        public DateTime FechaPrestamo { get; set; }
        public decimal Total { get; set; }
    }
}
