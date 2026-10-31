using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velopack;

namespace cromo
{
    // Actualizaciones con Velopack: se revisan al abrir y son obligatorias
    static class Actualizacion
    {
        public const string Ubicacion = "https://cdn-semantica.tor1.digitaloceanspaces.com/cromo/descargas";

        // Devuelve true si se instaló una versión nueva y la aplicación se está reiniciando
        public static bool Aplicar()
        {
            var manager = new UpdateManager(Ubicacion);
            if (!manager.IsInstalled)
            {
                // Paquete de Windows 7 (sin instalador): no se puede actualizar solo, se avisa si hay versión nueva.
                // En Windows 10 y 11 sin instalar (Visual Studio) no se hace nada, como antes
                if (EsWindows7 && !System.Diagnostics.Debugger.IsAttached)
                    AvisarVersionNueva();
                return false;
            }

            UpdateInfo version;
            try
            {
                version = manager.CheckForUpdates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo revisar si hay una version nueva de Cromo, se abrira la version actual.\n\n" + ex.Message,
                    "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (version == null)
                return false;

            return Instalar(manager, version);
        }

        // Paquete para Windows 7 (el instalador de Velopack no funciona en Windows 7)
        public const string PaqueteWindows7 = Ubicacion + "/Cromo-win7.zip";

        // Windows 7 o anterior (versión 6.1). Sin manifiesto, .NET reporta Windows 8 y posteriores como 6.2 o más,
        // así que Windows 10 y 11 nunca entran aquí
        public static bool EsWindows7 => Environment.OSVersion.Version < new Version(6, 2);

        // Compara con la última versión publicada (releases.win.json) y ofrece descargar el paquete de Windows 7
        private static void AvisarVersionNueva()
        {
            Version publicada;
            try
            {
                string json;
                using (var cliente = new System.Net.WebClient())
                {
                    cliente.Encoding = System.Text.Encoding.UTF8;
                    json = cliente.DownloadString(Ubicacion + "/releases.win.json");
                }
                publicada = UltimaVersion(json);
            }
            catch
            {
                return; // sin conexión o sin publicaciones: se abre la versión actual sin avisar
            }

            if (publicada == null || !Version.TryParse(Application.ProductVersion, out Version actual) || publicada <= actual)
                return;

            var respuesta = MessageBox.Show("Hay una version nueva de Cromo (" + publicada.ToString(3) + "). Su version es " + actual.ToString(3) + ".\n\n" +
                "¿Desea descargarla ahora? Descomprima el archivo en la misma carpeta de Cromo reemplazando los archivos.",
                "Version nueva", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respuesta == DialogResult.Yes)
            {
                try { System.Diagnostics.Process.Start(PaqueteWindows7); }
                catch (Exception ex) { MessageBox.Show("No se pudo abrir la descarga: " + ex.Message + "\n\n" + PaqueteWindows7, "Version nueva"); }
            }
        }

        // releases.win.json: { "Assets": [ { "Version": "2.2.2", "Type": "Full", ... } ] }
        private static Version UltimaVersion(string json)
        {
            var datos = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<System.Collections.Generic.Dictionary<string, object>>(json);
            Version mayor = null;
            if (datos != null && datos.TryGetValue("Assets", out object assets) && assets is System.Collections.ArrayList lista)
                foreach (var item in lista)
                    if (item is System.Collections.Generic.Dictionary<string, object> asset
                        && asset.TryGetValue("Version", out object texto)
                        && Version.TryParse(texto?.ToString().Split('-')[0], out Version v)
                        && (mayor == null || v > mayor))
                        mayor = v;
            return mayor;
        }

        private static bool Instalar(UpdateManager manager, UpdateInfo version)
        {
            string nueva = version.TargetFullRelease.Version.ToString();
            var etiqueta = new Label { Dock = DockStyle.Top, Height = 40, TextAlign = ContentAlignment.MiddleLeft, Text = "Descargando la version " + nueva + "..." };
            var barra = new ProgressBar { Dock = DockStyle.Top, Height = 20 };
            var ventana = new Form
            {
                Text = "Actualizando Cromo",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                ControlBox = false,
                ClientSize = new Size(360, 80),
                Padding = new Padding(12)
            };
            ventana.Controls.Add(barra);
            ventana.Controls.Add(etiqueta);

            bool instalada = false;
            ventana.Shown += async (s, e) =>
            {
                try
                {
                    var progreso = new Progress<int>(p => barra.Value = Math.Max(0, Math.Min(100, p)));
                    await Task.Run(() => manager.DownloadUpdates(version, p => ((IProgress<int>)progreso).Report(p)));
                    etiqueta.Text = "Instalando la version " + nueva + "...";
                    instalada = true;
                    manager.ApplyUpdatesAndRestart(version);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ventana, "No se pudo instalar la version " + nueva + ". Intente abrir Cromo de nuevo.\n\n" + ex.Message,
                        "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    instalada = false;
                    ventana.Close();
                }
            };
            Application.Run(ventana);
            return instalada;
        }

        // Cada versión instalada usa su propio user.config: al estrenar versión se trae la configuración de la anterior
        public static void ConservarConfiguracion()
        {
            var configuracion = cromo.Properties.Settings.Default;
            if (!configuracion.actualizarConfiguracion)
                return;
            configuracion.Upgrade();
            configuracion.actualizarConfiguracion = false;
            configuracion.Save();
        }
    }
}
