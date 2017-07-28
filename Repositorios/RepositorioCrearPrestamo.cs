using System;
using System.Collections.Generic;
using System.Linq;
using Prestamos.Modelos;

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

                    int noPrestamo = presta.NoPrestamo;
                    decimal saldo = presta.Total;
            
                    for(int i=1; i<= presta.NoCuotas ; i++)
                    {
                        var prestpago = new PrestamoPago();

                        prestpago = new PrestamoPago();

                        prestpago.NoPrestamo = noPrestamo;
                        context.PrestamoPago.Add(prestpago);

                        context.SaveChanges();

                        int id = prestpago.PrestamoPagoID;


                        var pag = new Pago();

                        pag = new Pago();
                        pag.PrestamoPagoID = id;
                        pag.Cuota = i;
                        pag.ValorPago = presta.Total / presta.NoCuotas;                        
                        saldo = saldo - pag.ValorPago;
                        pag.Saldo = saldo;
                        pag.FechaPago = presta.FechaPrestamo.AddDays(i);
                        pag.Pagado = false;

                        context.Pago.Add(pag);

                        context.SaveChanges();
                    }

            }

        }

        public List<Prestamo> GetPrestamosXDocumento(long documento)
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
                    PagoCuota pagoCuota = context.PagoCuota.Where(x => x.IDPago == pago.IDPago).SingleOrDefault();

                    if (pago != null)
                    {
                        context.Pago.Remove(pago);                       
                    }
                    if (pagoCuota != null)
                    {
                        context.PagoCuota.Remove(pagoCuota);
                    }

                    context.PrestamoPago.Remove(pp);
                    context.SaveChanges();
                }

                Prestamo prestamo = context.Prestamo.Where(x => x.NoPrestamo == noPrestamo).FirstOrDefault();

                context.Prestamo.Remove(prestamo);
                context.SaveChanges();


            }

        }

        public void RecalcularSaldo(int noPrestamo)
        {
            using (var context = new PrestamosEntities())
            {
               
                Prestamo p = context.Prestamo.FirstOrDefault(cl => cl.NoPrestamo == noPrestamo);
                decimal sumaSaldos = p.Total;
                decimal sumaS = 0;
               // decimal sumaSaldosAnt = 0;
                List<Pago> pagos = (from pa in context.Pago
                             join pp in context.PrestamoPago on pa.PrestamoPagoID equals pp.PrestamoPagoID
                             where pp.NoPrestamo == p.NoPrestamo
                             orderby  pa.Cuota ascending
                             select pa).ToList();

                foreach (Pago r in pagos)
                {
                    Pago pago = context.Pago.FirstOrDefault(x => x.IDPago == r.IDPago);
                    //sumaSaldosAnt = sumaSaldos;
                    sumaSaldos = sumaSaldos - pago.ValorPago;

                  
                    pago.Saldo = sumaSaldos;

                    context.SaveChanges();

                    if (r.Pagado == true)
                    {
                        sumaS = sumaS + r.ValorPago;
                    }

                }

                p.Saldo = p.Total - sumaS;

                context.SaveChanges();



            }

        }

        public List<PrestamosDTO> PrestamosCancelados(DateTime fechaIni, DateTime fechaFinal)
        {
            var query = new List<PrestamosDTO>();
            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Prestamo
                         join c in context.Cliente on p.Documento equals c.Documento
                         where p.Estado == false && p.FechaPrestamo >= fechaIni && p.FechaPrestamo <= fechaFinal
                         orderby c.Nombre, p.NoPrestamo ascending
                         select new PrestamosDTO() {
                             Nombre = c.Nombre,
                             Documento = c.Documento,
                             NoPrestamo = p.NoPrestamo,
                             FechaPrestamo = p.FechaPrestamo,
                             Total = p.Total
                         }).ToList();
            }

            return query;
        }
    }
}
