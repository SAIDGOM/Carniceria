using Carniceria.Interfaces;
using Carniceria.Models;
using Carniceria.Services;
using System;
using System.Windows.Forms;

namespace Carniceria.Views
{
    public partial class FrmProducto : Form
    {
        private bool _esModificacion = false;
        private string _idOriginal = "";

        private void CargarCategoriasDinamicas()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new object[] { "Res", "Cerdo", "Otros" });

            var productosGuardados = ProductoService.ObtenerTodos();

            foreach (var p in productosGuardados)
            {
                string catCruda = p.Categoria.Trim().ToLower();
                string catLimpia = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(catCruda);

                if (!string.IsNullOrEmpty(catLimpia))
                {
                    if (!cmbCategoria.Items.Contains(catLimpia))
                    {
                        cmbCategoria.Items.Add(catLimpia);
                    }
                }
            }
        }

        // SOBRECARGA
        public FrmProducto()
        {
            InitializeComponent();
            using (var ms = new System.IO.MemoryStream(Carniceria.Properties.Resources.icono_carniceria))
            {
                Icon = new System.Drawing.Icon(ms);
            }
            _esModificacion = false;

            lblTitulo.Text = "NUEVO PRODUCTO";
            btnEliminar.Visible = false;

            CargarCategoriasDinamicas();

            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbUnidad.Items.Count > 0) cmbUnidad.SelectedIndex = 0;

            ConfigurarEventosNumericos();
        }

        public FrmProducto(IProducto producto)
        {
            InitializeComponent();
            _esModificacion = true;
            _idOriginal = producto.Id;

            lblTitulo.Text = "EDITAR PRODUCTO";
            btnEliminar.Visible = true;

            CargarCategoriasDinamicas();

            txtID.Text = producto.Id;
            txtNombre.Text = producto.Nombre;
            numPrecio.Value = producto.Precio;
            numStock.Value = producto.Stock;

            string catLimpia = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(producto.Categoria.Trim().ToLower());
            if (!cmbCategoria.Items.Contains(catLimpia))
            {
                cmbCategoria.Items.Add(catLimpia);
            }
            cmbCategoria.Text = catLimpia;

            if (producto.UnidadMedida == "PZA")
            {
                cmbUnidad.Text = "Piezas (PZA)";
            }
            else
            {
                cmbUnidad.Text = "Kilos (KG)";
            }

            ConfigurarEventosNumericos();
        }

        private void ConfigurarEventosNumericos()
        {
            numPrecio.Enter += numPrecio_Enter;
            numPrecio.MouseClick += numPrecio_MouseClick;
            numStock.Enter += numStock_Enter;
            numStock.MouseClick += numStock_MouseClick;
        }

        private void numPrecio_Enter(object sender, EventArgs e)
        {
            numPrecio.Select(0, 20);
        }

        private void numPrecio_MouseClick(object sender, MouseEventArgs e)
        {
            numPrecio.Select(0, 20);
        }

        private void numStock_Enter(object sender, EventArgs e)
        {
            numStock.Select(0, 20);
        }

        private void numStock_MouseClick(object sender, MouseEventArgs e)
        {
            numStock.Select(0, 20);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("El ID y el Nombre son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El ID y el Nombre son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string idNuevo = txtID.Text.Trim().ToUpper();
                string nombreNormalizado = txtNombre.Text.Trim().Replace(",", " ");

                if (!IdEsValido(idNuevo))
                {
                    MessageBox.Show("El ID solo puede contener letras, números, guion o guion bajo.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                    txtID.SelectAll();
                    return;
                }

                if (!NombreEsValido(nombreNormalizado))
                {
                    MessageBox.Show("El nombre del producto contiene caracteres inválidos.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    txtNombre.SelectAll();
                    return;
                }

                string categoriaCruda = cmbCategoria.Text.Trim().ToLower().Replace(",", " ");
                string categoriaNormalizado = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoriaCruda);

                if (string.IsNullOrWhiteSpace(categoriaNormalizado)) categoriaNormalizado = "Otros";

                if (cmbUnidad.SelectedIndex < 0)
                {
                    if (string.IsNullOrWhiteSpace(cmbUnidad.Text))
                    {
                        MessageBox.Show("Selecciona si el producto se vende por kilos o piezas.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string unidadFinal = "KG";

                if (cmbUnidad.Text.Contains("PZA"))
                {
                    unidadFinal = "PZA";
                }
                decimal precio = numPrecio.Value;
                decimal stock = numStock.Value;

                if (precio <= 0)
                {
                    MessageBox.Show("El precio debe ser mayor que cero.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numPrecio.Focus();
                    return;
                }

                if (stock < 0)
                {
                    MessageBox.Show("El stock no puede ser negativo.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numStock.Focus();
                    return;
                }

                if (unidadFinal == "PZA")
                {
                    if (stock % 1 != 0)
                    {
                        MessageBox.Show("Los productos por pieza deben tener stock entero, sin decimales.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        numStock.Focus();
                        return;
                    }
                }

                bool exito = false;

                if (_esModificacion)
                {
                    exito = ProductoService.Modificar(_idOriginal, idNuevo, nombreNormalizado, precio, stock, categoriaNormalizado, unidadFinal);
                    if (exito)
                    {
                        MessageBox.Show("Producto actualizado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"¡El código '{idNuevo}' ya le pertenece a otro producto!\nNo puedes tener dos productos con el mismo ID.", "ID Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Focus();
                        txtID.SelectAll();
                        return;
                    }
                }
                else
                {
                    exito = ProductoService.Agregar(idNuevo, nombreNormalizado, precio, stock, categoriaNormalizado, unidadFinal);
                    if (exito)
                    {
                        MessageBox.Show("Producto agregado exitosamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"¡El código '{idNuevo}' ya está ocupado!\nInvéntate un ID diferente para poder guardarlo.", "Código Repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Focus();
                        txtID.SelectAll();
                        return;
                    }
                }

                if (exito)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro de que quieres eliminar permanentemente el producto '{txtNombre.Text}'?",
                "⚠️ ZONA DE PELIGRO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                if (ProductoService.Eliminar(_idOriginal))
                {
                    MessageBox.Show("Producto borrado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al intentar borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IdEsValido(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            foreach (char letra in id)
            {
                bool esLetraONumero = char.IsLetterOrDigit(letra);
                bool esGuion = letra == '-';
                bool esGuionBajo = letra == '_';

                if (!esLetraONumero)
                {
                    if (!esGuion)
                    {
                        if (!esGuionBajo)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool NombreEsValido(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            foreach (char letra in nombre)
            {
                if (char.IsControl(letra))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
