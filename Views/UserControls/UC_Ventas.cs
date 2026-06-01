using Carniceria.Interfaces;
using Carniceria.Models;
using Carniceria.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Carniceria.Views
{
    // HERENCIA DE CLASES
    public partial class UC_Ventas : UserControl
    {
        // HERENCIA DE INTERFACES
        private IUsuario _usuarioActual;

        // INSTANCIACIÓN DE CLASES PROPIAS
        private class ConsumoProducto
        {
            public string Id { get; set; }
            public decimal Cantidad { get; set; }
        }

        // HERENCIA DE INTERFACES
        public UC_Ventas(IUsuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;

            DoubleBuffered = true;
            typeof(UserControl).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, this, new object[] { true });

            dgvVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenta.MultiSelect = false;
            dgvVenta.AllowUserToResizeRows = false;
            dgvVenta.RowHeadersVisible = false;
            txtPeso.KeyPress += txtPeso_KeyPress;

            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AplicarEstiloTablaVenta();

            timerReloj.Interval = 1000;
            timerReloj.Start();

            txtIdProducto.AutoSize = false;
            txtIdProducto.Height = 65;

            ConfigurarAutocompletado();
            LimpiarTodoElPuntoDeVenta();
        }

        private void AplicarEstiloTablaVenta()
        {
            dgvVenta.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvVenta.BorderStyle = BorderStyle.None;
            dgvVenta.GridColor = Color.FromArgb(64, 64, 64);
            dgvVenta.RowHeadersVisible = false;
            dgvVenta.EnableHeadersVisualStyles = false;

            dgvVenta.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dgvVenta.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            dgvVenta.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvVenta.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dgvVenta.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 10F);
            dgvVenta.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvVenta.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvVenta.DefaultCellStyle.ForeColor = Color.White;
            dgvVenta.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dgvVenta.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvVenta.DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 12F);
            dgvVenta.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgvVenta.RowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvVenta.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvVenta.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dgvVenta.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void ConfigurarAutocompletado()
        {
            // INSTANCIACIÓN DE CLASES PROPIAS
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            var productos = ProductoService.ObtenerTodos();

            foreach (var p in productos)
            {
                coleccion.Add(p.Id);
                coleccion.Add(p.Nombre);
            }

            txtIdProducto.AutoCompleteCustomSource = coleccion;
            txtIdProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtIdProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            lblTiempo.Text = DateTime.Now.ToString("dddd d 'de' MMMM yyyy | hh:mm:ss tt", new CultureInfo("es-MX"));
        }

        private void txtIdProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string entrada = txtIdProducto.Text.Trim();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    MessageBox.Show("Primero ingresa el ID o nombre del producto.", "Dato faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdProducto.Focus();
                    e.SuppressKeyPress = true;
                    return;
                }

                var producto = BuscarProductoPorEntrada(entrada);

                if (producto != null)
                {
                    txtIdProducto.Text = producto.Id;
                    lblNombreProducto.Text = producto.Nombre;
                    lblCategoria.Text = "Categoría: " + producto.Categoria;

                    if (producto.UnidadMedida == "PZA")
                    {
                        lblPrecioProducto.Text = $"Precio (PZA) : {producto.Precio:F2} MXN";
                        lblStock.Text = $"En Stock: {(int)producto.Stock} pzas";
                        lblPeso.Text = "Cantidad (PZAS) :";
                    }
                    else
                    {
                        lblPrecioProducto.Text = $"Precio (KG) : {producto.Precio:F2} MXN";
                        lblStock.Text = $"En Stock: {producto.Stock:N3} kg";
                        lblPeso.Text = "Peso (KG) :";
                    }

                    lblEstadoProducto.Text = "PRODUCTO ENCONTRADO ✅";
                    lblEstadoProducto.ForeColor = Color.SpringGreen;

                    txtPeso.Focus();
                    txtPeso.SelectAll();
                }
                else
                {
                    lblEstadoProducto.Text = "PRODUCTO NO ENCONTRADO ❌";
                    lblEstadoProducto.ForeColor = Color.Red;
                    MessageBox.Show("El producto o código ingresado no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                e.SuppressKeyPress = true;
            }
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregar.PerformClick();
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            bool esNumero = char.IsDigit(e.KeyChar);
            bool esPunto = e.KeyChar == '.';
            bool esComa = e.KeyChar == ',';

            if (!esNumero)
            {
                if (!esPunto)
                {
                    if (!esComa)
                    {
                        e.Handled = true;
                        MessageBox.Show("La cantidad solo acepta números.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (esPunto)
            {
                ValidarDecimalPeso(e);
            }

            if (esComa)
            {
                ValidarDecimalPeso(e);
            }
        }

        private void ValidarDecimalPeso(KeyPressEventArgs e)
        {
            if (txtPeso.Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("La cantidad solo puede tener un decimal.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPeso.Text.Contains(","))
            {
                e.Handled = true;
                MessageBox.Show("La cantidad solo puede tener un decimal.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
            {
                MessageBox.Show("Ingresa primero el ID o nombre del producto.", "Dato faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdProducto.Focus();
                return;
            }

            if (lblNombreProducto.Text == "-")
            {
                MessageBox.Show("Primero busca un producto válido presionando Enter en el ID.", "Producto no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdProducto.Focus();
                txtIdProducto.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPeso.Text))
            {
                MessageBox.Show("Ingresa una cantidad o peso antes de agregar.", "Dato faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeso.Focus();
                return;
            }

            if (!decimal.TryParse(txtPeso.Text.Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal cantidadSolicitada))
            {
                MessageBox.Show("La cantidad ingresada no es válida. Usa solo números.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeso.Focus();
                txtPeso.SelectAll();
                return;
            }

            if (cantidadSolicitada <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeso.Focus();
                txtPeso.SelectAll();
                return;
            }

            var productoReal = ProductoService.BuscarPorId(txtIdProducto.Text.Trim());

            if (productoReal == null)
            {
                MessageBox.Show("El producto ya no existe o el ID es inválido.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdProducto.Focus();
                txtIdProducto.SelectAll();
                return;
            }

            if (productoReal.UnidadMedida == "PZA")
            {
                if (cantidadSolicitada % 1 != 0)
                {
                    MessageBox.Show("Este producto se vende por PIEZAS enteras.\nNo puedes registrar decimales.",
                        "Error de Captura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPeso.Focus();
                    txtPeso.SelectAll();
                    return;
                }
            }

            if (cantidadSolicitada > productoReal.Stock)
            {
                string unidadTexto = "kg";
                string stockFormat = productoReal.Stock.ToString("N3");

                if (productoReal.UnidadMedida == "PZA")
                {
                    unidadTexto = "pzas";
                    stockFormat = ((int)productoReal.Stock).ToString();
                }

                MessageBox.Show($"¡No hay suficiente producto!\nStock disponible: {stockFormat} {unidadTexto}",
                    "Inventario Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPeso.Focus();
                txtPeso.SelectAll();
                return;
            }

            decimal precio = productoReal.Precio;
            decimal subtotal = precio * cantidadSolicitada;

            string cantidadCarrito = cantidadSolicitada.ToString("N3") + " KG";

            if (productoReal.UnidadMedida == "PZA")
            {
                cantidadCarrito = cantidadSolicitada.ToString("N0") + " PZA";
            }

            dgvVenta.Rows.Add(txtIdProducto.Text, lblNombreProducto.Text, cantidadCarrito, precio.ToString("C2"), subtotal.ToString("C2"));
            ActualizarTotalVenta();
            LimpiarSoloBuscador();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvVenta.SelectedRows.Count > 0)
            {
                dgvVenta.Rows.RemoveAt(dgvVenta.SelectedRows[0].Index);
                ActualizarTotalVenta();
            }
            else
            {
                MessageBox.Show("Selecciona un producto del carrito para quitarlo.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                if (dgvVenta.Rows.Count == 0)
                {
                    throw new InvalidOperationException("No puedes cobrar una venta vacía. Agrega al menos un producto.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdProducto.Focus();
                return;
            }

            decimal totalCobrar = 0;

            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                string subtotalTexto = row.Cells["colSubtotal"].Value?.ToString() ?? "0";

                if (decimal.TryParse(subtotalTexto, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal subtotalNum))
                {
                    totalCobrar += subtotalNum;
                }
            }

            List<ConsumoProducto> consumoPorProducto = ObtenerConsumoPorProducto();

            foreach (var consumo in consumoPorProducto)
            {
                var producto = ProductoService.BuscarPorId(consumo.Id);
                bool stockInsuficiente = false;

                if (producto == null)
                {
                    stockInsuficiente = true;
                }
                else
                {
                    if (producto.Stock < consumo.Cantidad)
                    {
                        stockInsuficiente = true;
                    }
                }

                if (stockInsuficiente)
                {
                    string disponible = "0";

                    if (producto != null)
                    {
                        disponible = producto.Stock.ToString("N3");

                        if (producto.UnidadMedida == "PZA")
                        {
                            disponible = ((int)producto.Stock).ToString();
                        }
                    }

                    // EXCEPCIONES
                    try
                    {
                        throw new InvalidOperationException($"No hay stock suficiente para cobrar.\nProducto: {consumo.Id}\nDisponible: {disponible}\nSolicitado: {consumo.Cantidad:N3}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Inventario insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // INSTANCIACIÓN DE CLASES PROPIAS
            FrmCobro ventanaCobro = new FrmCobro(totalCobrar);
            ventanaCobro.ShowDialog();

            if (!ventanaCobro.VentaExitosa)
            {
                return;
            }

            string metodoElegido = ventanaCobro.MetodoPagoSeleccionado;

            // EXCEPCIONES
            try
            {
                foreach (DataGridViewRow row in dgvVenta.Rows)
                {
                    string id = row.Cells["colIDproducto"].Value?.ToString() ?? string.Empty;
                    decimal kg = ObtenerCantidadDeFila(row);

                    if (kg > 0)
                    {
                        string nombreProd = row.Cells["colProducto"].Value?.ToString() ?? "";
                        string subtotalTexto = row.Cells["colSubtotal"].Value?.ToString() ?? "0";

                        decimal.TryParse(subtotalTexto, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal subtotalNum);

                        if (!ProductoService.RestarStock(id, kg))
                        {
                            // EXCEPCIONES
                            throw new InvalidOperationException($"No se pudo descontar el stock del producto {id}.");
                        }

                        var productoReal = ProductoService.BuscarPorId(id);
                        string categoriaProd = "Otros";

                        if (productoReal != null)
                        {
                            categoriaProd = productoReal.Categoria;
                        }

                        // INSTANCIACIÓN DE CLASES PROPIAS
                        Venta nuevaVenta = new Venta
                        {
                            IdProducto = id,
                            FechaHora = DateTime.Now,
                            NombreProducto = nombreProd,
                            Categoria = categoriaProd,
                            KilosVendidos = kg,
                            TotalPagado = subtotalNum,
                            Vendedor = _usuarioActual.Nombre,
                            MetodoPago = metodoElegido
                        };

                        VentaService.RegistrarVenta(nuevaVenta);
                    }
                }

                MessageBox.Show("Venta cobrada con éxito. Inventario y caja actualizados.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTodoElPuntoDeVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el cobro: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                if (dgvVenta.Rows.Count == 0)
                {
                    throw new InvalidOperationException("No hay una venta activa para cancelar. El carrito está vacío.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdProducto.Focus();
                return;
            }

            if (MessageBox.Show("¿Cancelar venta y vaciar el carrito?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarTodoElPuntoDeVenta();
            }
        }

        private void ActualizarTotalVenta()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                string subtotalStr = row.Cells["colSubtotal"].Value?.ToString() ?? "0";

                if (decimal.TryParse(subtotalStr, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal sub))
                {
                    total += sub;
                }
            }

            lblTotal.Text = "TOTAL: " + total.ToString("C2");
        }

        // SOBRECARGA 
        private IProducto BuscarProductoPorEntrada(string entrada)
        {
            // HERENCIA DE INTERFACES
            List<IProducto> productos = ProductoService.ObtenerTodos();

            return BuscarProductoPorEntrada(entrada, productos);
        }

        // SOBRECARGA
        private IProducto BuscarProductoPorEntrada(string entrada, List<IProducto> productos)
        {
            // HERENCIA DE INTERFACES
            foreach (IProducto producto in productos)
            {
                if (producto.Id.Equals(entrada, StringComparison.OrdinalIgnoreCase))
                {
                    return producto;
                }

                if (producto.Nombre.Equals(entrada, StringComparison.OrdinalIgnoreCase))
                {
                    return producto;
                }
            }

            return null;
        }

        private List<ConsumoProducto> ObtenerConsumoPorProducto()
        {
            // INSTANCIACIÓN DE CLASES PROPIAS
            List<ConsumoProducto> consumos = new List<ConsumoProducto>();

            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                string id = "";

                if (row.Cells["colIDproducto"].Value != null)
                {
                    id = row.Cells["colIDproducto"].Value.ToString();
                }

                if (string.IsNullOrWhiteSpace(id))
                {
                    continue;
                }

                ConsumoProducto consumo = BuscarConsumo(consumos, id);

                if (consumo == null)
                {
                    // INSTANCIACIÓN DE CLASES PROPIAS
                    consumo = new ConsumoProducto();
                    consumo.Id = id;
                    consumo.Cantidad = 0;
                    consumos.Add(consumo);
                }

                consumo.Cantidad += ObtenerCantidadDeFila(row);
            }

            return consumos;
        }

        private ConsumoProducto BuscarConsumo(List<ConsumoProducto> consumos, string id)
        {
            foreach (ConsumoProducto consumo in consumos)
            {
                if (consumo.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return consumo;
                }
            }

            return null;
        }

        // SOBRECARGA 
        private decimal ObtenerCantidadDeFila(DataGridViewRow row)
        {
            string cantStr = row.Cells["colKG"].Value?.ToString() ?? "0";

            return ObtenerCantidadDeFila(cantStr);
        }

        // SOBRECARGA
        private decimal ObtenerCantidadDeFila(string cantStr)
        {
            cantStr = cantStr.Replace("KG", "").Replace("PZA", "").Trim();

            if (decimal.TryParse(cantStr, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal cantidad))
            {
                return cantidad;
            }

            if (decimal.TryParse(cantStr, NumberStyles.Number, CultureInfo.InvariantCulture, out cantidad))
            {
                return cantidad;
            }

            return 0;
        }

        private void LimpiarSoloBuscador()
        {
            txtIdProducto.Clear();
            txtPeso.Text = "";
            lblNombreProducto.Text = "-";
            lblPrecioProducto.Text = "0.00";
            lblStock.Text = "En Stock: 0.000 kg";
            lblCategoria.Text = "Categoría: -";
            lblEstadoProducto.Text = "Esperando ID...";
            lblEstadoProducto.ForeColor = Color.DarkGray;
            txtIdProducto.Focus();
        }

        private void LimpiarTodoElPuntoDeVenta()
        {
            dgvVenta.Rows.Clear();
            lblTotal.Text = "TOTAL: $0.00";
            LimpiarSoloBuscador();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                if (dgvVenta.Rows.Count > 0)
                {
                    btnCobrar.PerformClick();
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}