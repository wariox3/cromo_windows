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
            Actualizacion.ConservarConfiguracion();
            if (Actualizacion.Aplicar())
                return;
            Application.Run(new FrmPrincipal());
        }
    }
}
