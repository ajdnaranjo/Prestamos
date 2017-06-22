using System;
using System.Collections.Generic;
using System.Linq;

namespace Prestamos.Repositorios
{
    [Serializable]
    public class RepositorioCrearPrestamo:PrestamosEntities
    {

        public int GetPrestamoID()
        {
            int id = 0;
            using (var context = new PrestamosEntities())
            {

                var value = Prestamo.OrderByDescending(item => item.NoPrestamo).FirstOrDefault();

                if (value == null)
                    id = 1;
                else
                    id = value.NoPrestamo + 1;
            }
    
            return id ;

        }

        public List<FormasPago> GetFormasPago()
        {
            var query = new List<FormasPago>();            
            using (var context = new PrestamosEntities())
            {
                query = (from c in context.FormasPago
                         orderby c.Descripcion ascending
                         select c).ToList();
            }

            return query;

        }

        public void CrearPresatamo(Prestamo prestamo)
        {
            using (var context = new PrestamosEntities())
            {

                var presta = new Prestamo();


                    presta = new Prestamo();
                    presta.Documento = prestamo.Documento;
                    presta.FechaPrestamo = prestamo.FechaPrestamo;
                    presta.ValorPrestamo = prestamo.ValorPrestamo;
                    presta.NoCuotas = prestamo.NoCuotas;
                    presta.FormaPagoID = prestamo.FormaPagoID;
                    presta.Intereses = prestamo.Intereses;
                    presta.ValorCuota = prestamo.ValorCuota;
                    presta.Ganancias = prestamo.Ganancias;
                    presta.Saldo = prestamo.Saldo;
                    presta.Total = prestamo.Total;
                    presta.Estado = prestamo.Estado;

                    context.Prestamo.Add(presta);

                    context.SaveChanges();

            }

        }

        public List<Prestamo> GetPrestamosXDocumento(int documento)
        {
            var query = new List<Prestamo>();
            using (var context = new PrestamosEntities())
            {
                query = (from c in context.Prestamo
                         where c.Documento == documento 
                         orderby c.NoPrestamo ascending
                         select c).ToList();
            }

            return query;
        }

        public Prestamo GetPrestamosXID(int id)
        {
            var query = new Prestamo();
            using (var context = new PrestamosEntities())
            {
                query = (from c in context.Prestamo
                         where c.NoPrestamo == id                      
                         select c).FirstOrDefault();
            }

            return query;
        }

        public decimal PrestamoxFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            decimal totalPrestamos;
            var query = new List<Prestamo>();
            using (var context = new PrestamosEntities())
            {
                query = (from c in context.Prestamo
                         where c.FechaPrestamo >= fechaInicial && c.FechaPrestamo <= fechaFinal 
                         select c).ToList();
            }

            totalPrestamos = query.Sum(x => x.ValorPrestamo);
            return totalPrestamos;
        }

        public void EliminarPrestamo(int noPrestamo)
        {
            using (var context = new PrestamosEntities())
            {

                List<PrestamoPago> pPagos = context.PrestamoPago.Where(x => x.NoPrestamo == noPrestamo).ToList();

                foreach (PrestamoPago pp in pPagos)
                {
                    Pago pago = context.Pago.Where(x => x.PrestamoPagoID == pp.PrestamoPagoID).SingleOrDefault();

                    if (pago != null)
                    {
                        context.Pago.Remove(pago);
                        context.SaveChanges();
                    }

                    context.PrestamoPago.Remove(pp);
                    context.SaveChanges();
                }

                Prestamo prestamo = context.Prestamo.Where(x => x.NoPrestamo == noPrestamo).FirstOrDefault();

                context.Prestamo.Remove(prestamo);
                context.SaveChanges();


            }

        }


        public void RecalcularSaldo(int noPrestamo, decimal valor)
        {
            using (var context = new PrestamosEntities())
            {
               
                Prestamo p = context.Prestamo.FirstOrDefault(cl => cl.NoPrestamo == noPrestamo);
                decimal sumaSaldos = p.Total;
                List<Pago> pagos = (from pa in context.Pago
                             join pp in context.PrestamoPago on pa.PrestamoPagoID equals pp.PrestamoPagoID
                             where pp.NoPrestamo == p.NoPrestamo
                             orderby  pa.Cuota ascending
                             select pa).ToList();

                foreach (Pago r in pagos)
                {
                    Pago pago = context.Pago.FirstOrDefault(x => x.IDPago == r.IDPago);

                    sumaSaldos = sumaSaldos - pago.ValorPago;
                    pago.Saldo = sumaSaldos;

                    context.SaveChanges();

                }


                p.Saldo = valor;

                context.SaveChanges();



            }

        }
    }
}
