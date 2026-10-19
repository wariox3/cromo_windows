using System;
using System.Net;
using System.Web.Script.Serialization;

namespace cromo
{
    /// <summary>
    /// Cliente centralizado para integración con API Fluor
    /// Maneja: autenticación JWT, refresh tokens, y operaciones
    /// </summary>
    public static class Fluor
    {
        private static string _accessToken = "";
        private static string _refreshToken = "";
        private static DateTime _tokenExpireTime = DateTime.MinValue;

        private static readonly JavaScriptSerializer _serializer = new JavaScriptSerializer();
        private const string FLUOR_AUTH_URL = "https://api.semanticaapi.com.co/auth/seguridad";

        // ============ AUTENTICACIÓN ============

        /// <summary>
        /// Autentica un usuario con email/password contra Fluor
        /// Retorna true si login exitoso, false si falló
        /// </summary>
        public static bool Login(string email, string password)
        {
            try
            {
                var loginRequest = new
                {
                    email = email,
                    password = password,
                    client_type = "integration"
                };

                string json = _serializer.Serialize(loginRequest);
                string response = ApiControlador.ApiPostPlain(
                    FLUOR_AUTH_URL + "/login",
                    json
                );

                if (string.IsNullOrWhiteSpace(response))
                    return false;

                var loginResp = _serializer.Deserialize<dynamic>(response);

                if (loginResp != null && loginResp.ContainsKey("access_token"))
                {
                    _accessToken = loginResp["access_token"].ToString();
                    _tokenExpireTime = DateTime.Now.AddMinutes(60);

                    if (loginResp.ContainsKey("refresh_token"))
                    {
                        _refreshToken = loginResp["refresh_token"].ToString();
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogError("Login failed", ex);
                return false;
            }
        }

        /// <summary>
        /// Renueva el access token usando el refresh token
        /// </summary>
        public static bool RefreshAccessToken()
        {
            if (string.IsNullOrWhiteSpace(_refreshToken))
                return !string.IsNullOrWhiteSpace(_accessToken);

            try
            {
                // Si token va a expirar en <5 minutos, renovar
                if (DateTime.Now.AddMinutes(5) < _tokenExpireTime)
                    return true;

                var refreshRequest = new { refresh_token = _refreshToken };
                string json = _serializer.Serialize(refreshRequest);
                string response = ApiControlador.ApiPostPlain(
                    FLUOR_AUTH_URL + "/refresh",
                    json
                );

                if (string.IsNullOrWhiteSpace(response))
                    return false;

                var refreshResp = _serializer.Deserialize<dynamic>(response);

                if (refreshResp != null && refreshResp.ContainsKey("access_token"))
                {
                    _accessToken = refreshResp["access_token"].ToString();
                    _tokenExpireTime = DateTime.Now.AddMinutes(60);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogError("Token refresh failed", ex);
                return false;
            }
        }

        /// <summary>
        /// Obtiene el token de acceso actual (válido)
        /// Si está a punto de expirar, intenta renovar
        /// </summary>
        public static string GetAccessToken()
        {
            RefreshAccessToken();

            if (string.IsNullOrWhiteSpace(_accessToken))
                throw new InvalidOperationException("No hay token de acceso válido. Debe autenticarse primero.");

            return _accessToken;
        }

        /// <summary>
        /// Cierra la sesión y limpia tokens
        /// </summary>
        public static void Logout()
        {
            _accessToken = "";
            _refreshToken = "";
            _tokenExpireTime = DateTime.MinValue;
        }

        /// <summary>
        /// Verifica si hay un token válido
        /// </summary>
        public static bool IsAuthenticated()
        {
            return !string.IsNullOrWhiteSpace(_accessToken) &&
                   DateTime.Now < _tokenExpireTime;
        }

        /// <summary>
        /// Obtiene información del usuario autenticado
        /// </summary>
        public static dynamic GetCurrentUser()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(
                    FLUOR_AUTH_URL + "/me"
                );
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", "Bearer " + GetAccessToken());

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new System.IO.StreamReader(
                        response.GetResponseStream()))
                    {
                        string json = reader.ReadToEnd();
                        return _serializer.Deserialize<dynamic>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("GetCurrentUser failed", ex);
                return null;
            }
        }

        // ============ HELPERS ============

        private static void LogError(string message, Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[Fluor] {message}: {ex.Message}");
        }
    }
}
