using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace cromo
{
	public partial class frmReporte : Form
	{
		public frmReporte()
		{
			InitializeComponent();
		}

		private void frmReporte_Load(object sender, EventArgs e)
		{
			/* https:/www.youtube.com/watch?v=iisXC_RsZ3w */
			ReportDocument rpt = new ReportDocument();
			rpt.Load(@"C:\Users\desarrollo\source\repos\cromo\cromo\recibo.rpt");
			crystalReportViewer1.ReportSource = rpt;
			crystalReportViewer1.Refresh();
		}
	}
}
