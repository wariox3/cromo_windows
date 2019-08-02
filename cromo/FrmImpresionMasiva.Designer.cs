namespace cromo
{
    partial class FrmImpresionMasiva
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
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCodigoDesde = new System.Windows.Forms.TextBox();
            this.TxtCodigoHasta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Location = new System.Drawing.Point(107, 64);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(138, 23);
            this.BtnImprimir.TabIndex = 2;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // TxtCodigoDesde
            // 
            this.TxtCodigoDesde.Location = new System.Drawing.Point(145, 12);
            this.TxtCodigoDesde.Name = "TxtCodigoDesde";
            this.TxtCodigoDesde.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigoDesde.TabIndex = 0;
            // 
            // TxtCodigoHasta
            // 
            this.TxtCodigoHasta.Location = new System.Drawing.Point(145, 38);
            this.TxtCodigoHasta.Name = "TxtCodigoHasta";
            this.TxtCodigoHasta.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigoHasta.TabIndex = 1;
            // 
            // FrmImpresionMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 112);
            this.Controls.Add(this.TxtCodigoHasta);
            this.Controls.Add(this.TxtCodigoDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnImprimir);
            this.Name = "FrmImpresionMasiva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresion masiva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodigoDesde;
        private System.Windows.Forms.TextBox TxtCodigoHasta;
    }
}