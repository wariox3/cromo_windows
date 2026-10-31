using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velopack;

namespace cromo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Debe ser lo primero: Velopack ejecuta aquí los pasos de instalación, actualización y desinstalación
            VelopackApp.Build()
                .OnAfterInstallFastCallback(v => RefrescarIconos())
                .OnAfterUpdateFastCallback(v => RefrescarIconos())
                .Run();

            // Windows 7 no activa TLS 1.2 por defecto en .NET y Fluor y el Space lo exigen.
            // Solo en Windows 7: en Windows 10 y 11 se deja la configuración del sistema (permite TLS 1.3)
            if (Actualizacion.EsWindows7)
                System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UsarIconoEnFormularios();
            Actualizacion.ConservarConfiguracion();
            if (Actualizacion.Aplicar())
                return;
            Application.Run(new FrmPrincipal());
        }

        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern void SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        // Windows guarda en caché el ícono de los accesos directos; como la ruta del ejecutable no cambia
        // entre versiones, seguiría mostrando el ícono anterior. Esto le pide que los vuelva a leer.
        private static void RefrescarIconos()
        {
            try
            {
                const int SHCNE_ASSOCCHANGED = 0x08000000;
                SHChangeNotify(SHCNE_ASSOCCHANGED, 0, IntPtr.Zero, IntPtr.Zero);
            }
            catch
            {
                // No es crítico: el ícono se actualiza solo cuando Windows renueve su caché
            }
        }

        // WinForms no permite cambiar el ícono por defecto de los formularios; se asigna el de Cromo
        // por reflexión para que todas las ventanas lo usen sin repetirlo en cada una.
        private static void UsarIconoEnFormularios()
        {
            try
            {
                using (var flujo = typeof(Program).Assembly.GetManifestResourceStream("cromo.Resources.cromo.ico"))
                {
                    if (flujo == null) return;
                    var icono = new System.Drawing.Icon(flujo);
                    typeof(Form).GetField("defaultIcon", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?.SetValue(null, icono);
                }
            }
            catch
            {
                // Si falla, las ventanas quedan con el ícono por defecto de Windows
            }
        }
    }
}
