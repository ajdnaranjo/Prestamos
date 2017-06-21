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
    
    public partial class Prestamo
    {
        public Prestamo()
        {
            this.PrestamoPago = new HashSet<PrestamoPago>();
        }
    
        public int NoPrestamo { get; set; }
        public int Documento { get; set; }
        public System.DateTime FechaPrestamo { get; set; }
        public decimal ValorPrestamo { get; set; }
        public int NoCuotas { get; set; }
        public int FormaPagoID { get; set; }
        public decimal Intereses { get; set; }
        public decimal ValorCuota { get; set; }
        public decimal Ganancias { get; set; }
        public decimal Saldo { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual FormasPago FormasPago { get; set; }
        public virtual ICollection<PrestamoPago> PrestamoPago { get; set; }
    }
}
