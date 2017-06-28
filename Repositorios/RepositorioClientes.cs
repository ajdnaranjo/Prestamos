using System;
using System.Collections.Generic;
using System.Linq;


namespace Prestamos.Repositorios
{
    [Serializable]
    public class RepositorioClientes: PrestamosEntities
    {
        public Cliente ClienteXDocumento(long documento)
        {
            var query = new Cliente();

            using (var context = new PrestamosEntities())
            {
                query = (from c in context.Cliente
                         where c.Documento == documento
                         select c).FirstOrDefault();
                }

            return query;

        }

        public void GuardarCliente(Cliente cliente)
        {
            using (var context = new PrestamosEntities())
            {

                var client = new Cliente();

                client = context.Cliente.FirstOrDefault(c => c.Documento == cliente.Documento);

                if (client == null)
                {

                    client = new Cliente();
                    client.Documento = cliente.Documento;
                    client.Nombre = cliente.Nombre;
                    client.Direccion = cliente.Direccion;
                    client.Telefono = cliente.Telefono;
                    client.Celular = cliente.Celular;
                    client.Estado = cliente.Estado;
                    context.Cliente.Add(client);
                }
                else
                {
                    Cliente c = context.Cliente.FirstOrDefault(cl => cl.Documento == cliente.Documento);

                    c.Nombre = cliente.Nombre;
                    c.Direccion = cliente.Direccion;
                    c.Telefono = cliente.Telefono;
                    c.Celular = cliente.Celular;
                    c.Estado = cliente.Estado;
                }

                context.SaveChanges();

            }

        }


        public List<Cliente> Clientes(string nombre)
        {
            var query = new List<Cliente>();

            using (var context = new PrestamosEntities())
            {
                query = (from c in context.Cliente
                         where c.Nombre.Contains(nombre)
                         orderby c.Nombre                       
                         select c).ToList();
            }

            return query;

        }
    }
}
