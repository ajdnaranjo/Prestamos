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

namespace Prestamos.Maestros
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            InitialLoad();
        }

        private void InitialLoad()
        {
            ddlEstado.Items.Add("Seleccionar");
            ddlEstado.Items.Add("Activo");
            ddlEstado.Items.Add("InActivo");
            ddlEstado.SelectedItem = "Seleccionar";
       

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioUsuarios();
            var user = new Usuarios();

            user.Usuario = txtUsuario.Text.Trim();
            user.Contrasena = txtContrasena.Text;
            user.Nombre = txtNombre.Text.Trim();
            if (ddlEstado.SelectedItem.ToString() == "Activo")
                user.Estado = true;
            else
                user.Estado = false;

            try
            {
                repo.GuardarUsuario(user);

                MessageBox.Show("Usuario guardado correctamente.");
                limpiarForm();
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error. Verifique la información ingresada. ");
            }
        }

        private void limpiarForm()
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtNombre.Text = string.Empty;
            ddlEstado.SelectedItem = "Seleccionar";

        }
    }
}
