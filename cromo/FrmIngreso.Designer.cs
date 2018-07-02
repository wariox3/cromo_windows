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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TxtContraseña = new System.Windows.Forms.TextBox();
			this.TxtUsuario = new System.Windows.Forms.TextBox();
			this.BtnIngresar = new System.Windows.Forms.Button();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.BtnConfigurar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(43, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Usuario:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(43, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Contraseña:";
			// 
			// TxtContraseña
			// 
			this.TxtContraseña.Location = new System.Drawing.Point(125, 49);
			this.TxtContraseña.Name = "TxtContraseña";
			this.TxtContraseña.Size = new System.Drawing.Size(188, 20);
			this.TxtContraseña.TabIndex = 1;
			this.TxtContraseña.UseSystemPasswordChar = true;
			// 
			// TxtUsuario
			// 
			this.TxtUsuario.Location = new System.Drawing.Point(125, 15);
			this.TxtUsuario.Name = "TxtUsuario";
			this.TxtUsuario.Size = new System.Drawing.Size(188, 20);
			this.TxtUsuario.TabIndex = 0;
			// 
			// BtnIngresar
			// 
			this.BtnIngresar.Location = new System.Drawing.Point(228, 89);
			this.BtnIngresar.Name = "BtnIngresar";
			this.BtnIngresar.Size = new System.Drawing.Size(85, 24);
			this.BtnIngresar.TabIndex = 2;
			this.BtnIngresar.Text = "Ingresar";
			this.BtnIngresar.UseVisualStyleBackColor = true;
			this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancelar.Location = new System.Drawing.Point(46, 90);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(85, 23);
			this.BtnCancelar.TabIndex = 3;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// BtnConfigurar
			// 
			this.BtnConfigurar.Location = new System.Drawing.Point(137, 90);
			this.BtnConfigurar.Name = "BtnConfigurar";
			this.BtnConfigurar.Size = new System.Drawing.Size(85, 23);
			this.BtnConfigurar.TabIndex = 4;
			this.BtnConfigurar.Text = "Configurar";
			this.BtnConfigurar.UseVisualStyleBackColor = true;
			this.BtnConfigurar.Click += new System.EventHandler(this.BtnConfigurar_Click);
			// 
			// FrmIngreso
			// 
			this.AcceptButton = this.BtnIngresar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancelar;
			this.ClientSize = new System.Drawing.Size(329, 126);
			this.ControlBox = false;
			this.Controls.Add(this.BtnConfigurar);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.BtnIngresar);
			this.Controls.Add(this.TxtUsuario);
			this.Controls.Add(this.TxtContraseña);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FrmIngreso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ingreso al sistema";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TxtContraseña;
		private System.Windows.Forms.TextBox TxtUsuario;
		private System.Windows.Forms.Button BtnIngresar;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Button BtnConfigurar;
	}
}