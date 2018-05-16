namespace cromo
{
    partial class frmBuscarCliente
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
			this.dgClientes = new System.Windows.Forms.DataGridView();
			this.clmCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnSeleccionar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.btnFiltrar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
			this.SuspendLayout();
			// 
			// dgClientes
			// 
			this.dgClientes.AllowUserToAddRows = false;
			this.dgClientes.AllowUserToDeleteRows = false;
			this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigoCliente,
            this.clmNombre});
			this.dgClientes.Location = new System.Drawing.Point(12, 36);
			this.dgClientes.MultiSelect = false;
			this.dgClientes.Name = "dgClientes";
			this.dgClientes.ReadOnly = true;
			this.dgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgClientes.Size = new System.Drawing.Size(712, 301);
			this.dgClientes.StandardTab = true;
			this.dgClientes.TabIndex = 1;
			this.dgClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgClientes_KeyDown);
			// 
			// clmCodigoCliente
			// 
			this.clmCodigoCliente.DataPropertyName = "codigo_cliente_pk";
			this.clmCodigoCliente.HeaderText = "ID";
			this.clmCodigoCliente.Name = "clmCodigoCliente";
			this.clmCodigoCliente.ReadOnly = true;
			this.clmCodigoCliente.Width = 50;
			// 
			// clmNombre
			// 
			this.clmNombre.DataPropertyName = "nombre_corto";
			this.clmNombre.HeaderText = "Nombre";
			this.clmNombre.Name = "clmNombre";
			this.clmNombre.ReadOnly = true;
			this.clmNombre.Width = 400;
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(12, 343);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(106, 23);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnSeleccionar
			// 
			this.btnSeleccionar.Location = new System.Drawing.Point(618, 343);
			this.btnSeleccionar.Name = "btnSeleccionar";
			this.btnSeleccionar.Size = new System.Drawing.Size(106, 23);
			this.btnSeleccionar.TabIndex = 2;
			this.btnSeleccionar.Text = "Seleccionar";
			this.btnSeleccionar.UseVisualStyleBackColor = true;
			this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
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
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(65, 9);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(294, 20);
			this.txtNombre.TabIndex = 0;
			this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
			this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
			// 
			// btnFiltrar
			// 
			this.btnFiltrar.Location = new System.Drawing.Point(371, 9);
			this.btnFiltrar.Name = "btnFiltrar";
			this.btnFiltrar.Size = new System.Drawing.Size(84, 20);
			this.btnFiltrar.TabIndex = 6;
			this.btnFiltrar.Text = "Filtrar";
			this.btnFiltrar.UseVisualStyleBackColor = true;
			this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
			// 
			// frmBuscarCliente
			// 
			this.ClientSize = new System.Drawing.Size(736, 383);
			this.Controls.Add(this.btnFiltrar);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnSeleccionar);
			this.Controls.Add(this.dgClientes);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBuscarCliente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscar cliente";
			this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgClientes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
		private System.Windows.Forms.Button btnSeleccionar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Button btnFiltrar;
	}
}