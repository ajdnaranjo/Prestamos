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
    public partial class frmEliminarPagos : Form
    {
        public frmEliminarPagos()
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


        private void limpiarFormulario()
        {
            txtDocumento.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cbNoPrestamo.DataSource = null;
            cbNoPrestamo.Items.Add("Seleccionar");
            cbNoPrestamo.SelectedItem = "Seleccionar";
        }

        private void cbNoPrestamo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbNoPrestamo.SelectedValue != null)
            {
                llenarGrid(int.Parse(cbNoPrestamo.SelectedValue.ToString()));
            }
        }

        private void cbNoPrestamo_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbNoPrestamo.SelectedValue != null)
            {
                llenarGrid(int.Parse(cbNoPrestamo.SelectedValue.ToString()));
            }
        }

        private void llenarGrid(int noPrestamo)
        {
            var repo = new RepositorioPagos();
            List<Pago> pagos = new List<Pago>();
            pagos = repo.GetPagosXPrestamoID(noPrestamo);

            dgvPagos.AutoGenerateColumns = false;
            dgvPagos.DataSource = pagos;
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {     
            DataGridViewRow row = dgvPagos.CurrentRow;           
            var repo = new RepositorioPagos();
            var repoPrestamo = new RepositorioCrearPrestamo();
            int noPrestamo = int.Parse(cbNoPrestamo.SelectedValue.ToString());
            int noCouta = int.Parse(row.Cells[0].Value.ToString());
            var prestamo = repoPrestamo.GetPrestamosXID(noPrestamo);
            var cuota = repo.GetCuota(noCouta);

            decimal saldo = prestamo.Saldo + cuota.ValorPago;

            var closingPending = false;

            if (closingPending) return;
            string mesj = string.Format("Deseaa eliminar la cuota No. {0} por valor de $ {1} ?", cuota.Cuota, cuota.ValorPago.ToString("N"));
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
                        repo.EliminarPago(noCouta);
                        repoPrestamo.RecalcularSaldo(noPrestamo, saldo);
                        limpiarFormulario();

                        string mensaje = string.Format("La cuota No. {0} por valor de $ {1} fué eliminada correctamente", cuota.Cuota, cuota.ValorPago.ToString("N"));
                        MessageBox.Show(mensaje);

                        dgvPagos.DataSource = null;
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
    }
}
