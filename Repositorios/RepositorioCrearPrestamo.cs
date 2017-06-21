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
    }
}
