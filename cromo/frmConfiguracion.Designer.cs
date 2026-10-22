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
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.ChkGuiaRecogida = new System.Windows.Forms.CheckBox();
            this.ChkGuiaIngreso = new System.Windows.Forms.CheckBox();
            this.tbpOperacion = new System.Windows.Forms.TabPage();
            this.ChkValidarProductoCliente = new System.Windows.Forms.CheckBox();
            this.ChkBloquearManejo = new System.Windows.Forms.CheckBox();
            this.ChkBloquearFlete = new System.Windows.Forms.CheckBox();
            this.txtCentroOperacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOperador = new System.Windows.Forms.TabPage();
            this.ChkOperadorLogistico = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCodigoCliente = new System.Windows.Forms.TextBox();
            this.ChkValidarProductoLista = new System.Windows.Forms.CheckBox();
            this.tabConfiguracion.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.tbpOperacion.SuspendLayout();
            this.tabOperador.SuspendLayout();
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
            this.tabConfiguracion.Controls.Add(this.tbpGeneral);
            this.tabConfiguracion.Controls.Add(this.tbpOperacion);
            this.tabConfiguracion.Controls.Add(this.tabOperador);
            this.tabConfiguracion.Location = new System.Drawing.Point(24, 12);
            this.tabConfiguracion.Name = "tabConfiguracion";
            this.tabConfiguracion.SelectedIndex = 0;
            this.tabConfiguracion.Size = new System.Drawing.Size(348, 260);
            this.tabConfiguracion.TabIndex = 18;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.ChkGuiaRecogida);
            this.tbpGeneral.Controls.Add(this.ChkGuiaIngreso);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(340, 234);
            this.tbpGeneral.TabIndex = 5;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // ChkGuiaRecogida
            // 
            this.ChkGuiaRecogida.AutoSize = true;
            this.ChkGuiaRecogida.Location = new System.Drawing.Point(117, 45);
            this.ChkGuiaRecogida.Name = "ChkGuiaRecogida";
            this.ChkGuiaRecogida.Size = new System.Drawing.Size(92, 17);
            this.ChkGuiaRecogida.TabIndex = 18;
            this.ChkGuiaRecogida.Text = "Guia recogida";
            this.ChkGuiaRecogida.UseVisualStyleBackColor = true;
            // 
            // ChkGuiaIngreso
            // 
            this.ChkGuiaIngreso.AutoSize = true;
            this.ChkGuiaIngreso.Location = new System.Drawing.Point(117, 22);
            this.ChkGuiaIngreso.Name = "ChkGuiaIngreso";
            this.ChkGuiaIngreso.Size = new System.Drawing.Size(85, 17);
            this.ChkGuiaIngreso.TabIndex = 17;
            this.ChkGuiaIngreso.Text = "Guia ingreso";
            this.ChkGuiaIngreso.UseVisualStyleBackColor = true;
            // 
            // tbpOperacion
            // 
            this.tbpOperacion.Controls.Add(this.ChkValidarProductoLista);
            this.tbpOperacion.Controls.Add(this.ChkValidarProductoCliente);
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
            // ChkValidarProductoCliente
            // 
            this.ChkValidarProductoCliente.AutoSize = true;
            this.ChkValidarProductoCliente.Location = new System.Drawing.Point(147, 87);
            this.ChkValidarProductoCliente.Name = "ChkValidarProductoCliente";
            this.ChkValidarProductoCliente.Size = new System.Drawing.Size(137, 17);
            this.ChkValidarProductoCliente.TabIndex = 18;
            this.ChkValidarProductoCliente.Text = "Validar producto cliente";
            this.ChkValidarProductoCliente.UseVisualStyleBackColor = true;
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
            // tabOperador
            // 
            this.tabOperador.Controls.Add(this.ChkOperadorLogistico);
            this.tabOperador.Controls.Add(this.label3);
            this.tabOperador.Controls.Add(this.TxtCodigoCliente);
            this.tabOperador.Location = new System.Drawing.Point(4, 22);
            this.tabOperador.Name = "tabOperador";
            this.tabOperador.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperador.Size = new System.Drawing.Size(340, 234);
            this.tabOperador.TabIndex = 4;
            this.tabOperador.Text = "Operador";
            this.tabOperador.UseVisualStyleBackColor = true;
            // 
            // ChkOperadorLogistico
            // 
            this.ChkOperadorLogistico.AutoSize = true;
            this.ChkOperadorLogistico.Location = new System.Drawing.Point(103, 47);
            this.ChkOperadorLogistico.Name = "ChkOperadorLogistico";
            this.ChkOperadorLogistico.Size = new System.Drawing.Size(111, 17);
            this.ChkOperadorLogistico.TabIndex = 17;
            this.ChkOperadorLogistico.Text = "Operador logistico";
            this.ChkOperadorLogistico.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Codigo cliente:";
            // 
            // TxtCodigoCliente
            // 
            this.TxtCodigoCliente.Location = new System.Drawing.Point(103, 21);
            this.TxtCodigoCliente.Name = "TxtCodigoCliente";
            this.TxtCodigoCliente.Size = new System.Drawing.Size(103, 20);
            this.TxtCodigoCliente.TabIndex = 0;
            // 
            // ChkValidarProductoLista
            // 
            this.ChkValidarProductoLista.AutoSize = true;
            this.ChkValidarProductoLista.Location = new System.Drawing.Point(147, 110);
            this.ChkValidarProductoLista.Name = "ChkValidarProductoLista";
            this.ChkValidarProductoLista.Size = new System.Drawing.Size(124, 17);
            this.ChkValidarProductoLista.TabIndex = 19;
            this.ChkValidarProductoLista.Text = "Validar producto lista";
            this.ChkValidarProductoLista.UseVisualStyleBackColor = true;
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
            this.tbpGeneral.ResumeLayout(false);
            this.tbpGeneral.PerformLayout();
            this.tbpOperacion.ResumeLayout(false);
            this.tbpOperacion.PerformLayout();
            this.tabOperador.ResumeLayout(false);
            this.tabOperador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TabControl tabConfiguracion;
		private System.Windows.Forms.TabPage tbpOperacion;
		private System.Windows.Forms.TextBox txtCentroOperacion;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkBloquearManejo;
        private System.Windows.Forms.CheckBox ChkBloquearFlete;
        private System.Windows.Forms.TabPage tabOperador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCodigoCliente;
        private System.Windows.Forms.CheckBox ChkOperadorLogistico;
        private System.Windows.Forms.CheckBox ChkValidarProductoCliente;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.CheckBox ChkGuiaRecogida;
        private System.Windows.Forms.CheckBox ChkGuiaIngreso;
        private System.Windows.Forms.CheckBox ChkValidarProductoLista;
    }
}