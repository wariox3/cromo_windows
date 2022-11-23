using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace cromo
{
    public class ApiControlador
    {

        private static Cookie _cookie;
        private static CookieContainer _cookieContainer = new CookieContainer();

        public static String ApiPost(string ruta, string jsonParametros)
        {
            /*https://learn.microsoft.com/es-es/dotnet/api/system.net.httpwebresponse.cookies?view=net-7.0*/
            string url = General.UrlServicio + ruta;
            string usuario = General.UsuarioServicio;
            string clave = General.ClaveServicio;
            string jsonRespuesta = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookieContainer;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            if (string.IsNullOrWhiteSpace(jsonParametros))
                request.Method = "GET";
            else
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonParametros);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

            if (_cookie == null)
            {
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(usuario + ":" + clave));
                request.Headers.Add("Authorization", "Basic " + credentials);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (_cookie == null)
                {
                    foreach (Cookie cook in response.Cookies)
                    {
                        _cookie = cook;

                        request.CookieContainer.Add(_cookie);
                    }
                }
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) jsonRespuesta = "fallo";
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        jsonRespuesta = responseBody;
                    }
                }

            }
            return jsonRespuesta;

        }

        public static String ApiPostV1(string ruta, string jsonParametros)
        {
            string url = General.UrlServicio+ruta;
            string token = General.TokenServicio;
            string usuario = General.UsuarioServicio;
            string clave = General.ClaveServicio;
            string jsonRespuesta = "";
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/raw";
                //wc.Headers.Add("X-AUTH-TOKEN", token);
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(usuario + ":" + clave));
                wc.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;               
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

        public static String ApiPostSinConexion(string ruta, string jsonParametros)
        {
            string url = General.UrlServicio + ruta;
            string token = General.TokenServicio;
            string usuario = General.UsuarioServicio;
            string clave = General.ClaveServicio;
            string jsonRespuesta = "";
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/raw";                           
                if (jsonParametros != null)
                {
                    jsonRespuesta = wc.UploadString(url, jsonParametros);
                }
                else
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                    jsonRespuesta = wc.DownloadString(url);
                }

            }
            return jsonRespuesta;
        }

        public static String ApiPostRubidio(string ruta, string jsonParametros)
        {
            string url = "http://142.93.149.5/rubidio/public/index.php" + ruta;

            string jsonRespuesta = "";
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/raw";
                jsonRespuesta = wc.UploadString(url, jsonParametros);
            }
            return jsonRespuesta;
        }

        public static String ApiPrueba(string ruta, string jsonParametros)
        {
            string url = General.UrlServicio + ruta;           
            string usuario = General.UsuarioServicio;
            string clave = General.ClaveServicio;
            var request = (HttpWebRequest)WebRequest.Create(url);
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(usuario + ":" + clave));
            string jsonRespuesta = "";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Basic " + credentials);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonParametros);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return "fallo";
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        jsonRespuesta = responseBody;
                    }
                }
            }
            return jsonRespuesta;

        }
        
    }
}
