namespace Prestamos
{
    partial class frmInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPrestamoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarPagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientoDiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morososToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recaudosPorFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosCanceladosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarPrestamosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarPagosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manejoUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manejoUsuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.procesoToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.manejoUsuariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1128, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.clientesToolStripMenuItem.Text = "Administrar Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // procesoToolStripMenuItem
            // 
            this.procesoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearPrestamoToolStripMenuItem1,
            this.registrarPagosToolStripMenuItem});
            this.procesoToolStripMenuItem.Name = "procesoToolStripMenuItem";
            this.procesoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.procesoToolStripMenuItem.Text = "Proceso";
            // 
            // crearPrestamoToolStripMenuItem1
            // 
            this.crearPrestamoToolStripMenuItem1.Name = "crearPrestamoToolStripMenuItem1";
            this.crearPrestamoToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.crearPrestamoToolStripMenuItem1.Text = "Crear prestamo";
            this.crearPrestamoToolStripMenuItem1.Click += new System.EventHandler(this.crearPrestamoToolStripMenuItem1_Click);
            // 
            // registrarPagosToolStripMenuItem
            // 
            this.registrarPagosToolStripMenuItem.Name = "registrarPagosToolStripMenuItem";
            this.registrarPagosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.registrarPagosToolStripMenuItem.Text = "Registrar pagos";
            this.registrarPagosToolStripMenuItem.Click += new System.EventHandler(this.registrarPagosToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarPagosToolStripMenuItem,
            this.movimientoDiarioToolStripMenuItem,
            this.morososToolStripMenuItem,
            this.recaudosPorFechaToolStripMenuItem,
            this.prestamosCanceladosToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // consultarPagosToolStripMenuItem
            // 
            this.consultarPagosToolStripMenuItem.Name = "consultarPagosToolStripMenuItem";
            this.consultarPagosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.consultarPagosToolStripMenuItem.Text = "Consultar pagos";
            this.consultarPagosToolStripMenuItem.Click += new System.EventHandler(this.consultarPagosToolStripMenuItem_Click);
            // 
            // movimientoDiarioToolStripMenuItem
            // 
            this.movimientoDiarioToolStripMenuItem.Name = "movimientoDiarioToolStripMenuItem";
            this.movimientoDiarioToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.movimientoDiarioToolStripMenuItem.Text = "Movimiento diario";
            this.movimientoDiarioToolStripMenuItem.Click += new System.EventHandler(this.movimientoDiarioToolStripMenuItem_Click);
            // 
            // morososToolStripMenuItem
            // 
            this.morososToolStripMenuItem.Name = "morososToolStripMenuItem";
            this.morososToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.morososToolStripMenuItem.Text = "Morosos";
            this.morososToolStripMenuItem.Click += new System.EventHandler(this.morososToolStripMenuItem_Click);
            // 
            // recaudosPorFechaToolStripMenuItem
            // 
            this.recaudosPorFechaToolStripMenuItem.Name = "recaudosPorFechaToolStripMenuItem";
            this.recaudosPorFechaToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.recaudosPorFechaToolStripMenuItem.Text = "Recaudos por fecha";
            this.recaudosPorFechaToolStripMenuItem.Click += new System.EventHandler(this.recaudosPorFechaToolStripMenuItem_Click);
            // 
            // prestamosCanceladosToolStripMenuItem
            // 
            this.prestamosCanceladosToolStripMenuItem.Name = "prestamosCanceladosToolStripMenuItem";
            this.prestamosCanceladosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.prestamosCanceladosToolStripMenuItem.Text = "Prestamos cancelados";
            this.prestamosCanceladosToolStripMenuItem.Click += new System.EventHandler(this.prestamosCanceladosToolStripMenuItem_Click);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarPrestamosToolStripMenuItem1,
            this.eliminarPagosToolStripMenuItem1});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // eliminarPrestamosToolStripMenuItem1
            // 
            this.eliminarPrestamosToolStripMenuItem1.Name = "eliminarPrestamosToolStripMenuItem1";
            this.eliminarPrestamosToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.eliminarPrestamosToolStripMenuItem1.Text = "Eliminar prestamos";
            this.eliminarPrestamosToolStripMenuItem1.Click += new System.EventHandler(this.eliminarPrestamosToolStripMenuItem1_Click);
            // 
            // eliminarPagosToolStripMenuItem1
            // 
            this.eliminarPagosToolStripMenuItem1.Name = "eliminarPagosToolStripMenuItem1";
            this.eliminarPagosToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.eliminarPagosToolStripMenuItem1.Text = "Eliminar pagos";
            this.eliminarPagosToolStripMenuItem1.Click += new System.EventHandler(this.eliminarPagosToolStripMenuItem1_Click);
            // 
            // manejoUsuariosToolStripMenuItem
            // 
            this.manejoUsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manejoUsuariosToolStripMenuItem1});
            this.manejoUsuariosToolStripMenuItem.Name = "manejoUsuariosToolStripMenuItem";
            this.manejoUsuariosToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.manejoUsuariosToolStripMenuItem.Text = "Configuración";
            // 
            // manejoUsuariosToolStripMenuItem1
            // 
            this.manejoUsuariosToolStripMenuItem1.Name = "manejoUsuariosToolStripMenuItem1";
            this.manejoUsuariosToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.manejoUsuariosToolStripMenuItem1.Text = "Manejo Usuarios";
            this.manejoUsuariosToolStripMenuItem1.Click += new System.EventHandler(this.manejoUsuariosToolStripMenuItem1_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Prestamos.Properties.Resources._2017_07_28;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1128, 633);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmInicio";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Préstamos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearPrestamoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrarPagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarPagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientoDiarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarPrestamosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarPagosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem morososToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recaudosPorFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manejoUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manejoUsuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem prestamosCanceladosToolStripMenuItem;
    }
}