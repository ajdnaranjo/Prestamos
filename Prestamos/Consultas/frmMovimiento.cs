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
    public partial class frmMovimiento : Form
    {
        public frmMovimiento()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var repoPrestamos = new RepositorioCrearPrestamo();
            var repoPagos = new RepositorioPagos();

            txtTotalPrestamos.Text = 
                repoPrestamos.PrestamoxFecha(DateTime.Parse(dtpFechaini.Text), DateTime.Parse(dtpFechaFinal.Text)).ToString("N");
            txtTotalPagos.Text =
                repoPagos.TotalPagosxDia(DateTime.Parse(dtpFechaini.Text), DateTime.Parse(dtpFechaFinal.Text)).ToString("N");
            txtTotalAbonos.Text = 
                repoPagos.NoAbonosXDia(DateTime.Parse(dtpFechaini.Text), DateTime.Parse(dtpFechaFinal.Text)).ToString();
        }

      
    }
}
