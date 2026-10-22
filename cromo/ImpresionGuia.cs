using System;
using System.IO;
using System.Windows.Forms;

namespace cromo
{
    // Fluor genera el PDF de las guías del rango (máximo 30)
    static class ImpresionGuia
    {
        public const int MaximoGuias = 30;

        // Abre el PDF con el lector de PDF del equipo
        public static void Previsualizar(IWin32Window ventana, int desde, int hasta)
        {
            ConPdf(ventana, desde, hasta, pdf =>
            {
                string ruta = Path.Combine(Path.GetTempPath(), "guias_" + desde + "_" + hasta + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
                File.WriteAllBytes(ruta, pdf);
                System.Diagnostics.Process.Start(ruta);
            });
        }

        // Envía el PDF a la impresora predeterminada de Windows sin mostrarlo
        public static void Imprimir(IWin32Window ventana, int desde, int hasta)
        {
            ConPdf(ventana, desde, hasta, pdf =>
            {
                using (var memoria = new MemoryStream(pdf))
                using (var documento = PdfiumViewer.PdfDocument.Load(memoria))
                using (var impresion = documento.CreatePrintDocument())
                {
                    impresion.DocumentName = "Guias " + desde + "-" + hasta;
                    impresion.PrintController = new System.Drawing.Printing.StandardPrintController();
                    impresion.Print();
                }
            });
        }

        private static void ConPdf(IWin32Window ventana, int desde, int hasta, Action<byte[]> usar)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                usar(Fluor.GetBytes("/tte/guia/imprimir-guia?numero_desde=" + desde + "&numero_hasta=" + hasta));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ventana, "No se pudo imprimir la guia: " + Fluor.MensajeError(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
