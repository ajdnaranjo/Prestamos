using Prestamos.Repositorios;
using System;
using System.Windows.Forms;

namespace Prestamos.Consultas
{
    public partial class frmMovimiento : Form
    {
        public frmMovimiento()
        {
            InitializeComponent();
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            var repoPagos = new RepositorioPagos();
            var totalPagos = repoPagos.TotalPagosxDia(DateTime.Parse(dtpFechaInicial.Text), DateTime.Parse(dtpFechaFinal.Text));
            var repoPrestamos = new RepositorioCrearPrestamo();
            var totalPrestamos = repoPrestamos.PrestamoxFecha(DateTime.Parse(dtpFechaInicial.Text), DateTime.Parse(dtpFechaFinal.Text));
            var NoAbonos = repoPagos.NoAbonosXDia(DateTime.Parse(dtpFechaInicial.Text), DateTime.Parse(dtpFechaFinal.Text));

            lblTotalPrestamos.Text = totalPrestamos.ToString("N");
            lbltotalPagos.Text = totalPagos.ToString("N");
            lblNoAbonos.Text = NoAbonos.ToString();
        }

      

           
    }
}
