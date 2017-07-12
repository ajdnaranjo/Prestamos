using System;
using System.Windows.Forms;
using System.Drawing;

namespace Prestamos
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
            
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Maestros.frmClientes frm = new Maestros.frmClientes();
            frm.MdiParent  = this;
            frm.Show();
        }


        private void crearPrestamoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Proceso.frmCrearPrestamo frm = new Proceso.frmCrearPrestamo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proceso.frmPagos frm = new Proceso.frmPagos();
            frm.MdiParent = this;
            frm.Show();
        }

    
        private void consultarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.frmConsultaPagos frm = new Consultas.frmConsultaPagos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void movimientoDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.frmMovimiento frm = new Consultas.frmMovimiento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
 

        private void eliminarPrestamosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Proceso.frmEliminarPrestamos frm = new Proceso.frmEliminarPrestamos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void eliminarPagosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Proceso.frmEliminarPagos frm = new Proceso.frmEliminarPagos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void morososToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.frmMorosos frm = new Consultas.frmMorosos();
            frm.MdiParent = this;
            frm.Show();

        }
    }
}
