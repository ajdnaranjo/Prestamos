using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Repositorios
{
    [Serializable]
    public class RepositorioUsuarios : PrestamosEntities
    {


        public void GuardarUsuario(Usuarios usuario)
        {
            using (var context = new PrestamosEntities())
            {

                var user = new Usuarios();

                user = context.Usuarios.FirstOrDefault(c => c.Usuario == usuario.Usuario);

                if (user == null)
                {

                    user = new Usuarios();
                    user.Usuario = usuario.Usuario;
                    user.Contrasena = Encriptar(usuario.Contrasena);
                    user.Nombre = usuario.Nombre;
                    user.Estado = usuario.Estado;
                    user.FechaModificación = DateTime.Now;
                    context.Usuarios.Add(user);
                }
                else
                {
                    Usuarios c = context.Usuarios.FirstOrDefault(cl => cl.Usuario == usuario.Usuario);

                    c.Contrasena = Encriptar(usuario.Contrasena);
                    c.Nombre = usuario.Nombre;
                    c.Estado = usuario.Estado;
                    c.FechaModificación = DateTime.Now;                   
                }

                context.SaveChanges();

            }
        }

        public bool ValidarUsuario(Usuarios usuario)
        {
            var flag = false;
            using (var context = new PrestamosEntities())
            {
                
                var user = context.Usuarios.FirstOrDefault(c => c.Usuario == usuario.Usuario && c.Estado == true);

                if (user != null)
                {
                    if (user.Usuario == usuario.Usuario && DesEncriptar(user.Contrasena) == usuario.Contrasena)
                        flag = true;
                }

            }
            return flag;
        }

        private static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        private static string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
