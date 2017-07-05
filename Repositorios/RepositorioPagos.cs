using System;
using System.Collections.Generic;
using System.Linq;

namespace Prestamos.Repositorios
{
    [Serializable]
    public class RepositorioPagos
    {

        public void GuardarPago(Pago pago, int noPrestamo)
        {
         /*   using (var context = new PrestamosEntities())
            {
                Pago p = context.Pago.FirstOrDefault(cl => cl.Documento == cliente.Documento);

                c.Nombre = cliente.Nombre;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.Celular = cliente.Celular;
                c.Estado = cliente.Estado;

                var pag = new Pago();

                pag = new Pago();
                pag.PrestamoPagoID = id;
                pag.Cuota = NumeroCuotaXNoPrestamo(noPrestamo);
                pag.ValorPago = pago.ValorPago;
                pag.Saldo = pago.Saldo;
                pag.FechaPago = pago.FechaPago;

                context.Pago.Add(pag);               

                Prestamo p = context.Prestamo.FirstOrDefault(c => c.NoPrestamo == noPrestamo);
                p.Saldo = pago.Saldo;
                if (p.Saldo <= 0) p.Estado = false;

                context.SaveChanges();

            }
            */
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
    }
}
