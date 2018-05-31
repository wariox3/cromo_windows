namespace cromo
{
	partial class frmReporte
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
			this.crvReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvReporte
			// 
			this.crvReporte.ActiveViewIndex = -1;
			this.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crvReporte.Cursor = System.Windows.Forms.Cursors.Default;
			this.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crvReporte.Location = new System.Drawing.Point(0, 0);
			this.crvReporte.Name = "crvReporte";
			this.crvReporte.Size = new System.Drawing.Size(953, 512);
			this.crvReporte.TabIndex = 0;
			// 
			// frmReporte
			// 
			this.ClientSize = new System.Drawing.Size(953, 512);
			this.Controls.Add(this.crvReporte);
			this.Name = "frmReporte";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmReporte_Load_1);
			this.ResumeLayout(false);

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporte;
	}
}