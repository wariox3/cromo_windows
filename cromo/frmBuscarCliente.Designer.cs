namespace cromo
{
    partial class FrmBuscarCliente
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
            this.DgClientes = new System.Windows.Forms.DataGridView();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.clmCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // DgClientes
            // 
            this.DgClientes.AllowUserToAddRows = false;
            this.DgClientes.AllowUserToDeleteRows = false;
            this.DgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigoCliente,
            this.clmNombre});
            this.DgClientes.Location = new System.Drawing.Point(12, 36);
            this.DgClientes.MultiSelect = false;
            this.DgClientes.Name = "DgClientes";
            this.DgClientes.ReadOnly = true;
            this.DgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgClientes.Size = new System.Drawing.Size(712, 301);
            this.DgClientes.StandardTab = true;
            this.DgClientes.TabIndex = 1;
            this.DgClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgClientes_KeyDown);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(12, 343);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(106, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Location = new System.Drawing.Point(618, 343);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(106, 23);
            this.BtnSeleccionar.TabIndex = 2;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(65, 9);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(294, 20);
            this.TxtNombre.TabIndex = 0;
            this.TxtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNombre_KeyDown);
            this.TxtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Location = new System.Drawing.Point(371, 9);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(84, 20);
            this.BtnFiltrar.TabIndex = 6;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // clmCodigoCliente
            // 
            this.clmCodigoCliente.DataPropertyName = "codigoTerceroPk";
            this.clmCodigoCliente.HeaderText = "ID";
            this.clmCodigoCliente.Name = "clmCodigoCliente";
            this.clmCodigoCliente.ReadOnly = true;
            this.clmCodigoCliente.Width = 50;
            // 
            // clmNombre
            // 
            this.clmNombre.DataPropertyName = "nombreCorto";
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            this.clmNombre.Width = 400;
            // 
            // FrmBuscarCliente
            // 
            this.ClientSize = new System.Drawing.Size(736, 383);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.DgClientes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar cliente";
            this.Load += new System.EventHandler(this.FrmBuscarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView DgClientes;
        private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Button BtnSeleccionar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxtNombre;
		private System.Windows.Forms.Button BtnFiltrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
    }
}