using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            pnlMenu = new Panel();
            btnUsuarios = new Button();
            btnCorteDeCaja = new Button();
            btnInventario = new Button();
            btnVenta = new Button();
            btnAyuda = new Button();
            btnCerrarSesion = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlContenido = new Panel();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(230, 20, 20, 20);
            pnlMenu.Controls.Add(btnUsuarios);
            pnlMenu.Controls.Add(btnCorteDeCaja);
            pnlMenu.Controls.Add(btnInventario);
            pnlMenu.Controls.Add(btnVenta);
            pnlMenu.Controls.Add(btnAyuda);
            pnlMenu.Controls.Add(btnCerrarSesion);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(254, 967);
            pnlMenu.TabIndex = 20;
            pnlMenu.Visible = false;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(160, 40, 40, 40);
            btnUsuarios.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnUsuarios.FlatAppearance.BorderSize = 2;
            btnUsuarios.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Arial Rounded MT Bold", 16F);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 220);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(254, 67);
            btnUsuarios.TabIndex = 10;
            btnUsuarios.Text = "👥 USUARIOS ";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Visible = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnCorteDeCaja
            // 
            btnCorteDeCaja.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnCorteDeCaja.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnCorteDeCaja.FlatAppearance.BorderSize = 2;
            btnCorteDeCaja.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnCorteDeCaja.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnCorteDeCaja.FlatStyle = FlatStyle.Flat;
            btnCorteDeCaja.Font = new Font("Arial Rounded MT Bold", 16F);
            btnCorteDeCaja.ForeColor = Color.White;
            btnCorteDeCaja.Location = new Point(0, 146);
            btnCorteDeCaja.Name = "btnCorteDeCaja";
            btnCorteDeCaja.Size = new Size(254, 67);
            btnCorteDeCaja.TabIndex = 9;
            btnCorteDeCaja.Text = "🗃️ CORTE DE CAJA ";
            btnCorteDeCaja.UseVisualStyleBackColor = false;
            btnCorteDeCaja.Visible = false;
            btnCorteDeCaja.Click += btnCorteDeCaja_Click;
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnInventario.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnInventario.FlatAppearance.BorderSize = 2;
            btnInventario.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnInventario.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Arial Rounded MT Bold", 16F);
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(0, 73);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(254, 67);
            btnInventario.TabIndex = 8;
            btnInventario.Text = "🗓️ INVENTARIO";
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnVenta
            // 
            btnVenta.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnVenta.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnVenta.FlatAppearance.BorderSize = 2;
            btnVenta.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnVenta.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnVenta.FlatStyle = FlatStyle.Flat;
            btnVenta.Font = new Font("Arial Rounded MT Bold", 16F);
            btnVenta.ForeColor = Color.White;
            btnVenta.Location = new Point(0, 0);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new Size(254, 67);
            btnVenta.TabIndex = 7;
            btnVenta.Text = "\U0001f6d2 VENTA";
            btnVenta.UseVisualStyleBackColor = false;
            btnVenta.Click += btnVenta_Click;
            // 
            // btnAyuda
            // 
            btnAyuda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAyuda.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnAyuda.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnAyuda.FlatAppearance.BorderSize = 2;
            btnAyuda.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnAyuda.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnAyuda.FlatStyle = FlatStyle.Flat;
            btnAyuda.Font = new Font("Arial Rounded MT Bold", 16F);
            btnAyuda.ForeColor = Color.White;
            btnAyuda.Location = new Point(0, 819);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(254, 67);
            btnAyuda.TabIndex = 11;
            btnAyuda.Text = "❓ AYUDA";
            btnAyuda.UseVisualStyleBackColor = false;
            btnAyuda.Click += btnAyuda_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnCerrarSesion.FlatAppearance.BorderSize = 2;
            btnCerrarSesion.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnCerrarSesion.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Arial Rounded MT Bold", 16F);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(0, 900);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(254, 67);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "🔐 CERRAR SESION";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.FromArgb(200, 30, 30, 30);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(1706, 967);
            pnlContenido.TabIndex = 0;
            pnlContenido.Visible = false;
            pnlContenido.Paint += pnlContenido_Paint;
            // 
            // FrmPrincipal
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.CarniceriaFondo;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1706, 967);
            Controls.Add(pnlMenu);
            Controls.Add(pnlContenido);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPrincipal";
            WindowState = FormWindowState.Maximized;
            Load += FormPrincipal_Load;
            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnUsuarios;
        private Button btnCorteDeCaja;
        private Button btnInventario;
        private Button btnVenta;
        private Button btnAyuda;
        private Button btnCerrarSesion;
        protected Panel pnlMenu;
        private System.Windows.Forms.Timer timer1;
        private Panel pnlContenido;
    }
}