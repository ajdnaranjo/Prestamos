//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prestamos.Repositorios
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pago
    {
        public Pago()
        {
            this.PagoCuota = new HashSet<PagoCuota>();
        }
    
        public int IDPago { get; set; }
        public int PrestamoPagoID { get; set; }
        public Nullable<int> Cuota { get; set; }
        public decimal ValorPago { get; set; }
        public decimal Saldo { get; set; }
        public System.DateTime FechaPago { get; set; }
        public Nullable<bool> Pagado { get; set; }
    
        public virtual PrestamoPago PrestamoPago { get; set; }
        public virtual ICollection<PagoCuota> PagoCuota { get; set; }
    }
}
