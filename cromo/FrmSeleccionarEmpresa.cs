using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cromo
{
    /// <summary>
    /// Define la empresa (tenant) del usuario: consulta sus empresas, la deja elegir y descarga los catálogos de esa empresa.
    /// Se usa al iniciar sesión y en Archivo > Cambiar empresa. Si la descarga falla, se conserva la empresa anterior
    /// (al iniciar sesión no hay anterior y se puede elegir otra o cancelar).
    /// Devuelve OK solo cuando la empresa quedó definida con sus catálogos.
    /// </summary>
    public class FrmSeleccionarEmpresa : Form
    {
        private readonly ListView LstEmpresas = new ListView();
        private readonly Label LblEstado = new Label();
        private readonly ProgressBar PrgCarga = new ProgressBar();
        private readonly Button BtnAceptar = new Button();
        private readonly Button BtnCancelar = new Button();
        private bool ocupado;

        private Fluor.Empresa Seleccionada => LstEmpresas.SelectedItems.Count > 0 ? LstEmpresas.SelectedItems[0].Tag as Fluor.Empresa : null;

        public FrmSeleccionarEmpresa()
        {
            Text = "Seleccionar empresa";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(480, 330);
            Font = new Font("Segoe UI", 9F);

            var lblTitulo = new Label
            {
                Text = "Seleccione la empresa con la que desea trabajar:",
                Location = new Point(12, 12),
                AutoSize = true
            };

            LstEmpresas.Location = new Point(12, 36);
            LstEmpresas.Size = new Size(456, 214);
            LstEmpresas.View = View.Details;
            LstEmpresas.FullRowSelect = true;
            LstEmpresas.MultiSelect = false;
            LstEmpresas.HideSelection = false;
            LstEmpresas.GridLines = true;
            LstEmpresas.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            LstEmpresas.Columns.Add("Empresa", 290);
            LstEmpresas.Columns.Add("UsuarioERP", 100);
            LstEmpresas.Columns.Add("Control", 60, HorizontalAlignment.Center);
            LstEmpresas.DoubleClick += (s, e) => { if (Seleccionada != null) BtnAceptar.PerformClick(); };

            LblEstado.Location = new Point(12, 256);
            LblEstado.Size = new Size(456, 18);

            PrgCarga.Location = new Point(12, 276);
            PrgCarga.Size = new Size(290, 18);
            PrgCarga.Maximum = CatalogoManager.Pasos;

            BtnAceptar.Text = "Aceptar";
            BtnAceptar.Location = new Point(312, 294);
            BtnAceptar.Size = new Size(75, 26);
            BtnAceptar.Click += BtnAceptar_Click;

            BtnCancelar.Text = "Cancelar";
            BtnCancelar.Location = new Point(393, 294);
            BtnCancelar.Size = new Size(75, 26);
            BtnCancelar.DialogResult = DialogResult.Cancel;

            AcceptButton = BtnAceptar;
            CancelButton = BtnCancelar;
            Controls.AddRange(new Control[] { lblTitulo, LstEmpresas, LblEstado, PrgCarga, BtnAceptar, BtnCancelar });
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Ocupado(true, "Consultando empresas...");
            PrgCarga.Style = ProgressBarStyle.Marquee;

            List<Fluor.Empresa> empresas;
            try
            {
                empresas = await Task.Run(() => Fluor.Empresas());
            }
            catch (Exception ex)
            {
                Cerrar("No se pudieron consultar las empresas del usuario.\n\n" + Fluor.MensajeError(ex));
                return;
            }

            if (empresas.Count == 0)
            {
                Cerrar("El usuario no tiene acceso a ninguna empresa activa.");
                return;
            }

            foreach (var empresa in empresas)
            {
                var fila = new ListViewItem(empresa.Nombre) { Tag = empresa };
                fila.SubItems.Add(empresa.CodigoUsuario ?? "");
                fila.SubItems.Add(empresa.Control ? "SI" : "NO");
                LstEmpresas.Items.Add(fila);
            }
            int actual = empresas.FindIndex(x => x.TenantId == Fluor.EmpresaActual?.TenantId);
            var seleccion = LstEmpresas.Items[actual >= 0 ? actual : 0];
            seleccion.Selected = true;
            seleccion.Focused = true;
            seleccion.EnsureVisible();
            PrgCarga.Style = ProgressBarStyle.Blocks;
            Ocupado(false, null);
            LstEmpresas.Focus();
        }

        private async void BtnAceptar_Click(object sender, EventArgs e)
        {
            var empresa = Seleccionada;
            if (empresa == null || ocupado)
                return;

            // Misma empresa con los catálogos ya cargados: no hay nada que cambiar
            if (Fluor.EmpresaActual != null && Fluor.EmpresaActual.TenantId == empresa.TenantId && CatalogoManager.CatalogosCargados)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            var anterior = Fluor.EmpresaActual;
            Ocupado(true, "Cargando catálogos de " + empresa.Nombre + "...");
            PrgCarga.Value = 0;
            Fluor.SeleccionarEmpresa(empresa);
            var progreso = new Progress<KeyValuePair<int, string>>(p =>
            {
                PrgCarga.Value = Math.Min(p.Key, PrgCarga.Maximum);
                LblEstado.Text = p.Value;
            });

            if (await Task.Run(() => CatalogoManager.CargarCatalogos(progreso, forzar: true)))
            {
                ocupado = false;
                DialogResult = DialogResult.OK;
                return;
            }

            Fluor.SeleccionarEmpresa(anterior);
            Ocupado(false, null);
            string continuar = anterior != null ? "Se continúa trabajando con " + anterior.Nombre + "." : "Puede intentar de nuevo o elegir otra empresa.";
            MessageBox.Show(this, "No se pudieron cargar los catálogos de " + empresa.Nombre + ". " + continuar + "\n\n" + CatalogoManager.UltimoError,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Ocupado(bool valor, string estado)
        {
            ocupado = valor;
            LstEmpresas.Enabled = !valor;
            BtnAceptar.Enabled = !valor;
            BtnCancelar.Enabled = !valor;
            LblEstado.Visible = valor;
            PrgCarga.Visible = valor;
            if (estado != null)
                LblEstado.Text = estado;
        }

        private void Cerrar(string mensaje)
        {
            ocupado = false;
            MessageBox.Show(this, mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Mientras consulta o descarga no se puede cerrar (la X también queda bloqueada)
            if (ocupado)
                e.Cancel = true;
            base.OnFormClosing(e);
        }
    }
}
