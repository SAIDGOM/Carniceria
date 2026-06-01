using Carniceria.Interfaces;
using Carniceria.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    public partial class FrmPrincipal : Form
    {
        // HERENCIA DE INTERFACES
        private IUsuario _usuarioActual;

        // HERENCIA DE INTERFACES
        public FrmPrincipal(IUsuario usuario)
        {
            InitializeComponent();
            using (var ms = new System.IO.MemoryStream(Carniceria.Properties.Resources.icono_carniceria))
            {
                Icon = new System.Drawing.Icon(ms);
            }

            _usuarioActual = usuario;
            DoubleBuffered = true;

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, pnlContenido, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, pnlMenu, new object[] { true });
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
            pnlMenu.Dock = DockStyle.Left;

            pnlContenido.Visible = true;
            pnlContenido.Dock = DockStyle.Fill;

            _usuarioActual.ConfigurarPermisos(btnVenta, btnInventario, btnCorteDeCaja, btnUsuarios);
        }

        private void CargarModulo(UserControl modulo)
        {
            if (pnlContenido.Controls.Count > 0)
            {
                pnlContenido.Controls[0].Dispose();
            }

            pnlContenido.Controls.Clear();
            modulo.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(modulo);
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            // INSTANCIACIÓN DE CLASES PROPIAS
            CargarModulo(new UC_Ventas(_usuarioActual));
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            // INSTANCIACIÓN DE CLASES PROPIAS
            CargarModulo(new UC_Inventario(_usuarioActual));
        }

        private void DibujarBordeNeon(System.Drawing.Graphics graficos, System.Drawing.Rectangle area)
        {
            System.Drawing.Color colorBorde = System.Drawing.Color.FromArgb(0, 192, 192);
            int grosor = 2;
            ControlPaint.DrawBorder(graficos, area,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid);
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e) => DibujarBordeNeon(e.Graphics, pnlContenido.ClientRectangle);

        private void pnlMenu_Paint(object sender, PaintEventArgs e) => DibujarBordeNeon(e.Graphics, pnlMenu.ClientRectangle);

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea cerrar la sesión actual?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            // INSTANCIACIÓN DE CLASES PROPIAS
            FrmLogin login = new FrmLogin();
            login.Show();
            Close();
        }

        private void btnCorteDeCaja_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            // INSTANCIACIÓN DE CLASES PROPIAS
            UC_CorteCaja ucCorte = new UC_CorteCaja(_usuarioActual);
            ucCorte.Location = new Point(0, 45);
            pnlContenido.Controls.Add(ucCorte);
            pnlContenido.Visible = true;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // INSTANCIACIÓN DE CLASES PROPIAS
            UC_Usuarios uc = new UC_Usuarios(_usuarioActual);
            uc.Dock = DockStyle.Fill;
            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(uc);
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                ManualService.AbrirManual(_usuarioActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el manual PDF: " + ex.Message, "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}