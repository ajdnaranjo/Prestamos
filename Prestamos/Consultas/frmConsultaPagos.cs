using Prestamos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Prestamos.Modelos;

namespace Prestamos.Consultas
{
    public partial class frmConsultaPagos : Form
    {
        public frmConsultaPagos()
        {
            InitializeComponent();
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() != "")
            {
                try
                {
                    var repo = new RepositorioCrearPrestamo();
                    var repocliente = new RepositorioClientes();
                    List<Prestamo> prestamos = new List<Prestamo>();
                    prestamos = repo.GetPrestamosXDocumento(long.Parse(txtDocumento.Text.Trim()));
                    cbNoPrestamo.DisplayMember = "NoPrestamo";
                    cbNoPrestamo.ValueMember = "NoPrestamo";
                    cbNoPrestamo.DataSource = prestamos;
                    var cliente = repocliente.ClienteXDocumento(long.Parse(txtDocumento.Text.Trim()));
                    txtNombre.Text = cliente.Nombre;
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error, por favor verifique la información ingresada.");
                }
            }
        }

        private void cbNoPrestamo_SelectedValueChanged(object sender, EventArgs e)
        {
            var repo = new RepositorioCrearPrestamo();
            var prestamo = new Prestamo();


            if (cbNoPrestamo.SelectedItem != null )
            {
                if (cbNoPrestamo.SelectedItem.ToString() != "Seleccionar")
                {
                    prestamo = repo.GetPrestamosXID(int.Parse(cbNoPrestamo.SelectedValue.ToString()));

                    if (prestamo.Estado == true)
                        txtEstado.Text = "Activo";
                    else
                        txtEstado.Text = "Pagado";
                    txtValorTotal.Text = prestamo.Total.ToString("N0");

                    var repop = new RepositorioPagos();
                    var pagos = repop.ConsultaPagos(int.Parse(cbNoPrestamo.SelectedValue.ToString()));
                    var pagados = repop.GetPagosCuotasXPrestamoID(int.Parse(cbNoPrestamo.SelectedValue.ToString()));

                    var sumaAbonos = pagados.Sum(x => x.Valor);
                    txtTotalAbonos.Text = sumaAbonos.ToString("N0");
                    txtSaldoPendiente.Text = (prestamo.Total - sumaAbonos).ToString("N0");

                    dtgDatos.AutoGenerateColumns = false;
                    dtgDatos.Columns["valorpago"].DefaultCellStyle.Format = "N0";
                    dtgDatos.Columns["saldo"].DefaultCellStyle.Format = "N0";
                    dtgDatos.DataSource = pagos;
                }
            }
        }

        private void tab(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;

                SendKeys.Send("{TAB}");

            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void cbNoPrestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            txtDocumento.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtValorTotal.Text = string.Empty;
            txtTotalAbonos.Text = string.Empty;
            txtSaldoPendiente.Text = string.Empty;
            cbNoPrestamo.DataSource = null;
            cbNoPrestamo.Items.Add("Seleccionar");
            cbNoPrestamo.SelectedItem = "Seleccionar";
            dtgDatos.DataSource = null;
            txtNombre.Text = string.Empty;
        }
    }
}
