using Carniceria.Interfaces;
using Carniceria.Services;
using Carniceria.Views.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Carniceria.Views
{
    // HERENCIA DE CLASES
    public partial class UC_Inventario : UserControl
    {
        // HERENCIA DE INTERFACES
        private IUsuario _usuarioActual;

        // HERENCIA DE INTERFACES
        public UC_Inventario(IUsuario usuario)
        {
            InitializeComponent();

            _usuarioActual = usuario;

            ConfigurarUI();
            CargarTablas();

            if (_usuarioActual.GetType().Name == "Empleado")
            {
                btnAgregarProducto.Visible = false;
                btnModificarProducto.Visible = false;
                btnRegistrarMerma.Visible = true;
                btnRegistrarMerma.Enabled = true;
                tcCategorias.TabPages.Remove(tpResumen);
            }

            tcCategorias.SelectedIndexChanged += tcCategorias_SelectedIndexChanged;
        }

        private void ConfigurarUI()
        {
            DoubleBuffered = true;

            DataGridView[] tablas = { dgvRes, dgvCerdo, dgvOtros, dgvMermas };

            foreach (var tabla in tablas)
            {
                tabla.AllowUserToOrderColumns = false;
                tabla.AllowUserToResizeColumns = false;
                tabla.AllowUserToResizeRows = false;

                tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                tabla.BackgroundColor = Color.FromArgb(30, 30, 30);
                tabla.BorderStyle = BorderStyle.None;
                tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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

                tabla.SelectionChanged += tabla_SelectionChanged;
            }

            foreach (TabPage tab in tcCategorias.TabPages)
            {
                tab.BackColor = Color.FromArgb(30, 30, 30);
            }
        }

        private void tcCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCategorias.SelectedTab != tpGrafica)
            {
                return;
            }

            ActualizarGrafica();
        }

        private void tabla_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView tabla = sender as DataGridView;

            if (tabla == null)
            {
                return;
            }

            tabla.ClearSelection();
        }

        public void CargarTablas()
        {
            dgvRes.Rows.Clear();
            dgvCerdo.Rows.Clear();
            dgvOtros.Rows.Clear();
            dgvMermas.Rows.Clear();

            var todosLosProductos = ProductoService.ObtenerTodos();

            foreach (var p in todosLosProductos)
            {
                DataGridView dgvActual = ObtenerTablaPorCategoria(p.Categoria);

                if (dgvActual == null)
                {
                    continue;
                }

                string stockVisual = FormatearCantidad(p.Stock, p.UnidadMedida);
                int n = dgvActual.Rows.Add(p.Id, p.Nombre, p.Categoria, p.Precio.ToString("C2"), stockVisual);
                DataGridViewRow fila = dgvActual.Rows[n];

                AplicarColorPorStock(fila, p.Stock);
            }

            CargarHistorialMermas();
            ActualizarDashboardGlobal();
        }

        private DataGridView ObtenerTablaPorCategoria(string categoria)
        {
            categoria = categoria.Trim();

            if (categoria.Equals("Res", StringComparison.OrdinalIgnoreCase))
            {
                return dgvRes;
            }

            if (categoria.Equals("Cerdo", StringComparison.OrdinalIgnoreCase))
            {
                return dgvCerdo;
            }

            return dgvOtros;
        }

        private void AplicarColorPorStock(DataGridViewRow fila, decimal stock)
        {
            if (stock < 10.0m)
            {
                fila.DefaultCellStyle.ForeColor = Color.FromArgb(255, 80, 80);
                return;
            }

            if (stock < 50.0m)
            {
                fila.DefaultCellStyle.ForeColor = Color.FromArgb(255, 200, 0);
                return;
            }

            fila.DefaultCellStyle.ForeColor = Color.White;
        }

        private void CargarHistorialMermas()
        {
            var mermas = MermaService.ObtenerTodas();

            foreach (var m in mermas)
            {
                dgvMermas.Rows.Add(
                    m.Fecha.ToString("dd/MM/yyyy HH:mm"),
                    m.IdProducto,
                    m.NombreProducto,
                    FormatearCantidad(m.PesoBruto, m.UnidadMedida),
                    FormatearCantidad(m.PesoNeto, m.UnidadMedida),
                    FormatearCantidad(m.CantidadMerma, m.UnidadMedida),
                    m.ValorPerdido.ToString("C2"),
                    m.Notas
                );
            }
        }

        private void ActualizarDashboardGlobal()
        {
            var inventario = ProductoService.ObtenerTodos();

            if (inventario == null)
            {
                return;
            }

            if (inventario.Count == 0)
            {
                return;
            }

            decimal kilosRes = 0;
            decimal kilosCerdo = 0;
            decimal kilosOtros = 0;
            decimal piezasOtros = 0;

            decimal valorRes = 0;
            decimal valorCerdo = 0;
            decimal valorOtros = 0;
            decimal valorTotal = 0;

            foreach (var p in inventario)
            {
                decimal valorProducto = p.Stock * p.Precio;
                valorTotal += valorProducto;

                if (p.Categoria.Equals("Res", StringComparison.OrdinalIgnoreCase))
                {
                    kilosRes += p.Stock;
                    valorRes += valorProducto;
                    continue;
                }

                if (p.Categoria.Equals("Cerdo", StringComparison.OrdinalIgnoreCase))
                {
                    kilosCerdo += p.Stock;
                    valorCerdo += valorProducto;
                    continue;
                }

                valorOtros += valorProducto;

                if (p.UnidadMedida == "PZA")
                {
                    piezasOtros += p.Stock;
                }
                else
                {
                    kilosOtros += p.Stock;
                }
            }

            lblKilosRes.Text = $"🐑 Res: {kilosRes:N2} KG   \nVALOR TOTAL: {valorRes:C2}";
            lblKilosCerdo.Text = $"🐖 Cerdo: {kilosCerdo:N2} KG   \nVALOR TOTAL: {valorCerdo:C2}";
            lblKilosOtros.Text = $"📦 Otros: {kilosOtros:N2} KG | {(int)piezasOtros} PZAS   \nVALOR TOTAL: {valorOtros:C2}";
            lblTotalDineroValor.Text = valorTotal.ToString("C2");
        }

        private void btnFiltroGlobal_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("Todos");
        }

        private void btnFiltroRes_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("Res");
        }

        private void btnFiltroCerdo_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("Cerdo");
        }

        private void btnFiltroOtros_Click(object sender, EventArgs e)
        {
            ActualizarGrafica("Otros");
        }

        // SOBRECARGA
        private void ActualizarGrafica(string categoriaFiltro = "Todos")
        {
            // GRÁFICOS
            chartStock.Series.Clear();
            chartStock.ChartAreas.Clear();
            chartStock.Titles.Clear();
            chartStock.Legends.Clear();

            chartStock.BackColor = Color.FromArgb(30, 30, 30);

            // GRÁFICOS
            ChartArea area = new ChartArea("MainArea")
            {
                BackColor = Color.FromArgb(20, 30, 50)
            };

            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisX.LabelStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            area.AxisX.LineColor = Color.White;
            area.AxisX.Interval = 1;
            area.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;

            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.Font = new Font("Arial", 12F);
            area.AxisY.LineColor = Color.White;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(50, Color.White);

            chartStock.ChartAreas.Add(area);

            // GRÁFICOS
            Legend leyenda = new Legend("Semaforo")
            {
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Bold),
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center
            };

            leyenda.CustomItems.Add(Color.FromArgb(255, 80, 80), "Crítico (MENOR A 10)");
            leyenda.CustomItems.Add(Color.FromArgb(255, 200, 0), "Preventivo (MENOR A 50)");

            chartStock.Legends.Add(leyenda);

            // GRÁFICOS
            Title titulo = new Title(
                $"ALERTA DE REABASTECIMIENTO: {categoriaFiltro.ToUpper()}",
                Docking.Top,
                new Font("Arial Rounded MT Bold", 18F, FontStyle.Bold),
                Color.White);

            chartStock.Titles.Add(titulo);

            // GRÁFICOS
            Series serie = new Series("Existencias")
            {
                ChartType = SeriesChartType.Column,
                IsXValueIndexed = true,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                Font = new Font("Arial", 11F, FontStyle.Bold),
                IsVisibleInLegend = false
            };

            serie["PointWidth"] = "0.6";
            chartStock.Series.Add(serie);

            List<IProducto> productos = ProductoService.ObtenerTodos();
            List<IProducto> listaAlerta = new List<IProducto>();

            foreach (IProducto p in productos)
            {
                if (!ProductoCumpleFiltro(p, categoriaFiltro))
                {
                    continue;
                }

                if (p.Stock < 50.0m)
                {
                    listaAlerta.Add(p);
                }
            }

            listaAlerta.Sort(CompararStock);

            if (listaAlerta.Count == 0)
            {
                chartStock.Titles.Clear();
                chartStock.Titles.Add("SIN PRODUCTOS EN ALERTA").ForeColor = Color.White;
                return;
            }

            foreach (var p in listaAlerta)
            {
                // GRÁFICOS
                int i = serie.Points.AddXY(p.Nombre, (double)p.Stock);

                if (p.Stock < 10.0m)
                {
                    serie.Points[i].Color = Color.FromArgb(255, 80, 80);
                }
                else
                {
                    serie.Points[i].Color = Color.FromArgb(255, 200, 0);
                }
            }
        }

        private bool ProductoCumpleFiltro(IProducto producto, string categoriaFiltro)
        {
            if (categoriaFiltro == "Todos")
            {
                return true;
            }

            if (categoriaFiltro == "Res")
            {
                return producto.Categoria.Equals("Res", StringComparison.OrdinalIgnoreCase);
            }

            if (categoriaFiltro == "Cerdo")
            {
                return producto.Categoria.Equals("Cerdo", StringComparison.OrdinalIgnoreCase);
            }

            if (categoriaFiltro == "Otros")
            {
                bool esRes = producto.Categoria.Equals("Res", StringComparison.OrdinalIgnoreCase);
                bool esCerdo = producto.Categoria.Equals("Cerdo", StringComparison.OrdinalIgnoreCase);

                return !esRes && !esCerdo;
            }

            return false;
        }

        private int CompararStock(IProducto primero, IProducto segundo)
        {
            return primero.Stock.CompareTo(segundo.Stock);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                // INSTANCIACIÓN DE CLASES PROPIAS
                FrmProducto frmAdd = new FrmProducto();

                if (frmAdd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                CargarTablas();

                if (tcCategorias.SelectedTab == tpGrafica)
                {
                    ActualizarGrafica();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el formulario de producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                // INSTANCIACIÓN DE CLASES PROPIAS
                FrmPedirID frmBuscar = new FrmPedirID();

                if (frmBuscar.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var productoAEditar = ProductoService.BuscarPorId(frmBuscar.IdEncontrado);

                if (productoAEditar == null)
                {
                    MessageBox.Show("No se pudo cargar el producto para modificar.", "Producto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // INSTANCIACIÓN DE CLASES PROPIAS
                // SOBRECARGA
                FrmProducto frmEdit = new FrmProducto(productoAEditar);

                if (frmEdit.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                CargarTablas();

                if (tcCategorias.SelectedTab == tpGrafica)
                {
                    ActualizarGrafica();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarMerma_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                // INSTANCIACIÓN DE CLASES PROPIAS
                using (FrmMerma frmMerma = new FrmMerma())
                {
                    if (frmMerma.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    CargarTablas();

                    tcCategorias.SelectedTab = tpMermas;
                    dgvMermas.Refresh();

                    if (tcCategorias.SelectedTab == tpGrafica)
                    {
                        ActualizarGrafica();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la merma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatearCantidad(decimal cantidad, string unidad)
        {
            if (unidad == "PZA")
            {
                return cantidad.ToString("N0") + " PZA";
            }

            return cantidad.ToString("N3") + " KG";
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}