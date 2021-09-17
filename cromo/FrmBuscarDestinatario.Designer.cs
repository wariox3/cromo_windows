namespace cromo
{
	partial class FrmBuscarDestinatario
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
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.DgDestinatarios = new System.Windows.Forms.DataGridView();
            this.ClmCodigoDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNumeroIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.ChkTodosClientes = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgDestinatarios)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Location = new System.Drawing.Point(373, 12);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(84, 20);
            this.BtnFiltrar.TabIndex = 4;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(67, 12);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(294, 20);
            this.TxtNombre.TabIndex = 0;
            this.TxtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNombre_KeyDown);
            this.TxtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(17, 451);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(106, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Location = new System.Drawing.Point(739, 451);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(106, 23);
            this.BtnSeleccionar.TabIndex = 2;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // DgDestinatarios
            // 
            this.DgDestinatarios.AllowUserToAddRows = false;
            this.DgDestinatarios.AllowUserToDeleteRows = false;
            this.DgDestinatarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgDestinatarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmCodigoDestinatario,
            this.ClmNumeroIdentificacion,
            this.ClmNombre,
            this.ClmCiudad,
            this.Direccion});
            this.DgDestinatarios.Location = new System.Drawing.Point(17, 49);
            this.DgDestinatarios.Name = "DgDestinatarios";
            this.DgDestinatarios.ReadOnly = true;
            this.DgDestinatarios.Size = new System.Drawing.Size(828, 396);
            this.DgDestinatarios.TabIndex = 1;
            this.DgDestinatarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgDestinatarios_KeyDown);
            // 
            // ClmCodigoDestinatario
            // 
            this.ClmCodigoDestinatario.DataPropertyName = "codigoDestinatarioPk";
            this.ClmCodigoDestinatario.HeaderText = "ID";
            this.ClmCodigoDestinatario.Name = "ClmCodigoDestinatario";
            this.ClmCodigoDestinatario.ReadOnly = true;
            this.ClmCodigoDestinatario.Width = 50;
            // 
            // ClmNumeroIdentificacion
            // 
            this.ClmNumeroIdentificacion.DataPropertyName = "numeroIdentificacion";
            this.ClmNumeroIdentificacion.HeaderText = "Identificacion";
            this.ClmNumeroIdentificacion.Name = "ClmNumeroIdentificacion";
            this.ClmNumeroIdentificacion.ReadOnly = true;
            this.ClmNumeroIdentificacion.Width = 80;
            // 
            // ClmNombre
            // 
            this.ClmNombre.DataPropertyName = "nombreCorto";
            this.ClmNombre.HeaderText = "Nombre";
            this.ClmNombre.Name = "ClmNombre";
            this.ClmNombre.ReadOnly = true;
            this.ClmNombre.Width = 250;
            // 
            // ClmCiudad
            // 
            this.ClmCiudad.DataPropertyName = "ciudadNombre";
            this.ClmCiudad.HeaderText = "Ciudad";
            this.ClmCiudad.Name = "ClmCiudad";
            this.ClmCiudad.ReadOnly = true;
            this.ClmCiudad.Width = 150;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "direccion";
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 230;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(627, 451);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(106, 23);
            this.BtnNuevo.TabIndex = 9;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // ChkTodosClientes
            // 
            this.ChkTodosClientes.AutoSize = true;
            this.ChkTodosClientes.Location = new System.Drawing.Point(734, 12);
            this.ChkTodosClientes.Name = "ChkTodosClientes";
            this.ChkTodosClientes.Size = new System.Drawing.Size(111, 17);
            this.ChkTodosClientes.TabIndex = 10;
            this.ChkTodosClientes.Text = "Todos los clientes";
            this.ChkTodosClientes.UseVisualStyleBackColor = true;
            this.ChkTodosClientes.CheckedChanged += new System.EventHandler(this.ChkTodosClientes_CheckedChanged);
            // 
            // FrmBuscarDestinatario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 486);
            this.ControlBox = false;
            this.Controls.Add(this.ChkTodosClientes);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.DgDestinatarios);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuscarDestinatario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar destinatario";
            this.Load += new System.EventHandler(this.FrmBuscarDestinatario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgDestinatarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button BtnFiltrar;
		private System.Windows.Forms.TextBox TxtNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Button BtnSeleccionar;
		private System.Windows.Forms.DataGridView DgDestinatarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNumeroIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.CheckBox ChkTodosClientes;
    }
}