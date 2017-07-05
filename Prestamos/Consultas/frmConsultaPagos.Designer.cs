namespace Prestamos.Consultas
{
    partial class frmConsultaPagos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtSaldoPendiente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAbonos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.idpago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Couta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pagada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbNoPrestamo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.txtSaldoPendiente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTotalAbonos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtValorTotal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbNoPrestamo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(296, 47);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Estado prestamo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(296, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(324, 20);
            this.txtNombre.TabIndex = 14;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(520, 75);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 23);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "Nueva consulta";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtSaldoPendiente
            // 
            this.txtSaldoPendiente.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldoPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoPendiente.ForeColor = System.Drawing.Color.Red;
            this.txtSaldoPendiente.Location = new System.Drawing.Point(98, 72);
            this.txtSaldoPendiente.Name = "txtSaldoPendiente";
            this.txtSaldoPendiente.ReadOnly = true;
            this.txtSaldoPendiente.Size = new System.Drawing.Size(100, 20);
            this.txtSaldoPendiente.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Saldo por Pagar:";
            // 
            // txtTotalAbonos
            // 
            this.txtTotalAbonos.Location = new System.Drawing.Point(520, 47);
            this.txtTotalAbonos.Name = "txtTotalAbonos";
            this.txtTotalAbonos.ReadOnly = true;
            this.txtTotalAbonos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAbonos.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Abonos Pagados:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(296, 72);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(121, 20);
            this.txtValorTotal.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total Prestamo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgDatos);
            this.groupBox2.Location = new System.Drawing.Point(7, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 244);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.AllowUserToDeleteRows = false;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpago,
            this.Couta,
            this.ValorPago,
            this.Saldo,
            this.fechapago,
            this.FechaReal,
            this.Pagada});
            this.dtgDatos.Location = new System.Drawing.Point(7, 20);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.ReadOnly = true;
            this.dtgDatos.Size = new System.Drawing.Size(595, 218);
            this.dtgDatos.TabIndex = 0;
            // 
            // idpago
            // 
            this.idpago.DataPropertyName = "idpago";
            this.idpago.HeaderText = "Pago ID";
            this.idpago.Name = "idpago";
            this.idpago.ReadOnly = true;
            this.idpago.Visible = false;
            // 
            // Couta
            // 
            this.Couta.DataPropertyName = "cuota";
            this.Couta.HeaderText = "Cuota";
            this.Couta.Name = "Couta";
            this.Couta.ReadOnly = true;
            this.Couta.Width = 50;
            // 
            // ValorPago
            // 
            this.ValorPago.DataPropertyName = "valorpago";
            dataGridViewCellStyle3.Format = "string.Format(\"N\")";
            this.ValorPago.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValorPago.HeaderText = "ValorPago";
            this.ValorPago.Name = "ValorPago";
            this.ValorPago.ReadOnly = true;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "saldo";
            dataGridViewCellStyle4.Format = "0.00##";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // fechapago
            // 
            this.fechapago.DataPropertyName = "FechaPago";
            this.fechapago.HeaderText = "Fecha Pago";
            this.fechapago.Name = "fechapago";
            this.fechapago.ReadOnly = true;
            // 
            // FechaReal
            // 
            this.FechaReal.DataPropertyName = "FechaPagoReal";
            this.FechaReal.HeaderText = "Fecha Pago Real";
            this.FechaReal.Name = "FechaReal";
            this.FechaReal.ReadOnly = true;
            this.FechaReal.Width = 150;
            // 
            // Pagada
            // 
            this.Pagada.DataPropertyName = "pagado";
            this.Pagada.HeaderText = "Pagada";
            this.Pagada.Name = "Pagada";
            this.Pagada.ReadOnly = true;
            this.Pagada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pagada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Pagada.Width = 50;
            // 
            // cbNoPrestamo
            // 
            this.cbNoPrestamo.DisplayMember = "NoPrestamo";
            this.cbNoPrestamo.FormattingEnabled = true;
            this.cbNoPrestamo.Location = new System.Drawing.Point(98, 45);
            this.cbNoPrestamo.Name = "cbNoPrestamo";
            this.cbNoPrestamo.Size = new System.Drawing.Size(100, 21);
            this.cbNoPrestamo.TabIndex = 3;
            this.cbNoPrestamo.ValueMember = "NoPrestamo";
            this.cbNoPrestamo.SelectedValueChanged += new System.EventHandler(this.cbNoPrestamo_SelectedValueChanged);
            this.cbNoPrestamo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbNoPrestamo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "No prestamo:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(98, 20);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Documento:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consulta pagos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConsultaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsultaPagos";
            this.Text = "Consulta Pagos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbNoPrestamo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalAbonos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaldoPendiente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Couta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaReal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pagada;
    }
}