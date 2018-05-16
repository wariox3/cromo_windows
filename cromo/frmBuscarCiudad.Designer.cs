namespace cromo
{
    partial class frmBuscarCiudad
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
			this.dgCiudades = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSeleccionar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFiltrar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgCiudades)).BeginInit();
			this.SuspendLayout();
			// 
			// dgCiudades
			// 
			this.dgCiudades.AllowUserToAddRows = false;
			this.dgCiudades.AllowUserToDeleteRows = false;
			this.dgCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgCiudades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre});
			this.dgCiudades.Location = new System.Drawing.Point(44, 45);
			this.dgCiudades.MultiSelect = false;
			this.dgCiudades.Name = "dgCiudades";
			this.dgCiudades.ReadOnly = true;
			this.dgCiudades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgCiudades.Size = new System.Drawing.Size(712, 325);
			this.dgCiudades.StandardTab = true;
			this.dgCiudades.TabIndex = 1;
			this.dgCiudades.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgCiudades_KeyDown);
			// 
			// ID
			// 
			this.ID.DataPropertyName = "codigo_ciudad_pk";
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			// 
			// Nombre
			// 
			this.Nombre.DataPropertyName = "nombre";
			this.Nombre.HeaderText = "Nombre";
			this.Nombre.Name = "Nombre";
			this.Nombre.ReadOnly = true;
			this.Nombre.Width = 300;
			// 
			// btnSeleccionar
			// 
			this.btnSeleccionar.Location = new System.Drawing.Point(650, 379);
			this.btnSeleccionar.Name = "btnSeleccionar";
			this.btnSeleccionar.Size = new System.Drawing.Size(106, 23);
			this.btnSeleccionar.TabIndex = 2;
			this.btnSeleccionar.Text = "Seleccionar";
			this.btnSeleccionar.UseVisualStyleBackColor = true;
			this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(44, 376);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(106, 23);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(94, 12);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(262, 20);
			this.txtNombre.TabIndex = 0;
			this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
			this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(41, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Nombre:";
			// 
			// btnFiltrar
			// 
			this.btnFiltrar.Location = new System.Drawing.Point(367, 12);
			this.btnFiltrar.Name = "btnFiltrar";
			this.btnFiltrar.Size = new System.Drawing.Size(76, 20);
			this.btnFiltrar.TabIndex = 6;
			this.btnFiltrar.Text = "Filtrar";
			this.btnFiltrar.UseVisualStyleBackColor = true;
			this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
			// 
			// frmBuscarCiudad
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(800, 414);
			this.Controls.Add(this.btnFiltrar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.dgCiudades);
			this.Controls.Add(this.btnSeleccionar);
			this.Controls.Add(this.btnCancelar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBuscarCiudad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscar ciudad";
			this.Load += new System.EventHandler(this.frmBuscarCiudad_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgCiudades)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgCiudades;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
		private System.Windows.Forms.Button btnSeleccionar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFiltrar;
	}
}