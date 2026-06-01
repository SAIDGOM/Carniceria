using Carniceria.Interfaces;
using Carniceria.Models;
using Carniceria.Services;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PdfImage = iTextSharp.text.Image;

namespace Carniceria.Views
{
    // HERENCIA DE CLASES
    public partial class UC_CorteCaja : UserControl
    {
        // HERENCIA DE INTERFACES
        private readonly IUsuario _usuarioActual;

        private List<Venta> _todasLasVentas = new List<Venta>();
        private List<Merma> _todasLasMermas = new List<Merma>();

        // INSTANCIACIÓN DE CLASES PROPIAS
        private FondoCaja _fondoActual = new FondoCaja();

        // HERENCIA DE INTERFACES
        public UC_CorteCaja(IUsuario usuario)
        {
            InitializeComponent();

            _usuarioActual = usuario;
            DoubleBuffered = true;

            ConfigurarTablas();
            ConfigurarTabControl();
            CargarTodo();

            tcCorteCaja.SelectedIndexChanged += TcCorteCaja_SelectedIndexChanged;
        }

        private void ConfigurarTablas()
        {
            ConfigurarTablaBase(dgvVentasDia);
            dgvVentasDia.Columns.Clear();
            dgvVentasDia.Columns.Add("Hora", "HORA");
            dgvVentasDia.Columns.Add("IdProducto", "ID PRODUCTO");
            dgvVentasDia.Columns.Add("Producto", "PRODUCTO");
            dgvVentasDia.Columns.Add("Cantidad", "CANTIDAD");
            dgvVentasDia.Columns.Add("MetodoPago", "PAGO");
            dgvVentasDia.Columns.Add("Total", "TOTAL");

            ConfigurarTablaBase(dgvMermasDia);
            dgvMermasDia.Columns.Clear();
            dgvMermasDia.Columns.Add("Hora", "HORA");
            dgvMermasDia.Columns.Add("IdProducto", "ID PRODUCTO");
            dgvMermasDia.Columns.Add("Producto", "PRODUCTO");
            dgvMermasDia.Columns.Add("Bruto", "BRUTO");
            dgvMermasDia.Columns.Add("Neto", "NETO");
            dgvMermasDia.Columns.Add("Merma", "MERMA");
            dgvMermasDia.Columns.Add("Valor", "PÉRDIDA");
            dgvMermasDia.Columns.Add("Notas", "NOTAS");

            ConfigurarTablaBase(dgvVentasMes);
            dgvVentasMes.Columns.Clear();
            dgvVentasMes.Columns.Add("Fecha", "FECHA");
            dgvVentasMes.Columns.Add("IdProducto", "ID PRODUCTO");
            dgvVentasMes.Columns.Add("Producto", "PRODUCTO");
            dgvVentasMes.Columns.Add("MetodoPago", "PAGO");
            dgvVentasMes.Columns.Add("Total", "TOTAL");
        }

        private void ConfigurarTablaBase(DataGridView tabla)
        {
            tabla.AllowUserToOrderColumns = false;
            tabla.AllowUserToResizeColumns = false;
            tabla.AllowUserToResizeRows = false;
            tabla.MultiSelect = false;
            tabla.ReadOnly = true;
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.EnableHeadersVisualStyles = true;

            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tabla.BorderStyle = BorderStyle.None;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabla.GridColor = System.Drawing.Color.FromArgb(50, 50, 50);
            tabla.RowHeadersVisible = false;
            tabla.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            tabla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle();

            tabla.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tabla.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            tabla.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            tabla.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            tabla.DefaultCellStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            tabla.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            tabla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tabla.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            tabla.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            tabla.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            tabla.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            tabla.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            tabla.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            tabla.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            tabla.SelectionChanged += (s, e) =>
            {
                ((DataGridView)s).ClearSelection();
            };
        }

        private void ConfigurarTabControl()
        {
            tcCorteCaja.DrawMode = TabDrawMode.Normal;
            tcCorteCaja.SizeMode = TabSizeMode.Fixed;
            tcCorteCaja.ItemSize = new System.Drawing.Size(220, 50);

            foreach (TabPage tab in tcCorteCaja.TabPages)
            {
                tab.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            }
        }

        private void CargarTodo()
        {
            _todasLasVentas = VentaService.ObtenerTodas();
            _todasLasMermas = MermaService.ObtenerTodas();
            _fondoActual = CajaService.ObtenerFondo();

            nudFondoInicial.Value = AjustarValorNumeric(_fondoActual.MontoInicial);

            CargarCorteDia();
            CargarMermasDia();
            CargarHistorialMensual();
            PrepararGraficasVacias("Abre esta pestaña para cargar el análisis.");
        }

        private void TcCorteCaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            _todasLasVentas = VentaService.ObtenerTodas();
            _todasLasMermas = MermaService.ObtenerTodas();

            if (tcCorteCaja.SelectedTab == tpCorteDia)
            {
                CargarCorteDia();
                return;
            }

            if (tcCorteCaja.SelectedTab == tpMermasDia)
            {
                CargarMermasDia();
                return;
            }

            if (tcCorteCaja.SelectedTab == tpHistorialMes)
            {
                CargarHistorialMensual();
                return;
            }

            if (tcCorteCaja.SelectedTab == tpEstadisticas)
            {
                CargarEstadisticas();
            }
        }

        private void CargarCorteDia()
        {
            dgvVentasDia.Rows.Clear();

            var ventasHoy = _todasLasVentas
                .Where(v => v.FechaHora.Date == DateTime.Now.Date)
                .OrderBy(v => v.FechaHora)
                .ToList();

            foreach (var venta in ventasHoy)
            {
                var producto = ProductoService.BuscarPorId(venta.IdProducto);
                string unidad = producto?.UnidadMedida ?? "KG";
                string cantidad;

                if (unidad == "PZA")
                {
                    cantidad = $"{venta.KilosVendidos:N0} PZA";
                }
                else
                {
                    cantidad = $"{venta.KilosVendidos:N3} KG";
                }

                string metodoPago = venta.MetodoPago;

                if (string.IsNullOrWhiteSpace(metodoPago))
                {
                    metodoPago = "Efectivo";
                }

                dgvVentasDia.Rows.Add(
                    venta.FechaHora.ToString("hh:mm tt"),
                    venta.IdProducto.ToUpper(),
                    venta.NombreProducto,
                    cantidad,
                    metodoPago,
                    venta.TotalPagado.ToString("C2"));
            }

            decimal ventasTotales = ventasHoy.Sum(v => v.TotalPagado);

            decimal ventasEfectivo = ventasHoy
                .Where(v => string.IsNullOrWhiteSpace(v.MetodoPago) || v.MetodoPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
                .Sum(v => v.TotalPagado);

            decimal efectivoEsperado = _fondoActual.MontoInicial + ventasEfectivo;

            lblTotalCaja.Text = ventasTotales.ToString("C2");
            lblVentasEfectivo.Text = ventasEfectivo.ToString("C2");
            lblEfectivoEsperado.Text = efectivoEsperado.ToString("C2");
        }

        private void CargarMermasDia()
        {
            dgvMermasDia.Rows.Clear();

            var mermasHoy = _todasLasMermas
                .Where(m => m.Fecha.Date == DateTime.Now.Date)
                .OrderBy(m => m.Fecha)
                .ToList();

            foreach (var merma in mermasHoy)
            {
                string unidad = merma.UnidadMedida ?? "KG";

                dgvMermasDia.Rows.Add(
                    merma.Fecha.ToString("hh:mm tt"),
                    merma.IdProducto.ToUpper(),
                    merma.NombreProducto,
                    FormatearCantidad(merma.PesoBruto, unidad),
                    FormatearCantidad(merma.PesoNeto, unidad),
                    FormatearCantidad(merma.CantidadMerma, unidad),
                    merma.ValorPerdido.ToString("C2"),
                    merma.Notas);
            }

            lblTotalMermas.Text = mermasHoy.Sum(m => m.ValorPerdido).ToString("C2");
            lblKilosMermados.Text = ResumenCantidadesMermadas(mermasHoy);
        }

        private void CargarHistorialMensual()
        {
            dgvVentasMes.Rows.Clear();

            var ventasMes = _todasLasVentas
                .Where(v => v.FechaHora.Year == dtpFiltroMes.Value.Year && v.FechaHora.Month == dtpFiltroMes.Value.Month)
                .OrderBy(v => v.FechaHora)
                .ToList();

            foreach (var venta in ventasMes)
            {
                string metodoPago = venta.MetodoPago;

                if (string.IsNullOrWhiteSpace(metodoPago))
                {
                    metodoPago = "Efectivo";
                }

                dgvVentasMes.Rows.Add(
                    venta.FechaHora.ToString("dd/MM/yyyy"),
                    venta.IdProducto.ToUpper(),
                    venta.NombreProducto,
                    metodoPago,
                    venta.TotalPagado.ToString("C2"));
            }

            lblTotalMensual.Text = ventasMes.Sum(v => v.TotalPagado).ToString("C2");
        }

        private void CargarEstadisticas()
        {
            // GRÁFICOS
            chartProductos.Series[0].Points.Clear();

            // GRÁFICOS
            chartHorarios.Series[0].Points.Clear();

            var ventasDelMes = _todasLasVentas
                .Where(v => v.FechaHora.Year == DateTime.Now.Year && v.FechaHora.Month == DateTime.Now.Month)
                .ToList();

            var ventasDeHoy = _todasLasVentas
                .Where(v => v.FechaHora.Date == DateTime.Now.Date)
                .ToList();

            if (!ventasDelMes.Any() && !ventasDeHoy.Any())
            {
                PrepararGraficasVacias("Sin ventas registradas para graficar.");
                return;
            }

            // GRÁFICOS
            chartProductos.Titles.Clear();
            chartProductos.Titles.Add($"INGRESOS POR CATEGORÍA - {DateTime.Now:MMMM yyyy}".ToUpper()).ForeColor = System.Drawing.Color.White;
            chartProductos.Series[0].IsValueShownAsLabel = true;
            chartProductos.Series[0].Label = "#VALX: $#VALY{N2}";
            chartProductos.Series[0].LabelForeColor = System.Drawing.Color.White;

            var gruposCategoria = ventasDelMes
                .GroupBy(v => v.Categoria)
                .Select(g => new { Categoria = g.Key, Total = g.Sum(v => v.TotalPagado) });

            foreach (var grupo in gruposCategoria)
            {
                // GRÁFICOS
                chartProductos.Series[0].Points.AddXY(grupo.Categoria, grupo.Total);
            }

            // GRÁFICOS
            chartHorarios.Titles.Clear();
            chartHorarios.Titles.Add($"HORARIO DE MAYOR VENTA - {DateTime.Now:dd/MM/yyyy}").ForeColor = System.Drawing.Color.White;
            chartHorarios.Series[0].IsValueShownAsLabel = true;
            chartHorarios.Series[0].Label = "$#VALY{N2}";
            chartHorarios.Series[0].LabelForeColor = System.Drawing.Color.White;

            var mayorVenta = ventasDeHoy
                .GroupBy(v => v.FechaHora.Hour)
                .Select(g => new
                {
                    Hora = g.Key,
                    Total = g.Sum(v => v.TotalPagado)
                })
                .OrderByDescending(g => g.Total)
                .FirstOrDefault();

            if (mayorVenta == null)
            {
                chartHorarios.Titles.Clear();
                chartHorarios.Titles.Add("SIN VENTAS REGISTRADAS HOY").ForeColor = System.Drawing.Color.White;
                return;
            }

            string horaMayor = new DateTime(2000, 1, 1, mayorVenta.Hora, 0, 0).ToString("h tt");

            // GRÁFICOS
            chartHorarios.Series[0].Points.AddXY(horaMayor, mayorVenta.Total);
        }
        private void PrepararGraficasVacias(string mensaje)
        {
            // GRÁFICOS
            chartProductos.Series[0].Points.Clear();

            // GRÁFICOS
            chartHorarios.Series[0].Points.Clear();

            // GRÁFICOS
            chartProductos.Titles.Clear();

            // GRÁFICOS
            chartHorarios.Titles.Clear();

            // GRÁFICOS
            chartProductos.Titles.Add(mensaje).ForeColor = System.Drawing.Color.White;

            // GRÁFICOS
            chartHorarios.Titles.Add(mensaje).ForeColor = System.Drawing.Color.White;
        }

        private bool HayFilas(DataGridView tabla)
        {
            return tabla.Rows.Cast<DataGridViewRow>().Any(row => !row.IsNewRow);
        }

        private bool HayMovimientosDia()
        {
            return HayFilas(dgvVentasDia) || HayFilas(dgvMermasDia);
        }

        private bool HayVentasMesSeleccionado()
        {
            return _todasLasVentas.Any(v => v.FechaHora.Year == dtpFiltroMes.Value.Year && v.FechaHora.Month == dtpFiltroMes.Value.Month);
        }

        private bool HayMermasMesSeleccionado()
        {
            return _todasLasMermas.Any(m => m.Fecha.Year == dtpFiltroMes.Value.Year && m.Fecha.Month == dtpFiltroMes.Value.Month);
        }

        private bool HayMovimientosMes()
        {
            return HayVentasMesSeleccionado() || HayMermasMesSeleccionado();
        }

        private bool GraficaTieneDatos(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            // GRÁFICOS
            return chart.Series.Count > 0 && chart.Series[0].Points.Count > 0;
        }

        private bool HayGraficasConDatos()
        {
            return GraficaTieneDatos(chartProductos) || GraficaTieneDatos(chartHorarios);
        }

        private void btnGuardarFondoInicial_Click(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                // INSTANCIACIÓN DE CLASES PROPIAS
                FondoCaja fondo = new FondoCaja
                {
                    Fecha = DateTime.Now.Date,
                    MontoInicial = nudFondoInicial.Value,
                    Responsable = _usuarioActual.Nombre
                };

                CajaService.GuardarFondo(fondo);

                _fondoActual = CajaService.ObtenerFondo();
                CargarCorteDia();

                MessageBox.Show("Fondo inicial guardado correctamente.", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el fondo inicial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFiltroMes_ValueChanged(object sender, EventArgs e)
        {
            CargarHistorialMensual();
        }

        private void btnImprimirCorte_Click(object sender, EventArgs e)
        {
            if (!HayMovimientosDia())
            {
                MessageBox.Show("No hay movimientos hoy para generar el corte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerarPdfDiario();
        }

        private void btnImprimirMes_Click(object sender, EventArgs e)
        {
            if (!HayMovimientosMes())
            {
                MessageBox.Show("No hay ventas ni mermas en el mes seleccionado para generar el corte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerarPdfMensual();
        }

        private void GenerarPdfDiario()
        {
            // EXCEPCIONES
            try
            {
                if (!HayMovimientosDia())
                {
                    MessageBox.Show("No hay movimientos hoy para generar el corte diario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ARCHIVOS
                string path = CrearRutaReporte("CORTES PDF", $"Corte_Diario_{DateTime.Now:yyyyMMdd}.pdf");

                // ARCHIVOS
                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (Document doc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25))
                {
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    AgregarEncabezadoPdf(doc, "CORTE DIARIO DE CAJA");
                    AgregarResumenDiarioPdf(doc);
                    AgregarTablaPdf(doc, "VENTAS DEL DÍA", dgvVentasDia);
                    AgregarTablaPdf(doc, "MERMAS DEL DÍA", dgvMermasDia);

                    doc.Close();
                }

                MessageBox.Show("Corte diario guardado en CORTES PDF.", "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el corte diario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPdfMensual()
        {
            // EXCEPCIONES
            try
            {
                if (!HayMovimientosMes())
                {
                    MessageBox.Show("No hay ventas ni mermas en el mes seleccionado para generar el corte mensual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreMes = dtpFiltroMes.Value.ToString("MMMM_yyyy", CultureInfo.CurrentCulture);

                // ARCHIVOS
                string path = CrearRutaReporte("CORTES PDF", $"Corte_Mensual_{nombreMes}.pdf");

                // ARCHIVOS
                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (Document doc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25))
                {
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    AgregarEncabezadoPdf(doc, $"CORTE MENSUAL - {dtpFiltroMes.Value:MMMM yyyy}".ToUpper());
                    AgregarResumenMensualPdf(doc);
                    AgregarTablaPdf(doc, "VENTAS DEL MES", dgvVentasMes);

                    doc.Close();
                }

                MessageBox.Show("Corte mensual guardado en CORTES PDF.", "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el corte mensual: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarEncabezadoPdf(Document doc, string titulo)
        {
            IntentarInyectarLogo(doc);

            var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, new BaseColor(0, 150, 136));
            var fontSub = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);

            doc.Add(new Paragraph(titulo, fontTitulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 8
            });

            doc.Add(new Paragraph($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy hh:mm tt}\nResponsable: {_usuarioActual.Nombre}", fontSub)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 15
            });
        }

        private void AgregarResumenDiarioPdf(Document doc)
        {
            PdfPTable tabla = new PdfPTable(4)
            {
                WidthPercentage = 100,
                SpacingAfter = 15
            };

            tabla.SetWidths(new float[] { 25f, 25f, 25f, 25f });

            AgregarCeldaResumen(tabla, "FONDO INICIAL", nudFondoInicial.Value.ToString("C2"));
            AgregarCeldaResumen(tabla, "VENTAS EFECTIVO", lblVentasEfectivo.Text);
            AgregarCeldaResumen(tabla, "VENTAS TOTALES", lblTotalCaja.Text);
            AgregarCeldaResumen(tabla, "EFECTIVO ESPERADO", lblEfectivoEsperado.Text);

            doc.Add(tabla);
        }

        private void AgregarResumenMensualPdf(Document doc)
        {
            var mermasMes = _todasLasMermas
                .Where(m => m.Fecha.Year == dtpFiltroMes.Value.Year && m.Fecha.Month == dtpFiltroMes.Value.Month)
                .ToList();

            PdfPTable tabla = new PdfPTable(3)
            {
                WidthPercentage = 100,
                SpacingAfter = 15
            };

            AgregarCeldaResumen(tabla, "VENTAS DEL MES", lblTotalMensual.Text);
            AgregarCeldaResumen(tabla, "PÉRDIDA POR MERMA", mermasMes.Sum(m => m.ValorPerdido).ToString("C2"));
            AgregarCeldaResumen(tabla, "MERMAS", ResumenCantidadesMermadas(mermasMes));

            doc.Add(tabla);
        }

        private void AgregarCeldaResumen(PdfPTable tabla, string titulo, string valor)
        {
            var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, new BaseColor(0, 105, 105));
            var fontValor = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, BaseColor.BLACK);

            PdfPCell celda = new PdfPCell
            {
                Padding = 8,
                BackgroundColor = BaseColor.WHITE,
                BorderColor = new BaseColor(0, 150, 136),
                BorderWidth = 1.2f
            };

            celda.AddElement(new Paragraph(titulo, fontTitulo)
            {
                Alignment = Element.ALIGN_CENTER
            });

            celda.AddElement(new Paragraph(valor, fontValor)
            {
                Alignment = Element.ALIGN_CENTER
            });

            tabla.AddCell(celda);
        }

        private void AgregarTablaPdf(Document doc, string titulo, DataGridView tablaFuente)
        {
            if (tablaFuente.Rows.Count == 0)
            {
                return;
            }

            var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, new BaseColor(0, 105, 105));
            var fontCabecera = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, new BaseColor(25, 25, 25));
            var fontDetalle = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);

            doc.Add(new Paragraph(titulo, fontTitulo)
            {
                SpacingBefore = 10,
                SpacingAfter = 6
            });

            PdfPTable tabla = new PdfPTable(tablaFuente.Columns.Count)
            {
                WidthPercentage = 100
            };

            if (tablaFuente.Columns.Count == 6)
            {
                tabla.SetWidths(new float[] { 12f, 15f, 33f, 15f, 13f, 12f });
            }
            else if (tablaFuente.Columns.Count == 8)
            {
                tabla.SetWidths(new float[] { 10f, 12f, 24f, 10f, 10f, 10f, 10f, 14f });
            }
            else if (tablaFuente.Columns.Count == 5)
            {
                tabla.SetWidths(new float[] { 15f, 15f, 40f, 15f, 15f });
            }

            foreach (DataGridViewColumn col in tablaFuente.Columns)
            {
                PdfPCell celdaCabecera = new PdfPCell(new Phrase(col.HeaderText, fontCabecera))
                {
                    BackgroundColor = new BaseColor(220, 245, 243),
                    BorderColor = new BaseColor(180, 180, 180),
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 5
                };

                tabla.AddCell(celdaCabecera);
            }

            int filaPdf = 0;

            foreach (DataGridViewRow row in tablaFuente.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                foreach (DataGridViewCell cell in row.Cells)
                {
                    BaseColor colorFondo;

                    if (filaPdf % 2 == 0)
                    {
                        colorFondo = BaseColor.WHITE;
                    }
                    else
                    {
                        colorFondo = new BaseColor(248, 248, 248);
                    }

                    PdfPCell celda = new PdfPCell(new Phrase(cell.Value?.ToString() ?? string.Empty, fontDetalle))
                    {
                        BackgroundColor = colorFondo,
                        BorderColor = new BaseColor(210, 210, 210),
                        Padding = 5
                    };

                    tabla.AddCell(celda);
                }

                filaPdf++;
            }

            doc.Add(tabla);
        }

        private void btnExportarExcelDia_Click(object sender, EventArgs e)
        {
            if (!HayMovimientosDia())
            {
                MessageBox.Show("No hay movimientos de hoy para exportar a Excel.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportarCorteDiarioExcel();
        }

        private void btnExportarExcelMes_Click(object sender, EventArgs e)
        {
            if (!HayMovimientosMes())
            {
                MessageBox.Show("No hay ventas ni mermas en el mes seleccionado para exportar a Excel.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportarCorteMensualExcel();
        }

        private void ExportarCorteDiarioExcel()
        {
            if (!HayMovimientosDia())
            {
                MessageBox.Show("No hay movimientos de hoy para exportar a Excel.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = $"Reporte_Corte_Diario_{DateTime.Now:yyyyMMdd}.xlsx";

            // ARCHIVOS
            using (SaveFileDialog sfd = CrearDialogoExcel(nombre))
            {
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // EXCEPCIONES
                try
                {
                    // ARCHIVOS
                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        EscribirResumenDiario(excel.Workbook.Worksheets.Add("Resumen"));
                        EscribirDataGrid(excel.Workbook.Worksheets.Add("Ventas"), dgvVentasDia, "VENTAS DEL DÍA");
                        EscribirDataGrid(excel.Workbook.Worksheets.Add("Mermas"), dgvMermasDia, "MERMAS DEL DÍA");

                        // GRÁFICOS
                        EscribirGraficaVentasPorProducto(excel.Workbook.Worksheets.Add("Gráficas"), DateTime.Now.Month, DateTime.Now.Year);

                        // ARCHIVOS
                        excel.SaveAs(new FileInfo(sfd.FileName));
                    }

                    MessageBox.Show("Corte diario exportado a Excel.", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportarCorteMensualExcel()
        {
            if (!HayMovimientosMes())
            {
                MessageBox.Show("No hay ventas ni mermas en el mes seleccionado para exportar a Excel.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreMes = dtpFiltroMes.Value.ToString("MMMM_yyyy", CultureInfo.CurrentCulture);
            string nombreArchivo = $"Reporte_Corte_Mensual_{nombreMes}.xlsx";

            // ARCHIVOS
            using (SaveFileDialog sfd = CrearDialogoExcel(nombreArchivo))
            {
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // EXCEPCIONES
                try
                {
                    // ARCHIVOS
                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        EscribirDataGrid(excel.Workbook.Worksheets.Add("Ventas"), dgvVentasMes, $"VENTAS - {dtpFiltroMes.Value:MMMM yyyy}".ToUpper());
                        EscribirMermasMes(excel.Workbook.Worksheets.Add("Mermas"));

                        // GRÁFICOS
                        EscribirGraficaVentasPorProducto(excel.Workbook.Worksheets.Add("Gráficas"), dtpFiltroMes.Value.Month, dtpFiltroMes.Value.Year);

                        // ARCHIVOS
                        excel.SaveAs(new FileInfo(sfd.FileName));
                    }

                    MessageBox.Show("Corte mensual exportado a Excel.", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private SaveFileDialog CrearDialogoExcel(string nombreArchivo)
        {
            // ARCHIVOS
            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "VENTAS CARNICERIA",
                "CORTES EXCEL");

            // ARCHIVOS
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            SaveFileDialog dialogo = new SaveFileDialog
            {
                InitialDirectory = carpeta,
                Filter = "Libro de Excel (*.xlsx)|*.xlsx",
                FileName = nombreArchivo
            };

            return dialogo;
        }

        private void EscribirResumenDiario(ExcelWorksheet ws)
        {
            ws.Cells["A1"].Value = "CORTE DIARIO DE CAJA";

            ws.Cells["A3"].Value = "Fondo inicial / cambio";
            ws.Cells["B3"].Value = nudFondoInicial.Value;

            ws.Cells["A4"].Value = "Ventas en efectivo";
            ws.Cells["B4"].Value = LeerMoneda(lblVentasEfectivo.Text);

            ws.Cells["A5"].Value = "Ventas totales";
            ws.Cells["B5"].Value = LeerMoneda(lblTotalCaja.Text);

            ws.Cells["A6"].Value = "Efectivo esperado";
            ws.Cells["B6"].Value = LeerMoneda(lblEfectivoEsperado.Text);

            ws.Cells["A8"].Value = "Pérdida por merma";
            ws.Cells["B8"].Value = LeerMoneda(lblTotalMermas.Text);

            ws.Cells["A9"].Value = "Kilos mermados";
            ws.Cells["B9"].Value = lblKilosMermados.Text;

            ws.Column(2).Style.Numberformat.Format = "$#,##0.00";

            FormatearEncabezado(ws, 1, 2);
            ws.Cells.AutoFitColumns();
        }

        private void EscribirDataGrid(ExcelWorksheet ws, DataGridView tabla, string titulo)
        {
            ws.Cells[1, 1].Value = titulo;
            FormatearEncabezado(ws, 1, tabla.Columns.Count);

            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                ws.Cells[2, i + 1].Value = tabla.Columns[i].HeaderText;
                ws.Cells[2, i + 1].Style.Font.Bold = true;
            }

            int fila = 3;

            foreach (DataGridViewRow row in tabla.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                for (int i = 0; i < tabla.Columns.Count; i++)
                {
                    ws.Cells[fila, i + 1].Value = row.Cells[i].Value?.ToString() ?? string.Empty;
                }

                fila++;
            }

            ws.Cells.AutoFitColumns();
        }

        private void EscribirMermasMes(ExcelWorksheet ws)
        {
            var mermasMes = _todasLasMermas
                .Where(m => m.Fecha.Year == dtpFiltroMes.Value.Year && m.Fecha.Month == dtpFiltroMes.Value.Month)
                .OrderBy(m => m.Fecha)
                .ToList();

            ws.Cells["A1"].Value = $"MERMAS - {dtpFiltroMes.Value:MMMM yyyy}".ToUpper();
            FormatearEncabezado(ws, 1, 8);

            string[] columnas =
            {
                "FECHA",
                "ID PRODUCTO",
                "PRODUCTO",
                "BRUTO",
                "NETO",
                "MERMA",
                "PÉRDIDA",
                "NOTAS"
            };

            for (int i = 0; i < columnas.Length; i++)
            {
                ws.Cells[2, i + 1].Value = columnas[i];
                ws.Cells[2, i + 1].Style.Font.Bold = true;
            }

            int fila = 3;

            foreach (var merma in mermasMes)
            {
                ws.Cells[fila, 1].Value = merma.Fecha;
                ws.Cells[fila, 2].Value = merma.IdProducto;
                ws.Cells[fila, 3].Value = merma.NombreProducto;
                ws.Cells[fila, 4].Value = FormatearCantidad(merma.PesoBruto, merma.UnidadMedida);
                ws.Cells[fila, 5].Value = FormatearCantidad(merma.PesoNeto, merma.UnidadMedida);
                ws.Cells[fila, 6].Value = FormatearCantidad(merma.CantidadMerma, merma.UnidadMedida);
                ws.Cells[fila, 7].Value = merma.ValorPerdido;
                ws.Cells[fila, 8].Value = merma.Notas;

                fila++;
            }

            ws.Column(1).Style.Numberformat.Format = "dd/mm/yyyy";
            ws.Column(7).Style.Numberformat.Format = "$#,##0.00";

            ws.Cells.AutoFitColumns();
        }

        private void EscribirGraficaVentasPorProducto(ExcelWorksheet ws, int mes, int anio)
        {
            // GRÁFICOS
            bool esDiario = excelWorksheetTieneResumen(ws);
            string periodo;

            if (esDiario)
            {
                periodo = "diarias";
            }
            else
            {
                periodo = $"mensuales - {dtpFiltroMes.Value:MMMM yyyy}";
            }

            IEnumerable<Venta> ventasFiltradas;
            IEnumerable<Merma> mermasFiltradas;

            if (esDiario)
            {
                ventasFiltradas = _todasLasVentas.Where(v => v.FechaHora.Date == DateTime.Now.Date);
                mermasFiltradas = _todasLasMermas.Where(m => m.Fecha.Date == DateTime.Now.Date);
            }
            else
            {
                ventasFiltradas = _todasLasVentas.Where(v => v.FechaHora.Year == anio && v.FechaHora.Month == mes);
                mermasFiltradas = _todasLasMermas.Where(m => m.Fecha.Year == anio && m.Fecha.Month == mes);
            }

            var ventas = ventasFiltradas
                .GroupBy(v => v.NombreProducto)
                .Select(g => new { Producto = g.Key, Total = g.Sum(v => v.TotalPagado) })
                .OrderByDescending(x => x.Total)
                .ToList();

            var mermas = mermasFiltradas
                .GroupBy(m => m.NombreProducto)
                .Select(g => new { Producto = g.Key, Total = g.Sum(m => m.ValorPerdido) })
                .OrderByDescending(x => x.Total)
                .ToList();

            ws.View.ShowGridLines = false;
            ws.Cells["A1"].Value = $"Graficas {periodo}";
            ws.Cells["A1"].Style.Font.Bold = true;
            ws.Cells["A1"].Style.Font.Size = 14;

            int ultimaVenta = EscribirDatosGrafica(ws, ventas, 26, "Producto", "Ingresos");
            int ultimaMerma = EscribirDatosGrafica(ws, mermas, 29, "Producto", "Perdida");

            // GRÁFICOS
            AgregarGraficaBarrasExcel(
                ws,
                "GraficaVentas",
                $"Ventas por producto ({periodo})",
                ws.Cells[2, 27, ultimaVenta, 27],
                ws.Cells[2, 26, ultimaVenta, 26],
                1,
                0);

            // GRÁFICOS
            AgregarGraficaBarrasExcel(
                ws,
                "GraficaMermas",
                $"Mermas por producto ({periodo})",
                ws.Cells[2, 30, ultimaMerma, 30],
                ws.Cells[2, 29, ultimaMerma, 29],
                24,
                0);
        }

        private bool excelWorksheetTieneResumen(ExcelWorksheet ws)
        {
            return ws.Workbook.Worksheets.Any(hoja => hoja.Name.Equals("Resumen", StringComparison.OrdinalIgnoreCase));
        }

        private int EscribirDatosGrafica<T>(ExcelWorksheet ws, List<T> datos, int columnaInicio, string tituloCategoria, string tituloValor)
        {
            ws.Cells[1, columnaInicio].Value = tituloCategoria;
            ws.Cells[1, columnaInicio + 1].Value = tituloValor;

            int fila = 2;

            foreach (dynamic item in datos)
            {
                ws.Cells[fila, columnaInicio].Value = item.Producto;
                ws.Cells[fila, columnaInicio + 1].Value = item.Total;

                fila++;
            }

            if (fila == 2)
            {
                ws.Cells[fila, columnaInicio].Value = "Sin datos";
                ws.Cells[fila, columnaInicio + 1].Value = 0;

                fila++;
            }

            ws.Column(columnaInicio + 1).Style.Numberformat.Format = "$#,##0.00";

            return fila - 1;
        }

        private void AgregarGraficaBarrasExcel(ExcelWorksheet ws, string nombre, string titulo, ExcelRange valores, ExcelRange categorias, int fila, int columna)
        {
            // GRÁFICOS
            var chart = (ExcelBarChart)ws.Drawings.AddChart(nombre, eChartType.ColumnClustered);

            // GRÁFICOS
            chart.Title.Text = titulo;
            chart.SetPosition(fila, 0, columna, 0);
            chart.SetSize(760, 420);

            var serie = chart.Series.Add(valores, categorias);
            serie.Header = titulo.StartsWith("Mermas", StringComparison.OrdinalIgnoreCase)
                ? "Pérdida MNX"
                : "Ingresos MNX";

            chart.DataLabel.ShowValue = true;
            chart.YAxis.Format = "$#,##0.00";
        }

        private void FormatearEncabezado(ExcelWorksheet ws, int fila, int columnas)
        {
            var rango = ws.Cells[fila, 1, fila, columnas];

            rango.Merge = true;
            rango.Style.Font.Bold = true;
            rango.Style.Font.Color.SetColor(System.Drawing.Color.White);
            rango.Style.Fill.PatternType = ExcelFillStyle.Solid;
            rango.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(0, 150, 136));
            rango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        private void btnImprimirGraficas_Click(object sender, EventArgs e)
        {
            // GRÁFICOS
            CargarEstadisticas();

            if (!HayGraficasConDatos())
            {
                MessageBox.Show("No hay datos para generar el reporte de gráficas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                string path = CrearRutaReporte("CORTES PDF", $"Analisis_Grafico_{DateTime.Now:yyyyMMdd}.pdf");

                // ARCHIVOS
                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (Document doc = new Document(PageSize.A4, 25, 25, 30, 30))
                {
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    AgregarEncabezadoPdf(doc, "REPORTE GRÁFICO DE VENTAS");

                    if (GraficaTieneDatos(chartProductos))
                    {
                        // GRÁFICOS
                        AgregarGraficaPdf(doc, chartProductos);
                    }

                    if (GraficaTieneDatos(chartHorarios))
                    {
                        // GRÁFICOS
                        AgregarGraficaPdf(doc, chartHorarios);
                    }

                    doc.Close();
                }

                MessageBox.Show("Reporte gráfico guardado en CORTES PDF.", "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar las gráficas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarGraficasImagen_Click(object sender, EventArgs e)
        {
            // GRÁFICOS
            CargarEstadisticas();

            if (!HayGraficasConDatos())
            {
                MessageBox.Show("No hay datos para guardar gráficas como imagen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "VENTAS CARNICERIA",
                    "GRAFICAS");

                // ARCHIVOS
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (GraficaTieneDatos(chartProductos))
                {
                    // ARCHIVOS
                    string rutaProductos = Path.Combine(carpeta, $"Grafica_Categorias_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                    // GRÁFICOS
                    chartProductos.SaveImage(rutaProductos, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }

                if (GraficaTieneDatos(chartHorarios))
                {
                    // ARCHIVOS
                    string rutaHorarios = Path.Combine(carpeta, $"Grafica_Horarios_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                    // GRÁFICOS
                    chartHorarios.SaveImage(rutaHorarios, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }

                MessageBox.Show("Gráficas guardadas como imágenes.", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar las imágenes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarGraficaPdf(Document doc, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            // GRÁFICOS
            using (MemoryStream ms = new MemoryStream())
            {
                // GRÁFICOS
                chart.SaveImage(ms, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

                PdfImage imagen = PdfImage.GetInstance(ms.ToArray());
                imagen.ScaleToFit(500f, 300f);
                imagen.Alignment = Element.ALIGN_CENTER;
                imagen.SpacingAfter = 20;

                doc.Add(imagen);
            }
        }

        private string PedirContrasena()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 220;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Autorización Requerida";
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label etiqueta = new Label
                {
                    Left = 20,
                    Top = 20,
                    Width = 350,
                    Text = "Ingrese la contraseña para continuar:",
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F)
                };

                TextBox caja = new TextBox
                {
                    Left = 20,
                    Top = 60,
                    Width = 340,
                    UseSystemPasswordChar = true,
                    Font = new System.Drawing.Font("Arial", 14F)
                };

                Button aceptar = new Button
                {
                    Text = "Aceptar",
                    Left = 260,
                    Width = 100,
                    Top = 110,
                    DialogResult = DialogResult.OK,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = System.Drawing.Color.White,
                    BackColor = System.Drawing.Color.Crimson
                };

                prompt.Controls.Add(etiqueta);
                prompt.Controls.Add(caja);
                prompt.Controls.Add(aceptar);
                prompt.AcceptButton = aceptar;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    return caja.Text;
                }

                return string.Empty;
            }
        }

        private void btnBorrarHistorial_Click(object sender, EventArgs e)
        {
            string input = PedirContrasena();

            if (input != "Dueño2026")
            {
                if (!string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Contraseña incorrecta.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas borrar el historial de ventas?\nSe creará un respaldo antes de borrar.",
                "Confirmar borrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                string respaldo = VentaService.LimpiarHistorialConRespaldo();

                MessageBox.Show(
                    "Historial borrado correctamente.\n\nRespaldo creado en:\n" + respaldo,
                    "Sistema limpio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _todasLasVentas = VentaService.ObtenerTodas();
                CargarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IntentarInyectarLogo(Document doc)
        {
            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Carniceria.Resources.logo_carniceria.png"))
                {
                    if (stream == null)
                    {
                        return;
                    }

                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(stream))
                    {
                        PdfImage logo = PdfImage.GetInstance(img, System.Drawing.Imaging.ImageFormat.Png);

                        logo.ScaleToFit(90f, 90f);
                        logo.Alignment = Element.ALIGN_CENTER;
                        logo.SpacingAfter = 8;

                        doc.Add(logo);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("No se pudo agregar el logo al reporte: " + ex.Message);
            }
        }

        private string CrearRutaReporte(string subcarpeta, string nombreArchivo)
        {
            // ARCHIVOS
            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "VENTAS CARNICERIA",
                subcarpeta);

            // ARCHIVOS
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            // ARCHIVOS
            return Path.Combine(carpeta, nombreArchivo);
        }

        private decimal LeerMoneda(string texto)
        {
            decimal.TryParse(texto, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal valor);
            return valor;
        }

        private string FormatearCantidad(decimal cantidad, string unidad)
        {
            if (unidad == "PZA")
            {
                return $"{cantidad:N0} PZA";
            }

            return $"{cantidad:N3} KG";
        }

        private string ResumenCantidadesMermadas(IEnumerable<Merma> mermas)
        {
            decimal kilos = mermas
                .Where(m => m.UnidadMedida != "PZA")
                .Sum(m => m.CantidadMerma);

            decimal piezas = mermas
                .Where(m => m.UnidadMedida == "PZA")
                .Sum(m => m.CantidadMerma);

            if (kilos > 0 && piezas > 0)
            {
                return $"{kilos:N3} KG / {piezas:N0} PZA";
            }

            if (piezas > 0)
            {
                return $"{piezas:N0} PZA";
            }

            return $"{kilos:N3} KG";
        }

        private decimal AjustarValorNumeric(decimal valor)
        {
            if (valor < nudFondoInicial.Minimum)
            {
                return nudFondoInicial.Minimum;
            }

            if (valor > nudFondoInicial.Maximum)
            {
                return nudFondoInicial.Maximum;
            }

            return valor;
        }
    }
}