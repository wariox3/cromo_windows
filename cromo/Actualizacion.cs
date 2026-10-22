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
                return false; // ejecución desde Visual Studio o sin instalar

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
