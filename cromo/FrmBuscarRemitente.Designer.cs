namespace cromo
{
    partial class FrmBuscarRemitente
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
            this.DgRemitentes = new System.Windows.Forms.DataGridView();
            this.ClmCodigoDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNumeroIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCodigoAsesorFk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSeleccionar = new System.Windows.Forms.Button();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgRemitentes)).BeginInit();
            this.SuspendLayout();
            // 
            // DgRemitentes
            // 
            this.DgRemitentes.AllowUserToAddRows = false;
            this.DgRemitentes.AllowUserToDeleteRows = false;
            this.DgRemitentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgRemitentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmCodigoDestinatario,
            this.ClmNumeroIdentificacion,
            this.ClmNombre,
            this.ClmCiudad,
            this.Direccion,
            this.ClmCodigoAsesorFk});
            this.DgRemitentes.Location = new System.Drawing.Point(17, 49);
            this.DgRemitentes.Name = "DgRemitentes";
            this.DgRemitentes.ReadOnly = true;
            this.DgRemitentes.Size = new System.Drawing.Size(828, 279);
            this.DgRemitentes.TabIndex = 1;
            this.DgRemitentes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgRemitentes_KeyDown);
            // 
            // ClmCodigoDestinatario
            // 
            this.ClmCodigoDestinatario.DataPropertyName = "codigoRemitentePk";
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
            this.Direccion.Width = 200;
            // 
            // ClmCodigoAsesorFk
            // 
            this.ClmCodigoAsesorFk.DataPropertyName = "codigoAsesorFk";
            this.ClmCodigoAsesorFk.HeaderText = "A";
            this.ClmCodigoAsesorFk.Name = "ClmCodigoAsesorFk";
            this.ClmCodigoAsesorFk.ReadOnly = true;
            this.ClmCodigoAsesorFk.Width = 50;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(17, 334);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(106, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Location = new System.Drawing.Point(739, 334);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(106, 23);
            this.BtnSeleccionar.TabIndex = 2;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
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
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre:";
            // 
            // FrmBuscarRemitente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 363);
            this.ControlBox = false;
            this.Controls.Add(this.DgRemitentes);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmBuscarRemitente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar remitente";
            this.Load += new System.EventHandler(this.FrmBuscarRemitente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgRemitentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgRemitentes;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnSeleccionar;
        private System.Windows.Forms.Button BtnFiltrar;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNumeroIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCodigoAsesorFk;
    }
}