namespace cromo
{
    partial class FrmConfiguracion
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
			this.tabConfiguracion = new System.Windows.Forms.TabControl();
			this.tbpOperacion = new System.Windows.Forms.TabPage();
			this.txtCodigoCiudadOrigen = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCentroOperacion = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbpBaseDatos = new System.Windows.Forms.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDriver = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtPuerto = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtServidor = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.txtBaseDatos = new System.Windows.Forms.TextBox();
			this.tbpRutas = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.txtRutaReportes = new System.Windows.Forms.TextBox();
			this.tabConfiguracion.SuspendLayout();
			this.tbpOperacion.SuspendLayout();
			this.tbpBaseDatos.SuspendLayout();
			this.tbpRutas.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(228, 278);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(140, 27);
			this.btnGuardar.TabIndex = 8;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(24, 278);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(154, 25);
			this.btnCancelar.TabIndex = 9;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// tabConfiguracion
			// 
			this.tabConfiguracion.Controls.Add(this.tbpOperacion);
			this.tabConfiguracion.Controls.Add(this.tbpBaseDatos);
			this.tabConfiguracion.Controls.Add(this.tbpRutas);
			this.tabConfiguracion.Location = new System.Drawing.Point(24, 12);
			this.tabConfiguracion.Name = "tabConfiguracion";
			this.tabConfiguracion.SelectedIndex = 0;
			this.tabConfiguracion.Size = new System.Drawing.Size(348, 260);
			this.tabConfiguracion.TabIndex = 18;
			// 
			// tbpOperacion
			// 
			this.tbpOperacion.Controls.Add(this.txtCodigoCiudadOrigen);
			this.tbpOperacion.Controls.Add(this.label6);
			this.tbpOperacion.Controls.Add(this.txtCentroOperacion);
			this.tbpOperacion.Controls.Add(this.label1);
			this.tbpOperacion.Location = new System.Drawing.Point(4, 22);
			this.tbpOperacion.Name = "tbpOperacion";
			this.tbpOperacion.Padding = new System.Windows.Forms.Padding(3);
			this.tbpOperacion.Size = new System.Drawing.Size(340, 234);
			this.tbpOperacion.TabIndex = 0;
			this.tbpOperacion.Text = "Operacion";
			this.tbpOperacion.UseVisualStyleBackColor = true;
			// 
			// txtCodigoCiudadOrigen
			// 
			this.txtCodigoCiudadOrigen.Location = new System.Drawing.Point(147, 41);
			this.txtCodigoCiudadOrigen.Name = "txtCodigoCiudadOrigen";
			this.txtCodigoCiudadOrigen.Size = new System.Drawing.Size(145, 20);
			this.txtCodigoCiudadOrigen.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(64, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Ciudad Origen:";
			// 
			// txtCentroOperacion
			// 
			this.txtCentroOperacion.Location = new System.Drawing.Point(147, 15);
			this.txtCentroOperacion.Name = "txtCentroOperacion";
			this.txtCentroOperacion.Size = new System.Drawing.Size(145, 20);
			this.txtCentroOperacion.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Centro operaciones:";
			// 
			// tbpBaseDatos
			// 
			this.tbpBaseDatos.Controls.Add(this.label8);
			this.tbpBaseDatos.Controls.Add(this.txtDriver);
			this.tbpBaseDatos.Controls.Add(this.label7);
			this.tbpBaseDatos.Controls.Add(this.txtPuerto);
			this.tbpBaseDatos.Controls.Add(this.label5);
			this.tbpBaseDatos.Controls.Add(this.label4);
			this.tbpBaseDatos.Controls.Add(this.label3);
			this.tbpBaseDatos.Controls.Add(this.label2);
			this.tbpBaseDatos.Controls.Add(this.txtServidor);
			this.tbpBaseDatos.Controls.Add(this.txtUsuario);
			this.tbpBaseDatos.Controls.Add(this.txtClave);
			this.tbpBaseDatos.Controls.Add(this.txtBaseDatos);
			this.tbpBaseDatos.Location = new System.Drawing.Point(4, 22);
			this.tbpBaseDatos.Name = "tbpBaseDatos";
			this.tbpBaseDatos.Padding = new System.Windows.Forms.Padding(3);
			this.tbpBaseDatos.Size = new System.Drawing.Size(340, 234);
			this.tbpBaseDatos.TabIndex = 1;
			this.tbpBaseDatos.Text = "Base datos";
			this.tbpBaseDatos.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(57, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 29;
			this.label8.Text = "Driver:";
			// 
			// txtDriver
			// 
			this.txtDriver.Location = new System.Drawing.Point(104, 17);
			this.txtDriver.Name = "txtDriver";
			this.txtDriver.Size = new System.Drawing.Size(228, 20);
			this.txtDriver.TabIndex = 18;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(57, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 28;
			this.label7.Text = "Puerto:";
			// 
			// txtPuerto
			// 
			this.txtPuerto.Location = new System.Drawing.Point(104, 119);
			this.txtPuerto.Name = "txtPuerto";
			this.txtPuerto.Size = new System.Drawing.Size(145, 20);
			this.txtPuerto.TabIndex = 22;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(49, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "Servidor:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(52, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "Usuario:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(61, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 25;
			this.label3.Text = "Clave:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Base datos:";
			// 
			// txtServidor
			// 
			this.txtServidor.Location = new System.Drawing.Point(104, 41);
			this.txtServidor.Name = "txtServidor";
			this.txtServidor.Size = new System.Drawing.Size(145, 20);
			this.txtServidor.TabIndex = 19;
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(104, 67);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(145, 20);
			this.txtUsuario.TabIndex = 20;
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(104, 93);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(145, 20);
			this.txtClave.TabIndex = 21;
			// 
			// txtBaseDatos
			// 
			this.txtBaseDatos.Location = new System.Drawing.Point(104, 145);
			this.txtBaseDatos.Name = "txtBaseDatos";
			this.txtBaseDatos.Size = new System.Drawing.Size(145, 20);
			this.txtBaseDatos.TabIndex = 23;
			// 
			// tbpRutas
			// 
			this.tbpRutas.Controls.Add(this.txtRutaReportes);
			this.tbpRutas.Controls.Add(this.label9);
			this.tbpRutas.Location = new System.Drawing.Point(4, 22);
			this.tbpRutas.Name = "tbpRutas";
			this.tbpRutas.Size = new System.Drawing.Size(340, 234);
			this.tbpRutas.TabIndex = 2;
			this.tbpRutas.Text = "Rutas";
			this.tbpRutas.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(17, 17);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "Reportes:";
			this.label9.Click += new System.EventHandler(this.label9_Click);
			// 
			// txtRutaReportes
			// 
			this.txtRutaReportes.Location = new System.Drawing.Point(74, 18);
			this.txtRutaReportes.Name = "txtRutaReportes";
			this.txtRutaReportes.Size = new System.Drawing.Size(249, 20);
			this.txtRutaReportes.TabIndex = 1;
			// 
			// frmConfiguracion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 315);
			this.Controls.Add(this.tabConfiguracion);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGuardar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConfiguracion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuracion";
			this.Load += new System.EventHandler(this.frmConfiguracion_Load);
			this.tabConfiguracion.ResumeLayout(false);
			this.tbpOperacion.ResumeLayout(false);
			this.tbpOperacion.PerformLayout();
			this.tbpBaseDatos.ResumeLayout(false);
			this.tbpBaseDatos.PerformLayout();
			this.tbpRutas.ResumeLayout(false);
			this.tbpRutas.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TabControl tabConfiguracion;
		private System.Windows.Forms.TabPage tbpOperacion;
		private System.Windows.Forms.TextBox txtCodigoCiudadOrigen;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCentroOperacion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tbpBaseDatos;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDriver;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtPuerto;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtServidor;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.TextBox txtBaseDatos;
		private System.Windows.Forms.TabPage tbpRutas;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtRutaReportes;
	}
}