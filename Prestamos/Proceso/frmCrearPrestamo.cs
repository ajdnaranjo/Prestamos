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
    public partial class frmCrearPrestamo : Form
    {
        public frmCrearPrestamo()
        {
            InitializeComponent();
            InitialLoad();

        }

        private void InitialLoad()
        {
            RepositorioCrearPrestamo repo = new RepositorioCrearPrestamo();
            txtNoPrestamo.Text =  repo.GetPrestamoID().ToString();

            cbFormaPago.DataSource = repo.GetFormasPago();           
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                var prestamo = new Prestamo()
                {
                    NoPrestamo = int.Parse(txtNoPrestamo.Text.Trim()),
                    Documento = long.Parse(txtDocumento.Text.Trim()),
                    ValorPrestamo = decimal.Parse(txtVlrPrestamo.Text.Trim()),
                    NoCuotas = int.Parse(txtNoCuotas.Text.Trim()),
                    FormaPagoID = int.Parse(cbFormaPago.SelectedValue.ToString()),
                    Intereses = decimal.Parse(txtIntereses.Text.Trim()),
                    ValorCuota = decimal.Parse(txtVlrCuota.Text.Trim()),
                    Ganancias = decimal.Parse(txtGanancias.Text.Trim()),
                    FechaPrestamo = DateTime.Parse(dtpFecha.Text),
                    Saldo = decimal.Parse(txtTotal.Text.Trim()),
                    Total = decimal.Parse(txtTotal.Text.Trim()),
                    Estado = true
                    
                };

                try
                {
                    var repoCliente = new RepositorioClientes();
                    RepositorioCrearPrestamo repo = new RepositorioCrearPrestamo();


                    var cliente = repoCliente.ClienteXDocumento(prestamo.Documento);                    

                    if (cliente != null && cliente.Estado == true)
                    {

                        repo.CrearPresatamo(prestamo);

                    }
                    else {
                        MessageBox.Show("El cliente no existe o se encuentra inactivo.");
                    }

                    MessageBox.Show("Prestamo guardado correctamente.");

                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error, intente nuevamente.");
                }
            }
            else
                MessageBox.Show("Información incorrecta o incompleta. Por favor verifique los datos ingresados.");
        }

        private bool ValidarCampos()
        { 
            bool flag = true;
            int salida;
            long salida3;
            decimal salida2;
            bool entero = long.TryParse(txtDocumento.Text.Trim(), out salida3);
            if (!entero) flag = false;
            entero = decimal.TryParse(txtVlrPrestamo.Text.Trim(), out salida2);
            if (!entero) flag = false;
            entero = Int32.TryParse(txtNoCuotas.Text.Trim(), out salida);
            if (!entero) flag = false;
            entero = Int32.TryParse(txtIntereses.Text.Trim(), out salida);
            if (!entero) flag = false;

            return flag;
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
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
        }

        private void txtIntereses_Leave(object sender, EventArgs e)
        {
            decimal valorCuota = 0;
            valorCuota = (decimal.Parse(txtVlrPrestamo.Text.Trim()) +
                        (decimal.Parse(txtVlrPrestamo.Text.Trim()) * decimal.Parse(txtIntereses.Text.Trim())) / 100)
                        / decimal.Parse(txtNoCuotas.Text.Trim());

            txtVlrCuota.Text = valorCuota.ToString("N0");

            decimal ganancias = 0;
            ganancias =  (decimal.Parse(txtVlrPrestamo.Text.Trim()) * (decimal.Parse(txtIntereses.Text.Trim()) / 100));
            txtGanancias.Text = ganancias.ToString("N0");

            decimal total = 0;
            total = (decimal.Parse(txtVlrPrestamo.Text.Trim()) +
                (decimal.Parse(txtVlrPrestamo.Text.Trim()) * decimal.Parse(txtIntereses.Text.Trim())) / 100);
            txtTotal.Text = total.ToString("N0");
            
        }

        private void LimpiarFormulario()
        {
            RepositorioCrearPrestamo repo = new RepositorioCrearPrestamo();
            txtNoPrestamo.Text = repo.GetPrestamoID().ToString();

            txtDocumento.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtVlrPrestamo.Text = string.Empty;
            txtNoCuotas.Text = string.Empty;
            txtIntereses.Text = "20";
            txtVlrCuota.Text = string.Empty;
            txtGanancias.Text = string.Empty;
            txtTotal.Text = string.Empty;

        }


        private void txtVlrPrestamo_Leave(object sender, EventArgs e)
        {
            if (txtVlrPrestamo.Text.Trim() != "")
            {
                decimal valor = decimal.Parse(txtVlrPrestamo.Text.Trim());
                txtVlrPrestamo.Text = valor.ToString("N0");
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

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtVlrPrestamo_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtNoCuotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtIntereses_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }
    }
}
