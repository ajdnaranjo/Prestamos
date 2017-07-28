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

namespace Prestamos.Consultas
{
    public partial class frmPrestamosCancelados : Form
    {
        public frmPrestamosCancelados()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioCrearPrestamo();
            var cancelados = repo.PrestamosCancelados(dtpDesde.Value, dtpHasta.Value);

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = cancelados;

            txtTotal.Text = cancelados.Sum(x => x.Total).ToString("N0");
        }
    }
}
