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
            this.txtCentroOperacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpRutas = new System.Windows.Forms.TabPage();
            this.txtRutaReportes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRutaServidorManual = new System.Windows.Forms.TextBox();
            this.ChkServidorManual = new System.Windows.Forms.CheckBox();
            this.ChkBloquearFlete = new System.Windows.Forms.CheckBox();
            this.ChkBloquearManejo = new System.Windows.Forms.CheckBox();
            this.tabConfiguracion.SuspendLayout();
            this.tbpOperacion.SuspendLayout();
            this.tbpRutas.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabConfiguracion.Controls.Add(this.tbpRutas);
            this.tabConfiguracion.Controls.Add(this.tabPage1);
            this.tabConfiguracion.Location = new System.Drawing.Point(24, 12);
            this.tabConfiguracion.Name = "tabConfiguracion";
            this.tabConfiguracion.SelectedIndex = 0;
            this.tabConfiguracion.Size = new System.Drawing.Size(348, 260);
            this.tabConfiguracion.TabIndex = 18;
            // 
            // tbpOperacion
            // 
            this.tbpOperacion.Controls.Add(this.ChkBloquearManejo);
            this.tbpOperacion.Controls.Add(this.ChkBloquearFlete);
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
            this.label1.Location = new System.Drawing.Point(80, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Operacion:";
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
            // txtRutaReportes
            // 
            this.txtRutaReportes.Location = new System.Drawing.Point(74, 18);
            this.txtRutaReportes.Name = "txtRutaReportes";
            this.txtRutaReportes.Size = new System.Drawing.Size(249, 20);
            this.txtRutaReportes.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Reportes:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TxtRutaServidorManual);
            this.tabPage1.Controls.Add(this.ChkServidorManual);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(340, 234);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Servidor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Servidor:";
            // 
            // TxtRutaServidorManual
            // 
            this.TxtRutaServidorManual.Location = new System.Drawing.Point(75, 43);
            this.TxtRutaServidorManual.Name = "TxtRutaServidorManual";
            this.TxtRutaServidorManual.Size = new System.Drawing.Size(259, 20);
            this.TxtRutaServidorManual.TabIndex = 1;
            // 
            // ChkServidorManual
            // 
            this.ChkServidorManual.AutoSize = true;
            this.ChkServidorManual.Location = new System.Drawing.Point(75, 20);
            this.ChkServidorManual.Name = "ChkServidorManual";
            this.ChkServidorManual.Size = new System.Drawing.Size(61, 17);
            this.ChkServidorManual.TabIndex = 0;
            this.ChkServidorManual.Text = "Manual";
            this.ChkServidorManual.UseVisualStyleBackColor = true;
            // 
            // ChkBloquearFlete
            // 
            this.ChkBloquearFlete.AutoSize = true;
            this.ChkBloquearFlete.Location = new System.Drawing.Point(147, 41);
            this.ChkBloquearFlete.Name = "ChkBloquearFlete";
            this.ChkBloquearFlete.Size = new System.Drawing.Size(91, 17);
            this.ChkBloquearFlete.TabIndex = 16;
            this.ChkBloquearFlete.Text = "Bloquear flete";
            this.ChkBloquearFlete.UseVisualStyleBackColor = true;
            // 
            // ChkBloquearManejo
            // 
            this.ChkBloquearManejo.AutoSize = true;
            this.ChkBloquearManejo.Location = new System.Drawing.Point(147, 64);
            this.ChkBloquearManejo.Name = "ChkBloquearManejo";
            this.ChkBloquearManejo.Size = new System.Drawing.Size(105, 17);
            this.ChkBloquearManejo.TabIndex = 17;
            this.ChkBloquearManejo.Text = "Bloquear manejo";
            this.ChkBloquearManejo.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 315);
            this.Controls.Add(this.tabConfiguracion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.tabConfiguracion.ResumeLayout(false);
            this.tbpOperacion.ResumeLayout(false);
            this.tbpOperacion.PerformLayout();
            this.tbpRutas.ResumeLayout(false);
            this.tbpRutas.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TabControl tabConfiguracion;
		private System.Windows.Forms.TabPage tbpOperacion;
		private System.Windows.Forms.TextBox txtCentroOperacion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tbpRutas;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtRutaReportes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRutaServidorManual;
        private System.Windows.Forms.CheckBox ChkServidorManual;
        private System.Windows.Forms.CheckBox ChkBloquearManejo;
        private System.Windows.Forms.CheckBox ChkBloquearFlete;
    }
}