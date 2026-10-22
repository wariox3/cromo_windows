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
            VelopackApp.Build().Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UsarIconoEnFormularios();
            Actualizacion.ConservarConfiguracion();
            if (Actualizacion.Aplicar())
                return;
            Application.Run(new FrmPrincipal());
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
