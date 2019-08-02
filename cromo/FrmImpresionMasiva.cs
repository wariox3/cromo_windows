using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cromo
{
    public partial class FrmImpresionMasiva : Form
    {
        public FrmImpresionMasiva()
        {
            InitializeComponent();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            int numeroDesde = Convert.ToInt32(TxtCodigoDesde.Text);
            int numeroHasta = Convert.ToInt32(TxtCodigoHasta.Text);
            if(numeroDesde <= numeroHasta)
            {
                if(numeroHasta - numeroDesde <= 3000)
                {
                    ImprimirFormato formato = new ImprimirFormato();
                    formato.codigoFormato = General.CodigoFormatoGuia;
                    formato.codigoDesde = numeroDesde.ToString();
                    formato.codigoHasta = numeroHasta.ToString();
                    formato.tipo = "Guia";
                    General.Formato = formato;
                    FrmVisor frm = new FrmVisor();
                    frm.ShowDialog();
                } else
                {
                    MessageBox.Show("La diferencia entre numero no puede ser superior a 3000");
                }
            } else
            {
                MessageBox.Show("El numero desde debe ser menor o igual al numero hasta");
            }
        }
    }
}
