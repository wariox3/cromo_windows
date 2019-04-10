using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
namespace cromo
{
    public class ApiControlador
    {
        public static String ApiPost(string ruta, string jsonParametros)
        {
            //string ejemploJson = "{\"numeroUnicoGuia\":\"S\",\"numero\":\"2000000000\"}";
            
            /*JavaScriptSerializer ser = new JavaScriptSerializer();
            ApiRespuesta jsonRespuesta = ser.Deserialize<ApiRespuesta>(json);
            
            if(jsonRespuesta.error != "")
            {
                MessageBox.Show(jsonRespuesta.error);
            }*/

            string url = General.UrlServicio+ruta;
            
            string jsonRespuesta = "";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/raw";
                if (jsonParametros != null)
                {                    
                    jsonRespuesta = wc.UploadString(url, jsonParametros);
                } else
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                    jsonRespuesta = wc.DownloadString(url);
                }
                
            }
            return jsonRespuesta;
        }

        public static String ApiPostCesio(string ruta, string jsonParametros)
        {
            string url = "http://192.168.15.43/cesio/public/index.php" + ruta;

            string jsonRespuesta = "";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/raw";
                jsonRespuesta = wc.UploadString(url, jsonParametros);
            }
            return jsonRespuesta;
        }

        public static String ApiGet()
        {
            //string url = "http://192.168.15.43/cromo/public/index.php/transporte/api/windows/guia/prueba";
            /*var json = new WebClient().DownloadString(url);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            UsuarioEjemplo ueUsuario = ser.Deserialize<UsuarioEjemplo>(json);
            MessageBox.Show(ueUsuario.mensaje);*/
            return "hola";
        }
    }
}
