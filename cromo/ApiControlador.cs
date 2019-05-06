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
            string url = General.UrlServicio+ruta;            
            string jsonRespuesta = "";
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
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
            string url = "http://159.65.52.53/cesio/public/index.php" + ruta;

            string jsonRespuesta = "";
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/raw";
                jsonRespuesta = wc.UploadString(url, jsonParametros);
            }
            return jsonRespuesta;
        }

    }
}
