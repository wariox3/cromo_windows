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
        // Fluor puede registrar o rechazar versiones viejas de la aplicacion con este encabezado
        private static HttpWebRequest CrearPeticion(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Client-Version", System.Windows.Forms.Application.ProductVersion);
            request.UserAgent = "Cromo/" + System.Windows.Forms.Application.ProductVersion;
            return request;
        }

        /// <summary>
        /// POST sin autenticación (para login inicial contra Fluor)
        /// </summary>
        public static String ApiPostPlain(string url, string jsonParametros)
        {
            try
            {
                var request = CrearPeticion(url);
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

        public static String ApiGetWithToken(string url, string token)
        {
            var request = CrearPeticion(url);
            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer " + token);

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static byte[] ApiGetBytesWithToken(string url, string token)
        {
            var request = CrearPeticion(url);
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + token);

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var memoria = new MemoryStream())
            {
                stream.CopyTo(memoria);
                return memoria.ToArray();
            }
        }

        /// <summary>
        /// POST con token Bearer JWT
        /// </summary>
        public static String ApiPostWithToken(string url, string jsonParametros, string token)
        {
            try
            {
                var request = CrearPeticion(url);
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
