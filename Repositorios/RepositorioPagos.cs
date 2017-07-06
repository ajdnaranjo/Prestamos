using System;
using System.Collections.Generic;
using System.Linq;
using Prestamos.Repositorios;
namespace Prestamos.Repositorios
{
    [Serializable]
    public class RepositorioPagos
    {

        public void GuardarPago(Pago pago, Prestamo prestamo)
        {
           using (var context = new PrestamosEntities())
            {

                var pres = context.Prestamo.FirstOrDefault(cl => cl.NoPrestamo == prestamo.NoPrestamo);

                if (pres.ValorCuota == pago.ValorPago)
                {
                    Pago p = context.Pago.FirstOrDefault(x => x.IDPago == pago.IDPago);
                    p.Pagado = true;
                    p.FechaPagoReal = DateTime.Now;

                    Prestamo pp = context.Prestamo.FirstOrDefault(c => c.NoPrestamo == prestamo.NoPrestamo);

                    pp.Saldo = pago.Saldo;

                    context.SaveChanges();

                    //var repo = new RepositorioCrearPrestamo();
                    //repo.RecalcularSaldo(prestamo.NoPrestamo);
                }
                else
                {
                    if (pago.ValorPago < pres.ValorCuota)
                    {
                        Pago p = context.Pago.FirstOrDefault(x => x.IDPago == pago.IDPago);
                        p.ValorPago = p.ValorPago - pago.ValorPago;
                        p.FechaPagoReal = DateTime.Now;

                        Prestamo pp = context.Prestamo.FirstOrDefault(c => c.NoPrestamo == prestamo.NoPrestamo);

                        pp.Saldo = pago.Saldo;

                        context.SaveChanges();
                    }
                    else { 

                        
                    }

                }
            }
            
        }

        private int NumeroCuotaXNoPrestamo(int NoPrestamo)
        {
            int? query ;
            int id = 0;
            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago
                         join pp in context.PrestamoPago on p.PrestamoPagoID equals pp.PrestamoPagoID
                         where pp.NoPrestamo == NoPrestamo                         
                         orderby p.Cuota descending
                         select p.Cuota).FirstOrDefault();
            }

            if (query == null) id = 1;
            else  id = int.Parse(query.ToString()) + 1;

            return id;
        }

        public List<Pago> GetPagosXPrestamoID(int prestamoID)
        {

            var query = new List<Pago>();

            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago
                         join pp in context.PrestamoPago on p.PrestamoPagoID equals pp.PrestamoPagoID
                         where pp.NoPrestamo == prestamoID 
                         orderby p.IDPago ascending
                         select p).ToList();
            }

            return query;
        }


        public decimal TotalPagosxDia(DateTime fechaInicial, DateTime fechaFinal)
        {
            var query = new List<Pago>();
            decimal pagos;

            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago                         
                         where p.FechaPago >= fechaInicial && p.FechaPago <= fechaFinal
                         select p).ToList();
            }

            pagos = query.Sum(x => x.ValorPago);

            return pagos;

        }

        public int NoAbonosXDia(DateTime fechaInicial, DateTime fechaFinal)
        {
            var query = new List<Pago>();            

            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago
                         where p.FechaPago >= fechaInicial && p.FechaPago <= fechaFinal
                         select p).ToList();
            }

            return query.Count();

        }

        public void EliminarPago(int idPago)
        {
            using (var context = new PrestamosEntities())
            {

                Pago pago = context.Pago.Where(x => x.IDPago == idPago).FirstOrDefault();

                pago.Pagado = false;
                context.SaveChanges();

            }

        }

        public Pago GetCuota(int idpago)
        {
            var query = new Pago();

            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago
                         where p.IDPago == idpago                         
                         select p).FirstOrDefault();
            }

            return query;
        }

        public decimal PorCobrar(DateTime fechaIni, DateTime FechaFinal)
        {
            decimal valor = 0;     
            using (var context = new PrestamosEntities())
            {
               

                var query = context.GetPorCobrarXFecha(fechaIni, FechaFinal).FirstOrDefault();



                if (query == null) valor = 0;
                else valor = decimal.Parse(query.ToString());
            }
            

            return valor;
        }


        public List<Pago> CuotasXPagar(int prestamoID)
        {
            var query = new List<Pago>();

            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago
                         join pp in context.PrestamoPago on p.PrestamoPagoID equals pp.PrestamoPagoID
                         where pp.NoPrestamo == prestamoID && p.Pagado == false
                         orderby p.Cuota ascending
                         select p).ToList();
            }

            return query;
        }

        public List<Pago> GetPagosXPrestamoIDPagados(int prestamoID)
        {

            var query = new List<Pago>();

            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago
                         join pp in context.PrestamoPago on p.PrestamoPagoID equals pp.PrestamoPagoID
                         where pp.NoPrestamo == prestamoID && p.Pagado == true
                         orderby p.IDPago ascending
                         select p).ToList();
            }

            return query;
        }
    }
}
