using System;
using System.Drawing;
using System.Windows.Forms;
using Carniceria.Services;

namespace Carniceria.Views
{
    public partial class FrmPedirID : Form
    {
        public string IdEncontrado { get; private set; } = string.Empty;

        public FrmPedirID()
        {
            InitializeComponent();

            using (var ms = new System.IO.MemoryStream(Carniceria.Properties.Resources.icono_carniceria))
            {
                Icon = new System.Drawing.Icon(ms);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                string id = txtIDBusqueda.Text.Trim();

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDBusqueda.Focus();
                    return;
                }

                if (!IdEsValido(id))
                {
                    MessageBox.Show("El ID solo puede contener letras, números, guion o guion bajo.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDBusqueda.Focus();
                    txtIDBusqueda.SelectAll();
                    return;
                }

                var producto = ProductoService.BuscarPorId(id);

                if (producto == null)
                {
                    MessageBox.Show($"No se encontró ningún producto con el ID: {id}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIDBusqueda.Clear();
                    txtIDBusqueda.Focus();
                    return;
                }

                IdEncontrado = producto.Id;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo buscar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IdEsValido(string id)
        {
            foreach (char letra in id)
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
    }
}