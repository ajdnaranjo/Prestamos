using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prestamos.Repositorios;

namespace Prestamos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioUsuarios();
            var user = new Usuarios();

            user.Usuario = txtUsuario.Text.Trim();
            user.Contrasena = txtContrasena.Text;

            var estado = repo.ValidarUsuario(user);

            if (estado == true)
            {
                this.Hide();
                frmInicio frm = new frmInicio();
                frm.Show();
            }
            else
            {
                MessageBox.Show("El usuario no existe o se encuentra inactivo.");
            }
        }

       
    }
}
