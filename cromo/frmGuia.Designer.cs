namespace cromo
{
    partial class frmGuia
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuia));
            this.gbDestinatario = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreCiudadDestino = new System.Windows.Forms.TextBox();
            this.txtCodigoCiudadDestino = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTotales = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNombreCiudadOrigen = new System.Windows.Forms.TextBox();
            this.txtCodigoCiudadOrigen = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.gbDestinatario.SuspendLayout();
            this.gbTotales.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDestinatario
            // 
            this.gbDestinatario.Controls.Add(this.label5);
            this.gbDestinatario.Controls.Add(this.txtNombreCiudadDestino);
            this.gbDestinatario.Controls.Add(this.txtCodigoCiudadDestino);
            this.gbDestinatario.Controls.Add(this.textBox5);
            this.gbDestinatario.Controls.Add(this.textBox4);
            this.gbDestinatario.Controls.Add(this.textBox3);
            this.gbDestinatario.Controls.Add(this.label4);
            this.gbDestinatario.Controls.Add(this.label3);
            this.gbDestinatario.Controls.Add(this.label2);
            this.gbDestinatario.Enabled = false;
            this.gbDestinatario.Location = new System.Drawing.Point(12, 163);
            this.gbDestinatario.Name = "gbDestinatario";
            this.gbDestinatario.Size = new System.Drawing.Size(645, 109);
            this.gbDestinatario.TabIndex = 4;
            this.gbDestinatario.TabStop = false;
            this.gbDestinatario.Text = "Destinatario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Destino:";
            // 
            // txtNombreCiudadDestino
            // 
            this.txtNombreCiudadDestino.Enabled = false;
            this.txtNombreCiudadDestino.Location = new System.Drawing.Point(214, 76);
            this.txtNombreCiudadDestino.Name = "txtNombreCiudadDestino";
            this.txtNombreCiudadDestino.ReadOnly = true;
            this.txtNombreCiudadDestino.Size = new System.Drawing.Size(420, 20);
            this.txtNombreCiudadDestino.TabIndex = 18;
            // 
            // txtCodigoCiudadDestino
            // 
            this.txtCodigoCiudadDestino.Location = new System.Drawing.Point(108, 76);
            this.txtCodigoCiudadDestino.Name = "txtCodigoCiudadDestino";
            this.txtCodigoCiudadDestino.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoCiudadDestino.TabIndex = 8;
            this.txtCodigoCiudadDestino.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCiudadDestino_KeyDown);
            this.txtCodigoCiudadDestino.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(108, 49);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(361, 20);
            this.textBox5.TabIndex = 7;
            this.textBox5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(534, 22);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(108, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(361, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Telefono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Destinatario:";
            // 
            // gbTotales
            // 
            this.gbTotales.Controls.Add(this.textBox14);
            this.gbTotales.Controls.Add(this.textBox13);
            this.gbTotales.Controls.Add(this.textBox12);
            this.gbTotales.Controls.Add(this.textBox11);
            this.gbTotales.Controls.Add(this.textBox10);
            this.gbTotales.Controls.Add(this.textBox9);
            this.gbTotales.Controls.Add(this.textBox8);
            this.gbTotales.Controls.Add(this.label12);
            this.gbTotales.Controls.Add(this.label11);
            this.gbTotales.Controls.Add(this.label10);
            this.gbTotales.Controls.Add(this.label9);
            this.gbTotales.Controls.Add(this.label8);
            this.gbTotales.Controls.Add(this.label7);
            this.gbTotales.Controls.Add(this.label6);
            this.gbTotales.Enabled = false;
            this.gbTotales.Location = new System.Drawing.Point(449, 278);
            this.gbTotales.Name = "gbTotales";
            this.gbTotales.Size = new System.Drawing.Size(208, 183);
            this.gbTotales.TabIndex = 9;
            this.gbTotales.TabStop = false;
            this.gbTotales.Text = "Totales";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(86, 148);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 20);
            this.textBox14.TabIndex = 15;
            this.textBox14.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(86, 126);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 20);
            this.textBox13.TabIndex = 14;
            this.textBox13.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(86, 104);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 20);
            this.textBox12.TabIndex = 13;
            this.textBox12.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(86, 82);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 20);
            this.textBox11.TabIndex = 12;
            this.textBox11.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(86, 60);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 11;
            this.textBox10.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(86, 38);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 10;
            this.textBox9.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(86, 15);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 9;
            this.textBox8.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Manejo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Flete:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Declara:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "P.Facturar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Volumen:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Peso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Unidades:";
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.label15);
            this.gbCliente.Controls.Add(this.txtNombreCiudadOrigen);
            this.gbCliente.Controls.Add(this.txtCodigoCiudadOrigen);
            this.gbCliente.Controls.Add(this.label14);
            this.gbCliente.Controls.Add(this.label13);
            this.gbCliente.Controls.Add(this.textBox16);
            this.gbCliente.Controls.Add(this.textBox15);
            this.gbCliente.Controls.Add(this.txtNombreCliente);
            this.gbCliente.Controls.Add(this.label1);
            this.gbCliente.Controls.Add(this.txtCodigoCliente);
            this.gbCliente.Enabled = false;
            this.gbCliente.Location = new System.Drawing.Point(12, 28);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(645, 129);
            this.gbCliente.TabIndex = 0;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(64, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Origen:";
            // 
            // txtNombreCiudadOrigen
            // 
            this.txtNombreCiudadOrigen.Enabled = false;
            this.txtNombreCiudadOrigen.Location = new System.Drawing.Point(214, 102);
            this.txtNombreCiudadOrigen.Name = "txtNombreCiudadOrigen";
            this.txtNombreCiudadOrigen.ReadOnly = true;
            this.txtNombreCiudadOrigen.Size = new System.Drawing.Size(420, 20);
            this.txtNombreCiudadOrigen.TabIndex = 21;
            // 
            // txtCodigoCiudadOrigen
            // 
            this.txtCodigoCiudadOrigen.Location = new System.Drawing.Point(111, 102);
            this.txtCodigoCiudadOrigen.Name = "txtCodigoCiudadOrigen";
            this.txtCodigoCiudadOrigen.Size = new System.Drawing.Size(97, 20);
            this.txtCodigoCiudadOrigen.TabIndex = 20;
            this.txtCodigoCiudadOrigen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCiudadOrigen_KeyDown);
            this.txtCodigoCiudadOrigen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Remitente:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Documento:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(111, 76);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(176, 20);
            this.textBox16.TabIndex = 3;
            this.textBox16.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(111, 50);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(523, 20);
            this.textBox15.TabIndex = 2;
            this.textBox15.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Location = new System.Drawing.Point(217, 24);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(417, 20);
            this.txtNombreCliente.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tercero:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(111, 24);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoCliente.TabIndex = 1;
            this.txtCodigoCliente.TextChanged += new System.EventHandler(this.txtCodigoCliente_TextChanged);
            this.txtCodigoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCliente_KeyDown);
            this.txtCodigoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCliente_KeyPress);
            this.txtCodigoCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metodoComun_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(732, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(913, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // frmGuia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 555);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbTotales);
            this.Controls.Add(this.gbDestinatario);
            this.Name = "frmGuia";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Guia_Load);
            this.gbDestinatario.ResumeLayout(false);
            this.gbDestinatario.PerformLayout();
            this.gbTotales.ResumeLayout(false);
            this.gbTotales.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDestinatario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreCiudadDestino;
        private System.Windows.Forms.TextBox txtCodigoCiudadDestino;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbTotales;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNombreCiudadOrigen;
        private System.Windows.Forms.TextBox txtCodigoCiudadOrigen;
    }
}

