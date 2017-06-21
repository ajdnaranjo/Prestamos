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
    public partial class frmClientes : Form
    {
        public int _documento = 0;

        public frmClientes()
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

            if (_documento != 0)
                txtDocumento.Text = _documento.ToString();
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            int salida;
            bool entero = Int32.TryParse(txtDocumento.Text.Trim(), out salida);
            if (txtDocumento.Text.Trim() != "")
            {
                if (!entero)
                {
                    MessageBox.Show("El documento debe ser un número entero.");
                    return;
                }
                else
                    llenarCliente(int.Parse(txtDocumento.Text.Trim()));
            }

        }

        private void llenarCliente(int documento)
        {
            RepositorioClientes repo = new RepositorioClientes();
            Cliente cliente = new Cliente();
            cliente = repo.ClienteXDocumento(documento);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                txtCelular.Text = cliente.Celular.ToString();
                if (cliente.Estado.Equals(true))
                    ddlEstado.SelectedItem = "Activo";
                else
                    ddlEstado.SelectedItem = "InActivo";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int salida;
            long salida2;
            bool entero = Int32.TryParse(txtDocumento.Text.Trim(), out salida);
            if (!entero)
            {
                MessageBox.Show("El documento debe ser un número entero.");
                return;
            }
            entero= Int64.TryParse(txtCelular.Text.Trim(), out salida2);
            if (!entero)
            {
                MessageBox.Show("El celular debe ser un número entero.");
                return;
            }
            if (ddlEstado.SelectedItem.Equals("Seleccionar"))
            {
                MessageBox.Show("Debe Seleccionar un estado.");
                return;
            }
            RepositorioClientes repo = new RepositorioClientes();
            bool estado = false;
            if (ddlEstado.SelectedItem.Equals("Activo")) estado = true;
            if (ddlEstado.SelectedItem.Equals("InActivo")) estado = false;
            var cliente = new Cliente()
            {
                Documento = int.Parse(txtDocumento.Text.Trim()),
                Nombre  = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Celular = txtCelular.Text.Trim(),
                Estado = estado
            };
            try
            {
                repo.GuardarCliente(cliente);
                MessageBox.Show("El cliente se ha guardado correctamente.");
                LimpiarFormulario();
                Buscar(txtBuscar.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error, intente nuevamente.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text.Trim());
        }

        private void Buscar(string buscar)
        {
            RepositorioClientes repo = new RepositorioClientes();
            List<Cliente> clientes = repo.Clientes(buscar);
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = clientes;
        }

        private void LimpiarFormulario()
        {
            txtDocumento.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text =  string.Empty;
            txtCelular.Text = string.Empty;
            ddlEstado.SelectedItem = "Seleccionar";
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvClientes.CurrentRow;
            int salida;
            if (row.Cells[0].Value.ToString() != "")
            {
                bool entero = Int32.TryParse(row.Cells[0].Value.ToString(), out salida);
                if (entero)
                {
                    var repo = new RepositorioClientes();
                    var cliente = repo.ClienteXDocumento(int.Parse(row.Cells[0].Value.ToString()));
                    txtDocumento.Text = cliente.Documento.ToString();
                    txtNombre.Text = cliente.Nombre;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    txtCelular.Text = cliente.Celular;
                    if (cliente.Estado == true) ddlEstado.SelectedItem = "Activo";
                    if (cliente.Estado == false) ddlEstado.SelectedItem = "InActivo";
                }
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void tab(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;

                SendKeys.Send("{TAB}");

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            tab(e);
        }
    }
}
