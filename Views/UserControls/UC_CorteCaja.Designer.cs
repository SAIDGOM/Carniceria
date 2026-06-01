using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    partial class UC_CorteCaja
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlContenedorTab = new Panel();
            tcCorteCaja = new TabControl();
            tpCorteDia = new TabPage();
            btnExportarExcelDia = new Button();
            btnImprimirCorte = new Button();
            btnGuardarFondoInicial = new Button();
            nudFondoInicial = new NumericUpDown();
            lblEfectivoEsperado = new Label();
            lblTituloEfectivoEsperado = new Label();
            lblVentasEfectivo = new Label();
            lblTituloVentasEfectivo = new Label();
            lblTituloFondoInicial = new Label();
            lblTotalCaja = new Label();
            lblTituloTotal = new Label();
            dgvVentasDia = new DataGridView();
            tpMermasDia = new TabPage();
            lblKilosMermados = new Label();
            lblTituloKilosMermados = new Label();
            lblTotalMermas = new Label();
            lblTituloTotalMermas = new Label();
            dgvMermasDia = new DataGridView();
            tpHistorialMes = new TabPage();
            btnExportarExcelMes = new Button();
            btnBorrarHistorial = new Button();
            btnImprimirMes = new Button();
            lblTotalMensual = new Label();
            lblTituloTotalMes = new Label();
            dtpFiltroMes = new DateTimePicker();
            lblSeleccionarMes = new Label();
            dgvVentasMes = new DataGridView();
            tpEstadisticas = new TabPage();
            btnGuardarGraficasImagen = new Button();
            btnImprimirGraficas = new Button();
            chartHorarios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlContenedorTab.SuspendLayout();
            tcCorteCaja.SuspendLayout();
            tpCorteDia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFondoInicial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasDia).BeginInit();
            tpMermasDia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMermasDia).BeginInit();
            tpHistorialMes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentasMes).BeginInit();
            tpEstadisticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartHorarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartProductos).BeginInit();
            SuspendLayout();
            // 
            // pnlContenedorTab
            // 
            pnlContenedorTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContenedorTab.BackColor = Color.FromArgb(30, 30, 30);
            pnlContenedorTab.Controls.Add(tcCorteCaja);
            pnlContenedorTab.Location = new Point(400, 0);
            pnlContenedorTab.Name = "pnlContenedorTab";
            pnlContenedorTab.Size = new Size(1280, 987);
            pnlContenedorTab.TabIndex = 0;
            // 
            // tcCorteCaja
            // 
            tcCorteCaja.Controls.Add(tpCorteDia);
            tcCorteCaja.Controls.Add(tpMermasDia);
            tcCorteCaja.Controls.Add(tpHistorialMes);
            tcCorteCaja.Controls.Add(tpEstadisticas);
            tcCorteCaja.Dock = DockStyle.Fill;
            tcCorteCaja.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tcCorteCaja.ItemSize = new Size(250, 55);
            tcCorteCaja.Location = new Point(0, 0);
            tcCorteCaja.Name = "tcCorteCaja";
            tcCorteCaja.SelectedIndex = 0;
            tcCorteCaja.Size = new Size(1280, 987);
            tcCorteCaja.SizeMode = TabSizeMode.Fixed;
            tcCorteCaja.TabIndex = 0;
            // 
            // tpCorteDia
            // 
            tpCorteDia.BackColor = Color.FromArgb(30, 30, 30);
            tpCorteDia.Controls.Add(btnExportarExcelDia);
            tpCorteDia.Controls.Add(btnImprimirCorte);
            tpCorteDia.Controls.Add(btnGuardarFondoInicial);
            tpCorteDia.Controls.Add(nudFondoInicial);
            tpCorteDia.Controls.Add(lblEfectivoEsperado);
            tpCorteDia.Controls.Add(lblTituloEfectivoEsperado);
            tpCorteDia.Controls.Add(lblVentasEfectivo);
            tpCorteDia.Controls.Add(lblTituloVentasEfectivo);
            tpCorteDia.Controls.Add(lblTituloFondoInicial);
            tpCorteDia.Controls.Add(lblTotalCaja);
            tpCorteDia.Controls.Add(lblTituloTotal);
            tpCorteDia.Controls.Add(dgvVentasDia);
            tpCorteDia.ForeColor = Color.White;
            tpCorteDia.Location = new Point(4, 59);
            tpCorteDia.Name = "tpCorteDia";
            tpCorteDia.Size = new Size(1272, 924);
            tpCorteDia.TabIndex = 0;
            tpCorteDia.Text = "📅 RESUMEN DIARIO";
            // 
            // btnExportarExcelDia
            // 
            btnExportarExcelDia.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportarExcelDia.BackColor = Color.FromArgb(30, 30, 30);
            btnExportarExcelDia.Cursor = Cursors.Hand;
            btnExportarExcelDia.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnExportarExcelDia.FlatAppearance.BorderSize = 2;
            btnExportarExcelDia.FlatStyle = FlatStyle.Flat;
            btnExportarExcelDia.Font = new Font("Arial Rounded MT Bold", 12F);
            btnExportarExcelDia.ForeColor = Color.White;
            btnExportarExcelDia.Location = new Point(1005, 831);
            btnExportarExcelDia.Name = "btnExportarExcelDia";
            btnExportarExcelDia.Size = new Size(240, 50);
            btnExportarExcelDia.TabIndex = 4;
            btnExportarExcelDia.Text = "📊 EXPORTAR A EXCEL";
            btnExportarExcelDia.UseVisualStyleBackColor = false;
            btnExportarExcelDia.Click += btnExportarExcelDia_Click;
            // 
            // btnImprimirCorte
            // 
            btnImprimirCorte.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimirCorte.BackColor = Color.FromArgb(30, 30, 30);
            btnImprimirCorte.Cursor = Cursors.Hand;
            btnImprimirCorte.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnImprimirCorte.FlatAppearance.BorderSize = 2;
            btnImprimirCorte.FlatStyle = FlatStyle.Flat;
            btnImprimirCorte.Font = new Font("Arial Rounded MT Bold", 12F);
            btnImprimirCorte.Location = new Point(1005, 769);
            btnImprimirCorte.Name = "btnImprimirCorte";
            btnImprimirCorte.Size = new Size(240, 50);
            btnImprimirCorte.TabIndex = 3;
            btnImprimirCorte.Text = "🖨️ REPORTAR CORTE";
            btnImprimirCorte.UseVisualStyleBackColor = false;
            btnImprimirCorte.Click += btnImprimirCorte_Click;
            // 
            // btnGuardarFondoInicial
            // 
            btnGuardarFondoInicial.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardarFondoInicial.BackColor = Color.FromArgb(30, 30, 30);
            btnGuardarFondoInicial.Cursor = Cursors.Hand;
            btnGuardarFondoInicial.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnGuardarFondoInicial.FlatAppearance.BorderSize = 2;
            btnGuardarFondoInicial.FlatStyle = FlatStyle.Flat;
            btnGuardarFondoInicial.Font = new Font("Arial Rounded MT Bold", 10F);
            btnGuardarFondoInicial.ForeColor = Color.White;
            btnGuardarFondoInicial.Location = new Point(44, 845);
            btnGuardarFondoInicial.Name = "btnGuardarFondoInicial";
            btnGuardarFondoInicial.Size = new Size(170, 38);
            btnGuardarFondoInicial.TabIndex = 11;
            btnGuardarFondoInicial.Text = "GUARDAR FONDO";
            btnGuardarFondoInicial.UseVisualStyleBackColor = false;
            btnGuardarFondoInicial.Click += btnGuardarFondoInicial_Click;
            // 
            // nudFondoInicial
            // 
            nudFondoInicial.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nudFondoInicial.DecimalPlaces = 2;
            nudFondoInicial.Font = new Font("Arial Rounded MT Bold", 18F);
            nudFondoInicial.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            nudFondoInicial.Location = new Point(33, 797);
            nudFondoInicial.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudFondoInicial.Name = "nudFondoInicial";
            nudFondoInicial.Size = new Size(200, 35);
            nudFondoInicial.TabIndex = 10;
            nudFondoInicial.ThousandsSeparator = true;
            // 
            // lblEfectivoEsperado
            // 
            lblEfectivoEsperado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEfectivoEsperado.AutoSize = true;
            lblEfectivoEsperado.Font = new Font("Arial Rounded MT Bold", 26F, FontStyle.Bold);
            lblEfectivoEsperado.ForeColor = Color.FromArgb(0, 192, 192);
            lblEfectivoEsperado.Location = new Point(525, 797);
            lblEfectivoEsperado.Name = "lblEfectivoEsperado";
            lblEfectivoEsperado.Size = new Size(117, 40);
            lblEfectivoEsperado.TabIndex = 9;
            lblEfectivoEsperado.Text = "$0.00";
            // 
            // lblTituloEfectivoEsperado
            // 
            lblTituloEfectivoEsperado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTituloEfectivoEsperado.AutoSize = true;
            lblTituloEfectivoEsperado.Font = new Font("Arial Rounded MT Bold", 12F);
            lblTituloEfectivoEsperado.ForeColor = Color.DarkGray;
            lblTituloEfectivoEsperado.Location = new Point(520, 769);
            lblTituloEfectivoEsperado.Name = "lblTituloEfectivoEsperado";
            lblTituloEfectivoEsperado.Size = new Size(193, 18);
            lblTituloEfectivoEsperado.TabIndex = 8;
            lblTituloEfectivoEsperado.Text = "EFECTIVO ESPERADO:";
            // 
            // lblVentasEfectivo
            // 
            lblVentasEfectivo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblVentasEfectivo.AutoSize = true;
            lblVentasEfectivo.Font = new Font("Arial Rounded MT Bold", 26F, FontStyle.Bold);
            lblVentasEfectivo.ForeColor = Color.White;
            lblVentasEfectivo.Location = new Point(313, 797);
            lblVentasEfectivo.Name = "lblVentasEfectivo";
            lblVentasEfectivo.Size = new Size(117, 40);
            lblVentasEfectivo.TabIndex = 7;
            lblVentasEfectivo.Text = "$0.00";
            // 
            // lblTituloVentasEfectivo
            // 
            lblTituloVentasEfectivo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTituloVentasEfectivo.AutoSize = true;
            lblTituloVentasEfectivo.Font = new Font("Arial Rounded MT Bold", 12F);
            lblTituloVentasEfectivo.ForeColor = Color.DarkGray;
            lblTituloVentasEfectivo.Location = new Point(307, 769);
            lblTituloVentasEfectivo.Name = "lblTituloVentasEfectivo";
            lblTituloVentasEfectivo.Size = new Size(167, 18);
            lblTituloVentasEfectivo.TabIndex = 6;
            lblTituloVentasEfectivo.Text = "VENTAS EFECTIVO:";
            // 
            // lblTituloFondoInicial
            // 
            lblTituloFondoInicial.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTituloFondoInicial.AutoSize = true;
            lblTituloFondoInicial.Font = new Font("Arial Rounded MT Bold", 12F);
            lblTituloFondoInicial.ForeColor = Color.DarkGray;
            lblTituloFondoInicial.Location = new Point(28, 769);
            lblTituloFondoInicial.Name = "lblTituloFondoInicial";
            lblTituloFondoInicial.Size = new Size(217, 18);
            lblTituloFondoInicial.TabIndex = 5;
            lblTituloFondoInicial.Text = "FONDO INICIAL / CAMBIO:";
            // 
            // lblTotalCaja
            // 
            lblTotalCaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalCaja.AutoSize = true;
            lblTotalCaja.Font = new Font("Arial Rounded MT Bold", 26F, FontStyle.Bold);
            lblTotalCaja.ForeColor = Color.FromArgb(0, 192, 192);
            lblTotalCaja.Location = new Point(766, 796);
            lblTotalCaja.Name = "lblTotalCaja";
            lblTotalCaja.Size = new Size(117, 40);
            lblTotalCaja.TabIndex = 2;
            lblTotalCaja.Text = "$0.00";
            // 
            // lblTituloTotal
            // 
            lblTituloTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTituloTotal.AutoSize = true;
            lblTituloTotal.Font = new Font("Arial Rounded MT Bold", 12F);
            lblTituloTotal.ForeColor = Color.DarkGray;
            lblTituloTotal.Location = new Point(758, 768);
            lblTituloTotal.Name = "lblTituloTotal";
            lblTituloTotal.Size = new Size(161, 18);
            lblTituloTotal.TabIndex = 1;
            lblTituloTotal.Text = "VENTAS TOTALES:";
            // 
            // dgvVentasDia
            // 
            dgvVentasDia.AllowUserToAddRows = false;
            dgvVentasDia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentasDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentasDia.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvVentasDia.BorderStyle = BorderStyle.None;
            dgvVentasDia.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVentasDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvVentasDia.DefaultCellStyle = dataGridViewCellStyle1;
            dgvVentasDia.GridColor = Color.FromArgb(50, 50, 50);
            dgvVentasDia.Location = new Point(25, 25);
            dgvVentasDia.Name = "dgvVentasDia";
            dgvVentasDia.ReadOnly = true;
            dgvVentasDia.RowHeadersVisible = false;
            dgvVentasDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentasDia.Size = new Size(1220, 724);
            dgvVentasDia.TabIndex = 0;
            // 
            // tpMermasDia
            // 
            tpMermasDia.BackColor = Color.FromArgb(30, 30, 30);
            tpMermasDia.Controls.Add(lblKilosMermados);
            tpMermasDia.Controls.Add(lblTituloKilosMermados);
            tpMermasDia.Controls.Add(lblTotalMermas);
            tpMermasDia.Controls.Add(lblTituloTotalMermas);
            tpMermasDia.Controls.Add(dgvMermasDia);
            tpMermasDia.ForeColor = Color.White;
            tpMermasDia.Location = new Point(4, 59);
            tpMermasDia.Name = "tpMermasDia";
            tpMermasDia.Size = new Size(1272, 924);
            tpMermasDia.TabIndex = 3;
            tpMermasDia.Text = "MERMAS DEL DÍA";
            // 
            // lblKilosMermados
            // 
            lblKilosMermados.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblKilosMermados.AutoSize = true;
            lblKilosMermados.Font = new Font("Arial Rounded MT Bold", 32F, FontStyle.Bold);
            lblKilosMermados.ForeColor = Color.White;
            lblKilosMermados.Location = new Point(430, 805);
            lblKilosMermados.Name = "lblKilosMermados";
            lblKilosMermados.Size = new Size(224, 50);
            lblKilosMermados.TabIndex = 4;
            lblKilosMermados.Text = "0.000 KG";
            // 
            // lblTituloKilosMermados
            // 
            lblTituloKilosMermados.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTituloKilosMermados.AutoSize = true;
            lblTituloKilosMermados.Font = new Font("Arial Rounded MT Bold", 13F);
            lblTituloKilosMermados.ForeColor = Color.DarkGray;
            lblTituloKilosMermados.Location = new Point(433, 775);
            lblTituloKilosMermados.Name = "lblTituloKilosMermados";
            lblTituloKilosMermados.Size = new Size(184, 21);
            lblTituloKilosMermados.TabIndex = 3;
            lblTituloKilosMermados.Text = "KILOS MERMADOS:";
            // 
            // lblTotalMermas
            // 
            lblTotalMermas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalMermas.AutoSize = true;
            lblTotalMermas.Font = new Font("Arial Rounded MT Bold", 32F, FontStyle.Bold);
            lblTotalMermas.ForeColor = Color.Crimson;
            lblTotalMermas.Location = new Point(25, 805);
            lblTotalMermas.Name = "lblTotalMermas";
            lblTotalMermas.Size = new Size(144, 50);
            lblTotalMermas.TabIndex = 2;
            lblTotalMermas.Text = "$0.00";
            // 
            // lblTituloTotalMermas
            // 
            lblTituloTotalMermas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTituloTotalMermas.AutoSize = true;
            lblTituloTotalMermas.Font = new Font("Arial Rounded MT Bold", 13F);
            lblTituloTotalMermas.ForeColor = Color.DarkGray;
            lblTituloTotalMermas.Location = new Point(28, 775);
            lblTituloTotalMermas.Name = "lblTituloTotalMermas";
            lblTituloTotalMermas.Size = new Size(215, 21);
            lblTituloTotalMermas.TabIndex = 1;
            lblTituloTotalMermas.Text = "PÉRDIDA POR MERMA:";
            // 
            // dgvMermasDia
            // 
            dgvMermasDia.AllowUserToAddRows = false;
            dgvMermasDia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMermasDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMermasDia.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvMermasDia.BorderStyle = BorderStyle.None;
            dgvMermasDia.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMermasDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMermasDia.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMermasDia.GridColor = Color.FromArgb(50, 50, 50);
            dgvMermasDia.Location = new Point(25, 25);
            dgvMermasDia.Name = "dgvMermasDia";
            dgvMermasDia.ReadOnly = true;
            dgvMermasDia.RowHeadersVisible = false;
            dgvMermasDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMermasDia.Size = new Size(1220, 720);
            dgvMermasDia.TabIndex = 0;
            // 
            // tpHistorialMes
            // 
            tpHistorialMes.BackColor = Color.FromArgb(30, 30, 30);
            tpHistorialMes.Controls.Add(btnExportarExcelMes);
            tpHistorialMes.Controls.Add(btnBorrarHistorial);
            tpHistorialMes.Controls.Add(btnImprimirMes);
            tpHistorialMes.Controls.Add(lblTotalMensual);
            tpHistorialMes.Controls.Add(lblTituloTotalMes);
            tpHistorialMes.Controls.Add(dtpFiltroMes);
            tpHistorialMes.Controls.Add(lblSeleccionarMes);
            tpHistorialMes.Controls.Add(dgvVentasMes);
            tpHistorialMes.ForeColor = Color.White;
            tpHistorialMes.Location = new Point(4, 59);
            tpHistorialMes.Name = "tpHistorialMes";
            tpHistorialMes.Size = new Size(1272, 924);
            tpHistorialMes.TabIndex = 1;
            tpHistorialMes.Text = "📆 HISTORIAL MES";
            // 
            // btnExportarExcelMes
            // 
            btnExportarExcelMes.BackColor = Color.FromArgb(30, 30, 30);
            btnExportarExcelMes.Cursor = Cursors.Hand;
            btnExportarExcelMes.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnExportarExcelMes.FlatAppearance.BorderSize = 2;
            btnExportarExcelMes.FlatStyle = FlatStyle.Flat;
            btnExportarExcelMes.Font = new Font("Arial Rounded MT Bold", 12F);
            btnExportarExcelMes.ForeColor = Color.White;
            btnExportarExcelMes.Location = new Point(485, 785);
            btnExportarExcelMes.Name = "btnExportarExcelMes";
            btnExportarExcelMes.Size = new Size(240, 50);
            btnExportarExcelMes.TabIndex = 7;
            btnExportarExcelMes.Text = "📊 EXPORTAR A EXCEL";
            btnExportarExcelMes.UseVisualStyleBackColor = false;
            btnExportarExcelMes.Click += btnExportarExcelMes_Click;
            // 
            // btnBorrarHistorial
            // 
            btnBorrarHistorial.BackColor = Color.FromArgb(30, 30, 30);
            btnBorrarHistorial.Cursor = Cursors.Hand;
            btnBorrarHistorial.FlatAppearance.BorderColor = Color.Crimson;
            btnBorrarHistorial.FlatAppearance.BorderSize = 2;
            btnBorrarHistorial.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 20, 20);
            btnBorrarHistorial.FlatStyle = FlatStyle.Flat;
            btnBorrarHistorial.Font = new Font("Arial Rounded MT Bold", 12F);
            btnBorrarHistorial.ForeColor = Color.Crimson;
            btnBorrarHistorial.Location = new Point(745, 785);
            btnBorrarHistorial.Name = "btnBorrarHistorial";
            btnBorrarHistorial.Size = new Size(240, 50);
            btnBorrarHistorial.TabIndex = 6;
            btnBorrarHistorial.Text = "⚠️ BORRAR HISTORIAL";
            btnBorrarHistorial.UseVisualStyleBackColor = false;
            btnBorrarHistorial.Click += btnBorrarHistorial_Click;
            // 
            // btnImprimirMes
            // 
            btnImprimirMes.BackColor = Color.FromArgb(30, 30, 30);
            btnImprimirMes.Cursor = Cursors.Hand;
            btnImprimirMes.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnImprimirMes.FlatAppearance.BorderSize = 2;
            btnImprimirMes.FlatStyle = FlatStyle.Flat;
            btnImprimirMes.Font = new Font("Arial Rounded MT Bold", 12F);
            btnImprimirMes.Location = new Point(1005, 785);
            btnImprimirMes.Name = "btnImprimirMes";
            btnImprimirMes.Size = new Size(240, 50);
            btnImprimirMes.TabIndex = 5;
            btnImprimirMes.Text = "🖨️ REPORTAR MES";
            btnImprimirMes.UseVisualStyleBackColor = false;
            btnImprimirMes.Click += btnImprimirMes_Click;
            // 
            // lblTotalMensual
            // 
            lblTotalMensual.AutoSize = true;
            lblTotalMensual.Font = new Font("Arial Rounded MT Bold", 32F, FontStyle.Bold);
            lblTotalMensual.ForeColor = Color.FromArgb(0, 192, 192);
            lblTotalMensual.Location = new Point(25, 785);
            lblTotalMensual.Name = "lblTotalMensual";
            lblTotalMensual.Size = new Size(144, 50);
            lblTotalMensual.TabIndex = 4;
            lblTotalMensual.Text = "$0.00";
            // 
            // lblTituloTotalMes
            // 
            lblTituloTotalMes.AutoSize = true;
            lblTituloTotalMes.Font = new Font("Arial Rounded MT Bold", 13F);
            lblTituloTotalMes.ForeColor = Color.DarkGray;
            lblTituloTotalMes.Location = new Point(28, 755);
            lblTituloTotalMes.Name = "lblTituloTotalMes";
            lblTituloTotalMes.Size = new Size(201, 21);
            lblTituloTotalMes.TabIndex = 3;
            lblTituloTotalMes.Text = "TOTAL ACUMULADO:";
            // 
            // dtpFiltroMes
            // 
            dtpFiltroMes.CustomFormat = "MMMM yyyy";
            dtpFiltroMes.Format = DateTimePickerFormat.Custom;
            dtpFiltroMes.Location = new Point(190, 25);
            dtpFiltroMes.Name = "dtpFiltroMes";
            dtpFiltroMes.ShowUpDown = true;
            dtpFiltroMes.Size = new Size(200, 29);
            dtpFiltroMes.TabIndex = 2;
            dtpFiltroMes.ValueChanged += dtpFiltroMes_ValueChanged;
            // 
            // lblSeleccionarMes
            // 
            lblSeleccionarMes.AutoSize = true;
            lblSeleccionarMes.Font = new Font("Arial Rounded MT Bold", 12F);
            lblSeleccionarMes.Location = new Point(25, 28);
            lblSeleccionarMes.Name = "lblSeleccionarMes";
            lblSeleccionarMes.Size = new Size(145, 18);
            lblSeleccionarMes.TabIndex = 1;
            lblSeleccionarMes.Text = "Seleccionar Mes:";
            // 
            // dgvVentasMes
            // 
            dgvVentasMes.AllowUserToAddRows = false;
            dgvVentasMes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentasMes.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvVentasMes.BorderStyle = BorderStyle.None;
            dgvVentasMes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVentasMes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvVentasMes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvVentasMes.GridColor = Color.FromArgb(50, 50, 50);
            dgvVentasMes.Location = new Point(25, 70);
            dgvVentasMes.Name = "dgvVentasMes";
            dgvVentasMes.ReadOnly = true;
            dgvVentasMes.RowHeadersVisible = false;
            dgvVentasMes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentasMes.Size = new Size(1220, 660);
            dgvVentasMes.TabIndex = 0;
            // 
            // tpEstadisticas
            // 
            tpEstadisticas.BackColor = Color.FromArgb(30, 30, 30);
            tpEstadisticas.Controls.Add(btnGuardarGraficasImagen);
            tpEstadisticas.Controls.Add(btnImprimirGraficas);
            tpEstadisticas.Controls.Add(chartHorarios);
            tpEstadisticas.Controls.Add(chartProductos);
            tpEstadisticas.Location = new Point(4, 59);
            tpEstadisticas.Name = "tpEstadisticas";
            tpEstadisticas.Size = new Size(1272, 924);
            tpEstadisticas.TabIndex = 2;
            tpEstadisticas.Text = "📊 ANÁLISIS GRÁFICO";
            // 
            // btnGuardarGraficasImagen
            // 
            btnGuardarGraficasImagen.BackColor = Color.FromArgb(30, 30, 30);
            btnGuardarGraficasImagen.Cursor = Cursors.Hand;
            btnGuardarGraficasImagen.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnGuardarGraficasImagen.FlatAppearance.BorderSize = 2;
            btnGuardarGraficasImagen.FlatStyle = FlatStyle.Flat;
            btnGuardarGraficasImagen.Font = new Font("Arial Rounded MT Bold", 12F);
            btnGuardarGraficasImagen.ForeColor = Color.White;
            btnGuardarGraficasImagen.Location = new Point(745, 785);
            btnGuardarGraficasImagen.Name = "btnGuardarGraficasImagen";
            btnGuardarGraficasImagen.Size = new Size(240, 50);
            btnGuardarGraficasImagen.TabIndex = 3;
            btnGuardarGraficasImagen.Text = "🖼️ GUARDAR IMÁGENES";
            btnGuardarGraficasImagen.UseVisualStyleBackColor = false;
            btnGuardarGraficasImagen.Click += btnGuardarGraficasImagen_Click;
            // 
            // btnImprimirGraficas
            // 
            btnImprimirGraficas.BackColor = Color.FromArgb(30, 30, 30);
            btnImprimirGraficas.Cursor = Cursors.Hand;
            btnImprimirGraficas.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnImprimirGraficas.FlatAppearance.BorderSize = 2;
            btnImprimirGraficas.FlatStyle = FlatStyle.Flat;
            btnImprimirGraficas.Font = new Font("Arial Rounded MT Bold", 12F);
            btnImprimirGraficas.ForeColor = Color.White;
            btnImprimirGraficas.Location = new Point(1005, 785);
            btnImprimirGraficas.Name = "btnImprimirGraficas";
            btnImprimirGraficas.Size = new Size(240, 50);
            btnImprimirGraficas.TabIndex = 2;
            btnImprimirGraficas.Text = "🖨️ IMPRIMIR GRÁFICAS";
            btnImprimirGraficas.UseVisualStyleBackColor = false;
            btnImprimirGraficas.Click += btnImprimirGraficas_Click;
            // 
            // chartHorarios
            // 
            chartHorarios.BackColor = Color.FromArgb(35, 35, 35);
            chartArea1.BackColor = Color.FromArgb(40, 40, 40);
            chartArea1.Name = "ChartArea1";
            chartHorarios.ChartAreas.Add(chartArea1);
            legend1.BackColor = Color.FromArgb(35, 35, 35);
            legend1.Font = new Font("Arial Rounded MT Bold", 10F);
            legend1.ForeColor = Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            chartHorarios.Legends.Add(legend1);
            chartHorarios.Location = new Point(645, 35);
            chartHorarios.Name = "chartHorarios";
            series1.ChartArea = "ChartArea1";
            series1.Font = new Font("Arial Rounded MT Bold", 10F);
            series1.Legend = "Legend1";
            series1.Name = "Ventas por Hora";
            chartHorarios.Series.Add(series1);
            chartHorarios.Size = new Size(600, 720);
            chartHorarios.TabIndex = 1;
            chartHorarios.Text = "Ventas por Horario";
            // 
            // chartProductos
            // 
            chartProductos.BackColor = Color.FromArgb(35, 35, 35);
            chartArea2.BackColor = Color.FromArgb(40, 40, 40);
            chartArea2.Name = "ChartArea1";
            chartProductos.ChartAreas.Add(chartArea2);
            legend2.BackColor = Color.FromArgb(35, 35, 35);
            legend2.Font = new Font("Arial Rounded MT Bold", 10F);
            legend2.ForeColor = Color.White;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            chartProductos.Legends.Add(legend2);
            chartProductos.Location = new Point(25, 35);
            chartProductos.Name = "chartProductos";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new Font("Arial Rounded MT Bold", 10F);
            series2.Legend = "Legend1";
            series2.Name = "Categorias";
            chartProductos.Series.Add(series2);
            chartProductos.Size = new Size(600, 720);
            chartProductos.TabIndex = 0;
            chartProductos.Text = "Productos más vendidos";
            // 
            // UC_CorteCaja
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(pnlContenedorTab);
            Name = "UC_CorteCaja";
            Size = new Size(1706, 987);
            pnlContenedorTab.ResumeLayout(false);
            tcCorteCaja.ResumeLayout(false);
            tpCorteDia.ResumeLayout(false);
            tpCorteDia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFondoInicial).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentasDia).EndInit();
            tpMermasDia.ResumeLayout(false);
            tpMermasDia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMermasDia).EndInit();
            tpHistorialMes.ResumeLayout(false);
            tpHistorialMes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentasMes).EndInit();
            tpEstadisticas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartHorarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContenedorTab;
        private TabControl tcCorteCaja;
        private TabPage tpCorteDia;
        private TabPage tpMermasDia;
        private TabPage tpHistorialMes;
        private TabPage tpEstadisticas;
        private DataGridView dgvVentasDia;
        private DataGridView dgvMermasDia;
        private Label lblTotalCaja;
        private Label lblTituloTotal;
        private Label lblTituloFondoInicial;
        private NumericUpDown nudFondoInicial;
        private Button btnGuardarFondoInicial;
        private Label lblTituloVentasEfectivo;
        private Label lblVentasEfectivo;
        private Label lblTituloEfectivoEsperado;
        private Label lblEfectivoEsperado;
        private Label lblTituloTotalMermas;
        private Label lblTotalMermas;
        private Label lblTituloKilosMermados;
        private Label lblKilosMermados;
        private Button btnImprimirCorte;
        private Button btnExportarExcelDia;
        private DataGridView dgvVentasMes;
        private DateTimePicker dtpFiltroMes;
        private Label lblSeleccionarMes;
        private Label lblTotalMensual;
        private Label lblTituloTotalMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHorarios;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductos;
        private Button btnImprimirMes;
        private Button btnExportarExcelMes;
        private Button btnImprimirGraficas;
        private Button btnBorrarHistorial;
        private Button btnGuardarGraficasImagen;
    }
}
