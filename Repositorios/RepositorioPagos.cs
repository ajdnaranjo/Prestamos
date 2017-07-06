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
                var pag = context.Pago.FirstOrDefault(x => x.IDPago == pago.IDPago);

                if (pago.ValorPago < pag.ValorPago)
                {
                    var pc = new PagoCuota();
                    pc = new PagoCuota();
                    pc.IDPago = pago.IDPago;
                    pc.Valor = pago.ValorPago;
                    pc.FechaPago = DateTime.Now;
                    context.PagoCuota.Add(pc);

                    var pp = new PrestamoPago();
                    pp = new PrestamoPago();
                    pp.NoPrestamo = prestamo.NoPrestamo;
                    context.PrestamoPago.Add(pp);                    

                    int id = pp.PrestamoPagoID;

                    var p = new Pago();
                    p = new Pago();
                    p.PrestamoPagoID = id;
                    p.Cuota = pag.Cuota;
                    p.ValorPago = pag.ValorPago - pago.ValorPago;
                    p.Saldo = pag.Saldo - pago.ValorPago;
                    p.FechaPago = DateTime.Now;
                    p.Pagado = false;
                    context.Pago.Add(p);

                    Pago pg = context.Pago.FirstOrDefault(x => x.IDPago == pago.IDPago);

                    pg.Pagado = true;

                    context.SaveChanges();
                }
                else
                {

                    if (pago.ValorPago > pag.ValorPago)
                    {

                        var pagosFaltantes = (from p in context.Pago
                                              join pp in context.PrestamoPago on p.PrestamoPagoID equals pp.PrestamoPagoID
                                              where pp.NoPrestamo == prestamo.NoPrestamo && p.Pagado == false
                                              orderby p.Cuota
                                              select p).ToList();

                        var sumaPagos = pagosFaltantes.Sum(z => z.ValorPago);

                        if (pago.ValorPago > sumaPagos)
                        {
                            throw new Exception("El valor ingresado supera el saldo pendiente de pago.");
                        }
                        else
                        {
                            var splitPago = pago.ValorPago;

                            foreach (Pago r in pagosFaltantes)
                            {
                                if (splitPago > 0)
                                {
                                    splitPago = splitPago - r.ValorPago;

                                    if (splitPago < 0)
                                    {
                                        splitPago = splitPago + r.ValorPago;

                                        var pc = new PagoCuota();
                                        pc = new PagoCuota();
                                        pc.IDPago = r.IDPago;
                                        pc.Valor = splitPago;
                                        pc.FechaPago = DateTime.Now;
                                        context.PagoCuota.Add(pc);

                                        var pp = new PrestamoPago();
                                        pp = new PrestamoPago();
                                        pp.NoPrestamo = prestamo.NoPrestamo;
                                        context.PrestamoPago.Add(pp);

                                        int id = pp.PrestamoPagoID;

                                        var p = new Pago();
                                        p = new Pago();
                                        p.PrestamoPagoID = id;
                                        p.Cuota = r.Cuota;
                                        p.ValorPago = r.ValorPago - splitPago;
                                        p.Saldo = r.Saldo - splitPago;
                                        p.FechaPago = DateTime.Now;
                                        p.Pagado = false;
                                        context.Pago.Add(p);

                                        Pago pg = context.Pago.FirstOrDefault(x => x.IDPago == r.IDPago);
                                        pg.Pagado = true;

                                        context.SaveChanges();

                                        splitPago = splitPago - r.ValorPago;

                                    }
                                    else
                                    {
                                        var pc = new PagoCuota();
                                        pc = new PagoCuota();
                                        pc.IDPago = r.IDPago;
                                        pc.Valor = r.ValorPago;
                                        pc.FechaPago = DateTime.Now;
                                        context.PagoCuota.Add(pc);

                                        Pago pg = context.Pago.FirstOrDefault(x => x.IDPago == r.IDPago);
                                        pg.Pagado = true;

                                        context.SaveChanges();

                                    }
                                  
                                }



                            }
                        }
                    }
                    else
                    {
                        var pc = new PagoCuota();
                        pc = new PagoCuota();
                        pc.IDPago = pago.IDPago;
                        pc.Valor = pago.ValorPago;
                        pc.FechaPago = DateTime.Now;
                        context.PagoCuota.Add(pc);

                        Pago pg = context.Pago.FirstOrDefault(x => x.IDPago == pago.IDPago);
                        pg.Pagado = true;

                        context.SaveChanges();
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
                         orderby p.Cuota ascending
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

                PagoCuota pagoCuota = context.PagoCuota.FirstOrDefault(x => x.IDPago == idPago);
                context.PagoCuota.Remove(pagoCuota);

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
                         orderby p.Cuota, p.IDPago ascending
                         select p).ToList();
            }

            return query;
        }

        public List<PagoCuota> GetPagosCuotasXPrestamoID(int prestamoID)
        {

            var query = new List<PagoCuota>();

            using (var context = new PrestamosEntities())
            {
                query = (from p in context.Pago
                         join pp in context.PrestamoPago on p.PrestamoPagoID equals pp.PrestamoPagoID
                         join pc in context.PagoCuota on p.IDPago equals pc.IDPago
                         where pp.NoPrestamo == prestamoID                          
                         select pc).ToList();
            }

            return query;
        }
    }
}
