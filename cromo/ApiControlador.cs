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
            try
            {
                string url = General.UrlServicio + ruta;
                string jsonRespuesta = "";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                // Usar JWT desde Fluor en lugar de Basic Auth
                try
                {
                    string token = Fluor.GetAccessToken();
                    request.Headers.Add("Authorization", "Bearer " + token);
                }
                catch
                {
                    // Si no hay token válido, intentar con Basic Auth (fallback)
                    if (!string.IsNullOrWhiteSpace(General.UsuarioServicio) && !string.IsNullOrWhiteSpace(General.ClaveServicio))
                    {
                        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(General.UsuarioServicio + ":" + General.ClaveServicio));
                        request.Headers.Add("Authorization", "Basic " + credentials);
                    }
                }

                if (string.IsNullOrWhiteSpace(jsonParametros))
                    request.Method = "GET";
                else
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(jsonParametros);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException("Token JWT inválido o expirado");
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ApiPost error: " + ex.Message);
                throw;
            }
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
            string url = "https://semantica.com.co" + ruta;
            //ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
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

        /// <summary>
        /// POST sin autenticación (para login inicial contra Fluor)
        /// </summary>
        public static String ApiPostPlain(string url, string jsonParametros)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                if (!string.IsNullOrWhiteSpace(jsonParametros))
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(jsonParametros);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            return objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ApiPostPlain error: " + ex.Message);
                return "";
            }
        }

        /// <summary>
        /// POST con token Bearer JWT
        /// </summary>
        public static String ApiPostWithToken(string url, string jsonParametros, string token)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Headers.Add("Authorization", "Bearer " + token);

                if (!string.IsNullOrWhiteSpace(jsonParametros))
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(jsonParametros);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException("Token inválido o expirado");
                    }

                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            return objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ApiPostWithToken error: " + ex.Message);
                throw;
            }
        }

    }
}
