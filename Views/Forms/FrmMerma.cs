using Carniceria.Interfaces;
using Carniceria.Models;
using Carniceria.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Carniceria.Views.Forms
{
    public partial class FrmMerma : Form
    {
        // HERENCIA DE INTERFACES
        private List<IProductoMedible> _listaProductos;

        private bool _guardando = false;

        public Merma MermaGuardada { get; private set; }

        public FrmMerma()
        {
            InitializeComponent();
            CargarProductos();

            KeyPreview = true;
            AcceptButton = btnGuardar;
            btnGuardar.Text = "💾 GUARDAR MERMA (G)";

            cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
            txtPesoBruto.TextChanged += CalcularMerma;
            txtPesoNeto.TextChanged += CalcularMerma;
            txtPesoBruto.KeyPress += ValidarCantidad_KeyPress;
            txtPesoNeto.KeyPress += ValidarCantidad_KeyPress;
            btnGuardar.Click += btnGuardar_Click;
            KeyDown += FrmMerma_KeyDown;
        }

        private void FrmMerma_KeyDown(object sender, KeyEventArgs e)
        {
            bool estaEscribiendo = txtPesoBruto.Focused || txtPesoNeto.Focused || txtNotas.Focused;

            if (e.Control && e.KeyCode == Keys.G)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                GuardarMerma();
                return;

            }

            if (!estaEscribiendo && e.KeyCode == Keys.G)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                GuardarMerma();
            }
        }

        private void CargarProductos()
        {
            // EXCEPCIONES
            try
            {
                // INSTANCIACIÓN DE CLASES PROPIAS
                _listaProductos = new List<IProductoMedible>();
                List<IProducto> productos = ProductoService.ObtenerTodos();

                foreach (IProducto producto in productos)
                {
                    // HERENCIA DE INTERFACES
                    IProductoMedible productoMedible = producto as IProductoMedible;

                    if (productoMedible != null)
                    {
                        _listaProductos.Add(productoMedible);
                    }
                }

                cboProducto.Items.Clear();

                foreach (var p in _listaProductos)
                {
                    cboProducto.Items.Add($"{p.Id} - {p.Nombre} ({p.FormatearCantidad(p.Stock)})");
                }

                if (cboProducto.Items.Count > 0)
                {
                    cboProducto.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Mermas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTextosUnidad();
            CalcularMerma(sender, e);
        }

        private void CalcularMerma(object sender, EventArgs e)
        {
            var producto = ProductoActual();
            string unidad = producto?.UnidadMedida ?? "KG";

            if (!TryParseDecimal(txtPesoBruto.Text, out decimal bruto) ||
                !TryParseDecimal(txtPesoNeto.Text, out decimal neto))
            {
                MostrarMerma(0, unidad, Color.SpringGreen);
                return;
            }

            if (producto == null)
            {
                MostrarMerma(0, unidad, Color.SpringGreen);
                return;
            }

            if (producto.SeVendePorPieza && (bruto % 1 != 0 || neto % 1 != 0))
            {
                lblResultadoMerma.Text = "ERROR: USA SOLO ENTEROS";
                lblResultadoMerma.ForeColor = Color.Crimson;
                return;
            }

            decimal merma = bruto - neto;
            var color = merma < 0 ? Color.Crimson : Color.SpringGreen;
            MostrarMerma(merma, unidad, color);
        }

        private void MostrarMerma(decimal merma, string unidad, Color color)
        {
            lblResultadoMerma.Text = $"MERMA: {FormatearCantidad(merma, unidad)}";
            lblResultadoMerma.ForeColor = color;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarMerma();
        }

        private void GuardarMerma()
        {
            if (_guardando)
            {
                return;
            }

            _guardando = true;

            // EXCEPCIONES
            try
            {
                if (cboProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!TryParseDecimal(txtPesoBruto.Text, out decimal bruto))
                {
                    MessageBox.Show("Ingresa una cantidad bruta válida. Puedes usar punto o coma decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!TryParseDecimal(txtPesoNeto.Text, out decimal neto))
                {
                    MessageBox.Show("Ingresa una cantidad neta válida. Puedes usar punto o coma decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var productoSeleccionado = ProductoActual();

                if (productoSeleccionado == null)
                {
                    MessageBox.Show("No pude leer el producto seleccionado. Vuelve a abrir mermas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (bruto <= 0)
                {
                    MessageBox.Show("La cantidad bruta debe ser mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (neto < 0)
                {
                    MessageBox.Show("La cantidad neta no puede ser negativa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (neto >= bruto)
                {
                    MessageBox.Show("La cantidad neta debe ser menor que la cantidad bruta para registrar una merma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal cantidadMerma = bruto - neto;

                if (!productoSeleccionado.CantidadValida(cantidadMerma))
                {
                    string mensaje;

                    if (productoSeleccionado.SeVendePorPieza)
                    {
                        mensaje = "Este producto se controla por piezas enteras.";
                    }
                    else
                    {
                        mensaje = "La cantidad de merma no es válida.";
                    }

                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (productoSeleccionado.Stock < cantidadMerma)
                {
                    string disponible = productoSeleccionado.FormatearCantidad(productoSeleccionado.Stock);

                    MessageBox.Show("No hay stock suficiente para descontar la merma.\nDisponible: " + disponible,
                        "Inventario insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // INSTANCIACIÓN DE CLASES PROPIAS
                Merma nuevaMerma = new Merma
                {
                    Fecha = DateTime.Now,
                    IdProducto = productoSeleccionado.Id,
                    NombreProducto = productoSeleccionado.Nombre,
                    PesoBruto = bruto,
                    PesoNeto = neto,
                    PrecioUnitario = productoSeleccionado.Precio,
                    UnidadMedida = productoSeleccionado.UnidadMedida,
                    Notas = LimpiarNotas(txtNotas.Text)
                };

                MermaService.Guardar(nuevaMerma);

                MermaGuardada = nuevaMerma;

                MessageBox.Show("Merma registrada y stock actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al guardar la merma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _guardando = false;
            }
        }

        private void ValidarCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            TextBox caja = sender as TextBox;

            bool esNumero = char.IsDigit(e.KeyChar);
            bool esPunto = e.KeyChar == '.';
            bool esComa = e.KeyChar == ',';

            if (!esNumero && !esPunto && !esComa)
            {
                e.Handled = true;
                MessageBox.Show("Las cantidades solo aceptan números.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (caja != null && (esPunto || esComa))
            {
                ValidarDecimalRepetido(caja, e);
            }
        }

        private void ValidarDecimalRepetido(TextBox caja, KeyPressEventArgs e)
        {
            if (caja.Text.Contains(".") || caja.Text.Contains(","))
            {
                e.Handled = true;
                MessageBox.Show("La cantidad solo puede tener un decimal.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool TryParseDecimal(string texto, out decimal valor)
        {
            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor))
            {
                return true;
            }

            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
            {
                return true;
            }

            return false;
        }

        private IProductoMedible ProductoActual()
        {
            if (_listaProductos == null || cboProducto.SelectedIndex < 0 || cboProducto.SelectedIndex >= _listaProductos.Count)
            {
                return null;
            }

            return _listaProductos[cboProducto.SelectedIndex];
        }

        private void ActualizarTextosUnidad()
        {
            string unidad = "KG";
            IProductoMedible producto = ProductoActual();

            if (producto != null)
            {
                unidad = producto.UnidadMedida;
            }

            string etiqueta = "KG";

            if (unidad == "PZA")
            {
                etiqueta = "PIEZAS";
            }

            labelBruto.Text = $"CANTIDAD BRUTA ({etiqueta}):";
            labelNeto.Text = $"CANTIDAD NETA ({etiqueta}):";
        }

        private string FormatearCantidad(decimal cantidad, string unidad)
        {
            if (unidad == "PZA")
            {
                return cantidad.ToString("N0") + " PZA";
            }

            return cantidad.ToString("N3") + " KG";
        }

        private string LimpiarNotas(string notas)
        {
            string limpias = string.Empty;

            if (notas != null)
            {
                limpias = notas;
            }

            limpias = limpias.Replace("\r", " ");
            limpias = limpias.Replace("\n", " ");
            limpias = limpias.Replace("\t", " ");
            limpias = limpias.Trim();
            limpias = limpias.Replace(",", " ");

            if (limpias.Length > 180)
            {
                return limpias.Substring(0, 180);
            }

            return limpias;
        }
    }
}
