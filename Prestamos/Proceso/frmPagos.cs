using Prestamos.Repositorios;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Prestamos.Proceso
{
    public partial class frmPagos : Form
    {
        public frmPagos()
        {
            InitializeComponent();
            InitialLoad();
        }

        private void InitialLoad()
        {
            cbPrestamos.Items.Add("Seleccionar");
            cbPrestamos.SelectedItem = "Seleccionar";
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() != "")
            {
                RepositorioCrearPrestamo repo = new RepositorioCrearPrestamo();
                var prestamos = repo.GetPrestamosXDocumento(long.Parse(txtDocumento.Text.Trim())).Where(x => x.Estado == true).ToList();

                if (prestamos.Count != 0)
                {
                    cbPrestamos.DisplayMember = "NoPrestamo";
                    cbPrestamos.ValueMember = "NoPrestamo";
                    cbPrestamos.DataSource = prestamos;                    
                }
                else MessageBox.Show("El documento ingresado no tiene prestamos asignados.");
                
                
            }
        }
      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbCuotas.SelectedItem.ToString() == "Seleccionar")
            {
                MessageBox.Show("Debe seleccionar una cuota.");
            }
            else
            {
                RepositorioCrearPrestamo repo = new RepositorioCrearPrestamo();
                RepositorioPagos repoPago = new RepositorioPagos();
                var prestamo = repo.GetPrestamosXID(int.Parse(cbPrestamos.SelectedValue.ToString()));
                var pago = new Pago();

                pago.ValorPago = decimal.Parse(txtAbono.Text.Trim());
                pago.Saldo = prestamo.Saldo - pago.ValorPago;
                pago.FechaPago = DateTime.Parse(dtpFechaPago.Text);
                pago.IDPago = int.Parse(cbCuotas.SelectedValue.ToString());

                txtSaldo.Text = pago.Saldo.ToString("N");

                try
                {
                    repoPago.GuardarPago(pago, prestamo);
                    MessageBox.Show("El pago se ha ingresado correctamente.");

                    var prestamop = repo.GetPrestamosXID(int.Parse(cbPrestamos.SelectedValue.ToString()));
                    if (prestamop.Saldo <= 0) btnGuardar.Enabled = false;

                    LimpiarFormulario();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error, intente nuevamente. " + ex);
                }

            }
        }

        private void cbPrestamos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbPrestamos.SelectedItem != null)
            {
                if (!cbPrestamos.SelectedItem.Equals("Seleccionar"))
                {
                    RepositorioCrearPrestamo repo = new RepositorioCrearPrestamo();
                    var repoPago = new RepositorioPagos();
                    var prestamo = repo.GetPrestamosXID(int.Parse(cbPrestamos.SelectedValue.ToString()));
                    txtSaldo.Text = prestamo.Saldo.ToString("N");
                    txtVlrCuota.Text = prestamo.ValorCuota.ToString("N");

                    List<Pago> cuotas = repoPago.CuotasXPagar(int.Parse(cbPrestamos.SelectedValue.ToString()));

                    cbCuotas.DisplayMember = "Cuota";
                    cbCuotas.ValueMember = "IDPago";
                    cbCuotas.DataSource = cuotas;
                   
                    if (prestamo.Saldo <= 0)
                    {
                        MessageBox.Show("El prestamo ya ha sido cancelado, no se pueden realizar abonos.");
                        btnGuardar.Enabled = false;
                    }
                    else
                    {
                        txtValor.Text = prestamo.ValorPrestamo.ToString("N");
                        btnGuardar.Enabled = true;
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            btnGuardar.Enabled = true;
            txtDocumento.Text = string.Empty;
            cbPrestamos.DataSource = null;
            cbPrestamos.Items.Add("Seleccionar");
            cbPrestamos.SelectedItem = "Seleccionar";
            cbCuotas.DataSource = null;
            cbCuotas.Items.Add("Seleccionar");
            cbCuotas.SelectedItem = "Seleccionar";
            txtValor.Text = string.Empty;
            txtAbono.Text = string.Empty;
            txtSaldo.Text = string.Empty;
            txtVlrCuota.Text = string.Empty;
        }

        private void txtAbono_Leave(object sender, EventArgs e)
        {
            if (txtAbono.Text.Trim() != "")
            {
                decimal valor = decimal.Parse(txtAbono.Text.Trim());
                txtAbono.Text = valor.ToString("N");

                var repo = new RepositorioCrearPrestamo();
                var prestamo = repo.GetPrestamosXID(int.Parse(cbPrestamos.SelectedValue.ToString()));

                if (decimal.Parse(txtAbono.Text) < prestamo.ValorCuota)
                {
                    MessageBox.Show(string.Format("El valor del abono es menor al valor de la cuota a pagar. Valor cuota: {0}", prestamo.ValorCuota.ToString("N")));
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

        private void cbPrestamos_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void dtpFechaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioClientes();
            List<Cliente> clientes = repo.Clientes(txtBuscar.Text.Trim());
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = clientes;
            
    
        }

       

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvClientes.CurrentRow;
            long salida;
            if (row.Cells[0].Value.ToString() != "")
            {
                bool entero = long.TryParse(row.Cells[0].Value.ToString(), out salida);
                if (entero)
                {
                    var repo = new RepositorioClientes();
                    var cliente = repo.ClienteXDocumento(long.Parse(row.Cells[0].Value.ToString()));
                    txtDocumento.Text = cliente.Documento.ToString();
                    txtDocumento.Focus();
                }
            }
        }

   

        private void cbCuotas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCuotas.SelectedItem != null && cbCuotas.SelectedValue != null)
            {
                if (cbCuotas.SelectedItem.ToString() != "Selccionar")
                {
                    var repo = new RepositorioPagos();
                    var pagos = repo.GetPagosXPrestamoID(int.Parse(cbPrestamos.SelectedValue.ToString()));

                    var pago = pagos.Where(x => x.IDPago == int.Parse(cbCuotas.SelectedValue.ToString())).FirstOrDefault();

                    txtVlrCuota.Text = pago.ValorPago.ToString("N");
                }
            }
        }
    }
}
