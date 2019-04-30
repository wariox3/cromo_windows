using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cromo
{
    public partial class FrmVisor : Form
    {
        public FrmVisor()
        {
            InitializeComponent();
        }

        private void FrmVisor_Load(object sender, EventArgs e)
        {
            string ruta = cromo.Properties.Settings.Default.rutaReportes + @"Transporte\Guia.rdlc";

            List<ApiGuia> Agregar = new List<ApiGuia>();            
            Agregar.Add(new ApiGuia
            {
                numero = 1123
            });
            
            MessageBox.Show(ruta);            
            this.reportViewer1.LocalReport.ReportPath = ruta;
            ReportParameter param = new ReportParameter("rutaImagen", @"file:\" + Directory.GetCurrentDirectory() + @"\logo.jpg", true);
            this.reportViewer1.LocalReport.SetParameters(param);
            ReportDataSource rds1 = new ReportDataSource("Guia", Agregar);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();                

        }


    }
}
