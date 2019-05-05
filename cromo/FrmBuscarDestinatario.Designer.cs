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
            ((System.ComponentModel.ISupportInitialize)(this.DgDestinatarios)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Location = new System.Drawing.Point(373, 12);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(84, 20);
            this.BtnFiltrar.TabIndex = 9;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(67, 12);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(294, 20);
            this.TxtNombre.TabIndex = 7;
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
            this.BtnCancelar.Location = new System.Drawing.Point(16, 345);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(106, 23);
            this.BtnCancelar.TabIndex = 11;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Location = new System.Drawing.Point(622, 345);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(106, 23);
            this.BtnSeleccionar.TabIndex = 10;
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
            this.ClmCiudad});
            this.DgDestinatarios.Location = new System.Drawing.Point(17, 49);
            this.DgDestinatarios.Name = "DgDestinatarios";
            this.DgDestinatarios.ReadOnly = true;
            this.DgDestinatarios.Size = new System.Drawing.Size(693, 279);
            this.DgDestinatarios.TabIndex = 12;
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
            this.ClmNombre.Width = 300;
            // 
            // ClmCiudad
            // 
            this.ClmCiudad.DataPropertyName = "ciudadNombre";
            this.ClmCiudad.HeaderText = "Ciudad";
            this.ClmCiudad.Name = "ClmCiudad";
            this.ClmCiudad.ReadOnly = true;
            this.ClmCiudad.Width = 150;
            // 
            // FrmBuscarDestinatario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 379);
            this.Controls.Add(this.DgDestinatarios);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuscarDestinatario";
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
    }
}