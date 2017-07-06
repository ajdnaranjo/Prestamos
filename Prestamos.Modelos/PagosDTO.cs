using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Modelos
{
    [Serializable]
    public class PagosDTO
    {
        public int tIDPago { get; set; }
        public int PrestamoPagoID { get; set; }
        public int Cuota { get; set; }
        public decimal ValorPago { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaPago { get; set; }
        public bool Pagado { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaPagoReal { get; set; }



    }
}
