using Carniceria.Interfaces;
using Carniceria.Models;
using Carniceria.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    // HERENCIA DE CLASES
    public partial class UC_Usuarios : UserControl
    {
        // HERENCIA DE INTERFACES
        private IUsuario _usuarioActual;
        private string _usernameOriginal = "";

        // HERENCIA DE INTERFACES
        public UC_Usuarios(IUsuario usuario)
        {
            InitializeComponent();

            _usuarioActual = usuario;
            DoubleBuffered = true;

            var propiedadBuffer = typeof(Control).GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (propiedadBuffer != null)
            {
                propiedadBuffer.SetValue(tcUsuarios, true, null);

                foreach (TabPage pag in tcUsuarios.TabPages)
                {
                    propiedadBuffer.SetValue(pag, true, null);
                }
            }

            ConfigurarTabControl();
            ConfigurarTablas();
            CargarUsuarios();
            CargarBitacora();

            cmbRol.Items.Clear();
            cmbRol.Items.Add("Empleado");
            cmbRol.Items.Add("Admi");

            ModoCreacion();
        }

        private void ConfigurarTabControl()
        {
            tcUsuarios.DrawMode = TabDrawMode.Normal;
            tcUsuarios.SizeMode = TabSizeMode.Fixed;
            tcUsuarios.ItemSize = new Size(420, 50);

            foreach (TabPage tab in tcUsuarios.TabPages)
            {
                tab.BackColor = Color.FromArgb(30, 30, 30);
            }
        }

        private void ModoCreacion()
        {
            _usernameOriginal = "";

            txtUsuario.Enabled = true;
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtNombreCompleto.Clear();
            cmbRol.SelectedIndex = 0;

            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;

            txtUsuario.Focus();
        }

        private void ModoEdicion()
        {
            txtUsuario.Enabled = true;

            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnEliminar.Visible = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ModoCreacion();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Ingresa un nombre de usuario para buscar.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!UsuarioValido(username))
            {
                MessageBox.Show("El usuario solo puede contener letras, números, guion o guion bajo.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                txtUsuario.SelectAll();
                return;
            }

            var usuarioEncontrado = UsuarioService.ObtenerPorNombre(username);

            if (usuarioEncontrado == null)
            {
                MessageBox.Show($"El usuario '{username}' no está registrado.\nEl formulario se configuró para crearlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModoCreacion();
                txtUsuario.Text = username;
                txtContrasena.Focus();
                return;
            }

            _usernameOriginal = username;
            txtContrasena.Text = usuarioEncontrado.Value.Pass;
            cmbRol.SelectedItem = usuarioEncontrado.Value.Rol;
            txtNombreCompleto.Text = usuarioEncontrado.Value.Nombre;

            ModoEdicion();
        }

        private void ConfigurarTablas()
        {
            ConfigurarTablaBase(dgvUsuarios);
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Columns.Add("User", "USUARIO");
            dgvUsuarios.Columns.Add("Nombre", "NOMBRE COMPLETO");
            dgvUsuarios.Columns.Add("Rol", "ROL");
            AplicarEstiloTabla(dgvUsuarios);

            ConfigurarTablaBase(dgvBitacora);
            dgvBitacora.Columns.Clear();
            dgvBitacora.Columns.Add("Fecha", "FECHA / HORA");
            dgvBitacora.Columns.Add("User", "USUARIO");
            dgvBitacora.Columns.Add("Rol", "ROL");
            dgvBitacora.Columns.Add("Accion", "ACTIVIDAD REGISTRADA");
            AplicarEstiloTabla(dgvBitacora);
        }

        private void ConfigurarTablaBase(DataGridView tabla)
        {
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.MultiSelect = false;
            tabla.ReadOnly = true;
            tabla.AllowUserToOrderColumns = false;
            tabla.AllowUserToResizeColumns = false;
            tabla.AllowUserToResizeRows = false;
        }

        private void AplicarEstiloTabla(DataGridView tabla)
        {
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.BackgroundColor = Color.FromArgb(30, 30, 30);
            tabla.BorderStyle = BorderStyle.None;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabla.GridColor = Color.FromArgb(50, 50, 50);
            tabla.RowHeadersVisible = false;
            tabla.EnableHeadersVisualStyles = true;
            tabla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle();

            tabla.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            tabla.DefaultCellStyle.ForeColor = Color.White;
            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 192, 192);
            tabla.DefaultCellStyle.SelectionForeColor = Color.Black;
            tabla.DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 12F);
            tabla.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            tabla.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            tabla.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 192, 192);
            tabla.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            tabla.RowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            tabla.RowsDefaultCellStyle.ForeColor = Color.White;
            tabla.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 192, 192);
            tabla.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.Rows.Clear();

            var lista = UsuarioService.ObtenerTodos();

            foreach (var u in lista)
            {
                dgvUsuarios.Rows.Add(u.Username, u.Nombre, u.Rol);
            }
        }

        private void CargarBitacora()
        {
            dgvBitacora.Rows.Clear();

            var logs = UsuarioService.ObtenerBitacora();

            foreach (var log in logs)
            {
                dgvBitacora.Rows.Add(
                    log.FechaHora.ToString("dd/MM/yyyy hh:mm:ss tt"),
                    log.Usuario,
                    log.Rol,
                    log.Accion);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                string user = txtUsuario.Text.Trim().ToUpper();
                string pass = txtContrasena.Text.Trim();

                string nombreCrudo = txtNombreCompleto.Text.Trim().ToLower();
                string nombre = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreCrudo);

                string rol = ObtenerRolSeleccionado();

                if (!CamposObligatoriosCompletos(user, pass, nombre))
                {
                    MessageBox.Show("Por favor llena todos los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!UsuarioValido(user))
                {
                    MessageBox.Show("El usuario solo puede contener letras, números, guion o guion bajo.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                    return;
                }

                if (!ContrasenaValida(pass))
                {
                    MessageBox.Show("La contraseña debe tener al menos 4 caracteres y no puede contener comas.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    txtContrasena.SelectAll();
                    return;
                }

                if (!NombreValido(nombre))
                {
                    MessageBox.Show("El nombre completo solo puede contener letras, espacios, puntos o guiones.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreCompleto.Focus();
                    txtNombreCompleto.SelectAll();
                    return;
                }

                string original = ObtenerUsuarioOriginal(user);

                if (!original.Equals(user, StringComparison.OrdinalIgnoreCase))
                {
                    if (UsuarioService.ExisteUsuario(user))
                    {
                        MessageBox.Show($"El nombre de usuario '{user}' ya está ocupado por otra cuenta.\nPor favor elige uno diferente.", "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                bool guardado = UsuarioService.GuardarUsuario(original, user, pass, rol, nombre);

                if (!guardado)
                {
                    MessageBox.Show("No se pudo guardar el usuario. Revisa los datos e inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Usuario '{user}' procesado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModoCreacion();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerRolSeleccionado()
        {
            if (cmbRol.SelectedItem == null)
            {
                return "Empleado";
            }

            return cmbRol.SelectedItem.ToString();
        }

        private bool CamposObligatoriosCompletos(string user, string pass, string nombre)
        {
            return !string.IsNullOrEmpty(user) &&
                   !string.IsNullOrEmpty(pass) &&
                   !string.IsNullOrEmpty(nombre);
        }

        private bool ContrasenaValida(string pass)
        {
            return pass.Length >= 4 && !pass.Contains(",");
        }

        private string ObtenerUsuarioOriginal(string user)
        {
            if (string.IsNullOrEmpty(_usernameOriginal))
            {
                return user;
            }

            return _usernameOriginal;
        }

        private bool UsuarioValido(string usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                return false;
            }

            foreach (char letra in usuario)
            {
                bool esLetraONumero = char.IsLetterOrDigit(letra);
                bool esGuion = letra == '-';
                bool esGuionBajo = letra == '_';

                if (!esLetraONumero && !esGuion && !esGuionBajo)
                {
                    return false;
                }
            }

            return true;
        }

        private bool NombreValido(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            foreach (char letra in nombre)
            {
                bool esLetra = char.IsLetter(letra);
                bool esEspacio = char.IsWhiteSpace(letra);
                bool esPunto = letra == '.';
                bool esGuion = letra == '-';

                if (!esLetra && !esEspacio && !esPunto && !esGuion)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string userAEliminar = txtUsuario.Text.Trim();

            if (!string.IsNullOrEmpty(_usernameOriginal))
            {
                userAEliminar = _usernameOriginal;
            }

            if (string.IsNullOrEmpty(userAEliminar))
            {
                return;
            }

            if (userAEliminar.Equals(_usuarioActual.Username, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Seguridad del Sistema: No puedes dar de baja tu propio usuario mientras tienes una sesión activa.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Seguro que quieres eliminar definitivamente al usuario '{userAEliminar}'?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            bool eliminado = UsuarioService.EliminarUsuario(userAEliminar);

            if (eliminado)
            {
                MessageBox.Show("Usuario removido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModoCreacion();
                CargarUsuarios();
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
            string username = row.Cells["User"].Value.ToString();

            txtUsuario.Text = username;
            btnBuscarUsuario_Click(null, null);
        }

        private void btnBorrarBitacora_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que deseas vaciar por completo el historial de entradas?\n\nEsta acción eliminará de forma irreversible el historial.",
                "Advertencia De Historial",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            UsuarioService.LimpiarBitacora();

            MessageBox.Show("Historial de accesos limpiado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarBitacora();
        }

        private void btnRefrescarLogs_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }
    }
}