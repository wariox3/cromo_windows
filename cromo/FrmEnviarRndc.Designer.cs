namespace cromo
{
    partial class FrmEnviarRndc
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
            this.DgDespachos = new System.Windows.Forms.DataGridView();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.BtnDescartar = new System.Windows.Forms.Button();
            this.clmCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCodigoVehiculoFk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmConductor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgDespachos)).BeginInit();
            this.SuspendLayout();
            // 
            // DgDespachos
            // 
            this.DgDespachos.AllowUserToAddRows = false;
            this.DgDespachos.AllowUserToDeleteRows = false;
            this.DgDespachos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgDespachos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigoCliente,
            this.clmTipo,
            this.clmOperacion,
            this.clmNumero,
            this.clmFecha,
            this.clmCodigoVehiculoFk,
            this.clmOrigen,
            this.clmDestino,
            this.clmConductor});
            this.DgDespachos.Location = new System.Drawing.Point(12, 12);
            this.DgDespachos.MultiSelect = false;
            this.DgDespachos.Name = "DgDespachos";
            this.DgDespachos.ReadOnly = true;
            this.DgDespachos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgDespachos.Size = new System.Drawing.Size(911, 422);
            this.DgDespachos.StandardTab = true;
            this.DgDespachos.TabIndex = 2;
            this.DgDespachos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgDespachos_CellContentClick);
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Location = new System.Drawing.Point(809, 440);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(114, 23);
            this.BtnEnviar.TabIndex = 3;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // BtnDescartar
            // 
            this.BtnDescartar.Location = new System.Drawing.Point(12, 437);
            this.BtnDescartar.Name = "BtnDescartar";
            this.BtnDescartar.Size = new System.Drawing.Size(114, 23);
            this.BtnDescartar.TabIndex = 4;
            this.BtnDescartar.Text = "Descartar";
            this.BtnDescartar.UseVisualStyleBackColor = true;
            this.BtnDescartar.Click += new System.EventHandler(this.BtnDescartar_Click);
            // 
            // clmCodigoCliente
            // 
            this.clmCodigoCliente.DataPropertyName = "codigoDespachoPk";
            this.clmCodigoCliente.HeaderText = "ID";
            this.clmCodigoCliente.Name = "clmCodigoCliente";
            this.clmCodigoCliente.ReadOnly = true;
            this.clmCodigoCliente.Width = 50;
            // 
            // clmTipo
            // 
            this.clmTipo.DataPropertyName = "despachoTipo";
            this.clmTipo.HeaderText = "Tipo";
            this.clmTipo.Name = "clmTipo";
            this.clmTipo.ReadOnly = true;
            // 
            // clmOperacion
            // 
            this.clmOperacion.DataPropertyName = "codigoOperacionFk";
            this.clmOperacion.HeaderText = "OP";
            this.clmOperacion.Name = "clmOperacion";
            this.clmOperacion.ReadOnly = true;
            this.clmOperacion.Width = 50;
            // 
            // clmNumero
            // 
            this.clmNumero.DataPropertyName = "numero";
            this.clmNumero.HeaderText = "Numero";
            this.clmNumero.Name = "clmNumero";
            this.clmNumero.ReadOnly = true;
            this.clmNumero.Width = 70;
            // 
            // clmFecha
            // 
            this.clmFecha.DataPropertyName = "fechaSalida";
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.ReadOnly = true;
            // 
            // clmCodigoVehiculoFk
            // 
            this.clmCodigoVehiculoFk.DataPropertyName = "codigoVehiculoFk";
            this.clmCodigoVehiculoFk.HeaderText = "Placa";
            this.clmCodigoVehiculoFk.Name = "clmCodigoVehiculoFk";
            this.clmCodigoVehiculoFk.ReadOnly = true;
            this.clmCodigoVehiculoFk.Width = 50;
            // 
            // clmOrigen
            // 
            this.clmOrigen.DataPropertyName = "ciudadOrigen";
            this.clmOrigen.HeaderText = "Origen";
            this.clmOrigen.Name = "clmOrigen";
            this.clmOrigen.ReadOnly = true;
            // 
            // clmDestino
            // 
            this.clmDestino.DataPropertyName = "ciudadDestino";
            this.clmDestino.HeaderText = "Destino";
            this.clmDestino.Name = "clmDestino";
            this.clmDestino.ReadOnly = true;
            // 
            // clmConductor
            // 
            this.clmConductor.DataPropertyName = "conductorNombre";
            this.clmConductor.HeaderText = "Conductor";
            this.clmConductor.Name = "clmConductor";
            this.clmConductor.ReadOnly = true;
            this.clmConductor.Width = 200;
            // 
            // FrmEnviarRndc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 472);
            this.Controls.Add(this.BtnDescartar);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.DgDespachos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnviarRndc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar RNDC";
            this.Load += new System.EventHandler(this.FrmEnviarRndc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgDespachos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DgDespachos;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Button BtnDescartar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoVehiculoFk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConductor;
    }
}