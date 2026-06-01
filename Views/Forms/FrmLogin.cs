using Carniceria.Interfaces;
using Carniceria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace Carniceria.Views
{
    public partial class FrmLogin : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FrmLogin()
        {
            InitializeComponent();
            using (var ms = new System.IO.MemoryStream(Carniceria.Properties.Resources.icono_carniceria))
            {
                Icon = new System.Drawing.Icon(ms);
            }
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            Color colorBorde = Color.FromArgb(0, 192, 192);
            int grosor = 2;

            ControlPaint.DrawBorder(e.Graphics, pnlLogin.ClientRectangle,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid
            );
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                string nombreInput = txtUser.Text.Trim();
                string contraseñaInput = txtContraseña.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombreInput) || string.IsNullOrWhiteSpace(contraseñaInput))
                {
                    MessageBox.Show("Ingresa usuario y contraseña.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                    return;
                }

                if (nombreInput.Contains(",") || contraseñaInput.Contains(","))
                {
                    MessageBox.Show("Usuario y contraseña no pueden contener comas.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContraseña.Clear();
                    txtUser.Focus();
                    return;
                }

                var usuarioValido = Services.UsuarioService.Autenticar(nombreInput, contraseñaInput);

                if (usuarioValido != null)
                {
                    string rolEncontrado = usuarioValido is Admi ? "Admi" : "Empleado";
                    Services.UsuarioService.RegistrarAcceso(usuarioValido.Nombre, rolEncontrado, "INICIO DE SESIÓN EXITOSO");

                    FrmPrincipal principal = new FrmPrincipal(usuarioValido);
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Clear();
                    txtUser.Clear();
                    txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}