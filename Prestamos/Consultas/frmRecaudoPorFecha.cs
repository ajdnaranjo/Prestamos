﻿using System;
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
    public partial class frmRecaudoPorFecha : Form
    {
        public frmRecaudoPorFecha()
        {
            InitializeComponent();
        }

        private void btnVerRecaudo_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioPagos();
            var pagos = repo.RecaudosXFechaTotal(dtpDesde.Value, dtpHasta.Value);
            var detalles = repo.RecaudosXFechaDetalle(dtpDesde.Value, dtpHasta.Value);

            txtAbonos.Text = pagos.Count().ToString();
            txtRecaudo.Text = pagos.Sum(x => x.ValorPago).ToString("N0");

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = detalles;

        }
    }
}
