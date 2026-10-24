namespace cromo
{
	partial class FrmIngreso
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtContraseña = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.BtnIngresar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.ChkRecordar = new System.Windows.Forms.CheckBox();
            this.LblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(33, 38);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.Location = new System.Drawing.Point(85, 64);
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.Size = new System.Drawing.Size(188, 20);
            this.TxtContraseña.TabIndex = 2;
            this.TxtContraseña.UseSystemPasswordChar = true;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(85, 38);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(188, 20);
            this.TxtUsuario.TabIndex = 1;
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.Location = new System.Drawing.Point(188, 117);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(85, 24);
            this.BtnIngresar.TabIndex = 3;
            this.BtnIngresar.Text = "Ingresar";
            this.BtnIngresar.UseVisualStyleBackColor = true;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(6, 118);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(85, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // ChkRecordar
            // 
            this.ChkRecordar.AutoSize = true;
            this.ChkRecordar.Location = new System.Drawing.Point(86, 88);
            this.ChkRecordar.Name = "ChkRecordar";
            this.ChkRecordar.Size = new System.Drawing.Size(70, 17);
            this.ChkRecordar.TabIndex = 6;
            this.ChkRecordar.Text = "Recordar";
            this.ChkRecordar.UseVisualStyleBackColor = true;
            //
            // LblEstado
            //
            this.LblEstado.Location = new System.Drawing.Point(6, 150);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(267, 15);
            this.LblEstado.TabIndex = 7;
            this.LblEstado.Visible = false;
            //
            // FrmIngreso
            // 
            this.AcceptButton = this.BtnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(287, 172);
            this.ControlBox = false;
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.ChkRecordar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.TxtContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsuario);
            this.Name = "FrmIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso al sistema";
            this.Load += new System.EventHandler(this.FrmIngreso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblUsuario;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TxtContraseña;
		private System.Windows.Forms.TextBox TxtUsuario;
		private System.Windows.Forms.Button BtnIngresar;
		private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.CheckBox ChkRecordar;
        private System.Windows.Forms.Label LblEstado;
    }
}