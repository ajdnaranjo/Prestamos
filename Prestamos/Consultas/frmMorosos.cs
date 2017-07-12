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
    public partial class frmMorosos : Form
    {
        public frmMorosos()
        {
            InitializeComponent();
            InitialLoad();
        }

        private void InitialLoad()
        {

            var repo = new RepositorioPagos();
            var morosos = repo.Morosos();

            dgvMorosos.AutoGenerateColumns = false;
            dgvMorosos.DataSource = morosos;
        }

    }
}
