using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Modelos
{
    [Serializable]
    public class MorososDTO
    {
        public long Documento { get; set; }
        public string Nombre { get; set; }
        public int NoPrestamo { get; set; }
        public int? Cuota { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorCuota { get; set; }

    }
}
