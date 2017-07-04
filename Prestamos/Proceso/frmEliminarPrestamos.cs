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

namespace Prestamos.Proceso
{
    public partial class frmEliminarPrestamos : Form
    {
        public frmEliminarPrestamos()
        {
            InitializeComponent();
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() != "")
            {

                txtNombre.Text = string.Empty;
                long salida;
                bool entero = long.TryParse(txtDocumento.Text.Trim(), out salida);
                if (entero)
                {
                    RepositorioClientes repo = new RepositorioClientes();
                    Cliente cliente = new Cliente();
                    cliente = repo.ClienteXDocumento(long.Parse(txtDocumento.Text.Trim()));
                    if (cliente != null && cliente.Estado == true)
                        txtNombre.Text = cliente.Nombre;
                }


                RepositorioCrearPrestamo repop = new RepositorioCrearPrestamo();
                var prestamos = repop.GetPrestamosXDocumento(long.Parse(txtDocumento.Text.Trim())).Where(x => x.Estado == true).ToList();

                if (prestamos.Count != 0)
                {
                    cbNoPrestamo.DisplayMember = "NoPrestamo";
                    cbNoPrestamo.ValueMember = "NoPrestamo";
                    cbNoPrestamo.DataSource = prestamos;
                }
                else MessageBox.Show("El documento ingresado no tiene prestamos asignados.");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioCrearPrestamo();
            var prestamo = repo.GetPrestamosXID(int.Parse(cbNoPrestamo.SelectedValue.ToString()));
            var noPrestamo = prestamo.NoPrestamo;
            var valor = prestamo.ValorPrestamo;
            var closingPending = false;

            if (closingPending) return;
            string mesj = string.Format("Deseaa eliminar el prestamo No. {0} por valor de $ {1} ?", noPrestamo, valor.ToString("N"));
            DialogResult result = MessageBox.Show(mesj, "Eliminar",
                                   MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Information,
                                   MessageBoxDefaultButton.Button3);

            switch (result)
            {

                case DialogResult.Yes:
                    closingPending = true;
                    try
                    {
                        repo.EliminarPrestamo(int.Parse(cbNoPrestamo.SelectedValue.ToString()));
                        limpiarFormulario();

                        string mensaje = string.Format("El prestamo No. {0} por valor de $ {1} fué eliminado correctamente", noPrestamo, valor.ToString("N"));
                        MessageBox.Show(mensaje);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error, intente nuevamente.");
                    }
                    break;

                case DialogResult.No:
                    closingPending = true;                  
                    break;

                case DialogResult.Cancel:
                    closingPending = true;                   
                    break;
            }
           
        }


        private void limpiarFormulario()
        {
            txtDocumento.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cbNoPrestamo.DataSource = null;
            cbNoPrestamo.Items.Add("Seleccionar");
            cbNoPrestamo.SelectedItem = "Seleccionar";
        }
    }
}
