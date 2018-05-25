namespace cromo
{
    partial class frmConfiguracion
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
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCentroOperacion = new System.Windows.Forms.TextBox();
			this.txtBaseDatos = new System.Windows.Forms.TextBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtServidor = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCodigoCiudadOrigen = new System.Windows.Forms.TextBox();
			this.txtPuerto = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(227, 227);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(140, 27);
			this.btnGuardar.TabIndex = 0;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(24, 227);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(154, 25);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(47, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Centro operaciones:";
			// 
			// txtCentroOperacion
			// 
			this.txtCentroOperacion.Location = new System.Drawing.Point(155, 25);
			this.txtCentroOperacion.Name = "txtCentroOperacion";
			this.txtCentroOperacion.Size = new System.Drawing.Size(145, 20);
			this.txtCentroOperacion.TabIndex = 0;
			// 
			// txtBaseDatos
			// 
			this.txtBaseDatos.Location = new System.Drawing.Point(155, 181);
			this.txtBaseDatos.Name = "txtBaseDatos";
			this.txtBaseDatos.Size = new System.Drawing.Size(145, 20);
			this.txtBaseDatos.TabIndex = 6;
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(155, 129);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(145, 20);
			this.txtClave.TabIndex = 4;
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(155, 103);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(145, 20);
			this.txtUsuario.TabIndex = 3;
			// 
			// txtServidor
			// 
			this.txtServidor.Location = new System.Drawing.Point(155, 77);
			this.txtServidor.Name = "txtServidor";
			this.txtServidor.Size = new System.Drawing.Size(145, 20);
			this.txtServidor.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(86, 181);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Base datos:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(112, 132);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Clave:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(103, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Usuario:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(100, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Servidor:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(72, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Ciudad Origen:";
			// 
			// txtCodigoCiudadOrigen
			// 
			this.txtCodigoCiudadOrigen.Location = new System.Drawing.Point(155, 51);
			this.txtCodigoCiudadOrigen.Name = "txtCodigoCiudadOrigen";
			this.txtCodigoCiudadOrigen.Size = new System.Drawing.Size(145, 20);
			this.txtCodigoCiudadOrigen.TabIndex = 1;
			// 
			// txtPuerto
			// 
			this.txtPuerto.Location = new System.Drawing.Point(155, 155);
			this.txtPuerto.Name = "txtPuerto";
			this.txtPuerto.Size = new System.Drawing.Size(145, 20);
			this.txtPuerto.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(108, 158);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Puerto:";
			// 
			// frmConfiguracion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 266);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtPuerto);
			this.Controls.Add(this.txtCodigoCiudadOrigen);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtServidor);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.txtClave);
			this.Controls.Add(this.txtBaseDatos);
			this.Controls.Add(this.txtCentroOperacion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGuardar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConfiguracion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuracion";
			this.Load += new System.EventHandler(this.frmConfiguracion_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCentroOperacion;
		private System.Windows.Forms.TextBox txtBaseDatos;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.TextBox txtServidor;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCodigoCiudadOrigen;
		private System.Windows.Forms.TextBox txtPuerto;
		private System.Windows.Forms.Label label7;
	}
}