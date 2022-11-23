using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace cromo
{
    public partial class FrmConexion : Form
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        public FrmConexion()
        {
            InitializeComponent();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();        
            string parametrosJson = "{\"guiaTipo\":\"COR\"}";
            string jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/guiatipo/detalle", parametrosJson);
            ApiGuiaTipo apiGuiaTipo = ser.Deserialize<ApiGuiaTipo>(jsonRespuesta);
            if (apiGuiaTipo.error == null)
            {
            }
            sw.Stop();
            MessageBox.Show(sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff") + " " + apiGuiaTipo.nombre);
        }

        private void btnProbar2_Click(object sender, EventArgs e)
        {
            /*Stopwatch sw = new Stopwatch();
            sw.Start();
            string parametrosJson = "{\"codigo\":\"478\"}";
            string jsonRespuesta = ApiControlador.ApiPostSinConexion("/transporte/api/windows/ciudad/detalle", parametrosJson);
            ApiCiudad apiCiudad = ser.Deserialize<ApiCiudad>(jsonRespuesta);
            if (apiCiudad.error == null)
            {
                MessageBox.Show("Tiempo");
            }
            sw.Stop();
            MessageBox.Show(sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));*/
        }

        private void btnProbar3_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string parametrosJson = "{\"codigo\":\"478\"}";
           // ApiControlador ob = new ApiControlador();
            var jsonRespuesta = ApiControlador.ApiPost("/transporte/api/windows/ciudad/detalle", parametrosJson);
            ApiCiudad apiCiudad = ser.Deserialize<ApiCiudad>(jsonRespuesta);
            if (apiCiudad.error == null)
            {
                
            }
            sw.Stop();
            MessageBox.Show(sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff") +" "+apiCiudad.nombre);
        }
    }
}
