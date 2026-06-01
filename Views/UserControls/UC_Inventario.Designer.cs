using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    partial class UC_Inventario
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tcCategorias = new TabControl();
            tpResumen = new TabPage();
            lblTotalDineroTitulo = new Label();
            lblTotalDineroValor = new Label();
            lblKilosRes = new Label();
            lblKilosCerdo = new Label();
            lblKilosOtros = new Label();
            tpRes = new TabPage();
            dgvRes = new DataGridView();
            colRID = new DataGridViewTextBoxColumn();
            colRProducto = new DataGridViewTextBoxColumn();
            colRCategoria = new DataGridViewTextBoxColumn();
            colRPrecio = new DataGridViewTextBoxColumn();
            colRStock = new DataGridViewTextBoxColumn();
            tpCerdo = new TabPage();
            dgvCerdo = new DataGridView();
            colCID = new DataGridViewTextBoxColumn();
            colCProducto = new DataGridViewTextBoxColumn();
            colCCategoria = new DataGridViewTextBoxColumn();
            colCPrecio = new DataGridViewTextBoxColumn();
            colCStock = new DataGridViewTextBoxColumn();
            tpOtros = new TabPage();
            dgvOtros = new DataGridView();
            colOID = new DataGridViewTextBoxColumn();
            colOProducto = new DataGridViewTextBoxColumn();
            colOCategoria = new DataGridViewTextBoxColumn();
            colOPrecio = new DataGridViewTextBoxColumn();
            colOSTOCK = new DataGridViewTextBoxColumn();
            tpGrafica = new TabPage();
            chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnFiltroGlobal = new Button();
            btnFiltroRes = new Button();
            btnFiltroCerdo = new Button();
            btnFiltroOtros = new Button();
            tpMermas = new TabPage();
            dgvMermas = new DataGridView();
            colMFecha = new DataGridViewTextBoxColumn();
            colMId = new DataGridViewTextBoxColumn();
            colMProducto = new DataGridViewTextBoxColumn();
            colMBruto = new DataGridViewTextBoxColumn();
            colMNeto = new DataGridViewTextBoxColumn();
            colMMerma = new DataGridViewTextBoxColumn();
            colMValor = new DataGridViewTextBoxColumn();
            colMNotas = new DataGridViewTextBoxColumn();
            btnAgregarProducto = new Button();
            btnModificarProducto = new Button();
            btnRegistrarMerma = new Button();
            tcCategorias.SuspendLayout();
            tpResumen.SuspendLayout();
            tpRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRes).BeginInit();
            tpCerdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCerdo).BeginInit();
            tpOtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOtros).BeginInit();
            tpGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartStock).BeginInit();
            tpMermas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMermas).BeginInit();
            SuspendLayout();
            // 
            // tcCategorias
            // 
            tcCategorias.Anchor = AnchorStyles.Left;
            tcCategorias.Controls.Add(tpResumen);
            tcCategorias.Controls.Add(tpRes);
            tcCategorias.Controls.Add(tpCerdo);
            tcCategorias.Controls.Add(tpOtros);
            tcCategorias.Controls.Add(tpGrafica);
            tcCategorias.Controls.Add(tpMermas);
            tcCategorias.Font = new Font("Arial Rounded MT Bold", 14F);
            tcCategorias.ItemSize = new Size(220, 50);
            tcCategorias.Location = new Point(400, 0);
            tcCategorias.Name = "tcCategorias";
            tcCategorias.SelectedIndex = 0;
            tcCategorias.Size = new Size(1200, 967);
            tcCategorias.SizeMode = TabSizeMode.Fixed;
            tcCategorias.TabIndex = 0;
            // 
            // tpResumen
            // 
            tpResumen.BackColor = Color.FromArgb(30, 30, 30);
            tpResumen.Controls.Add(lblTotalDineroTitulo);
            tpResumen.Controls.Add(lblTotalDineroValor);
            tpResumen.Controls.Add(lblKilosRes);
            tpResumen.Controls.Add(lblKilosCerdo);
            tpResumen.Controls.Add(lblKilosOtros);
            tpResumen.Location = new Point(4, 54);
            tpResumen.Name = "tpResumen";
            tpResumen.Size = new Size(1192, 909);
            tpResumen.TabIndex = 4;
            tpResumen.Text = "📈 RESUMEN";
            // 
            // lblTotalDineroTitulo
            // 
            lblTotalDineroTitulo.AutoSize = true;
            lblTotalDineroTitulo.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalDineroTitulo.ForeColor = Color.DarkGray;
            lblTotalDineroTitulo.Location = new Point(100, 100);
            lblTotalDineroTitulo.Name = "lblTotalDineroTitulo";
            lblTotalDineroTitulo.Size = new Size(514, 37);
            lblTotalDineroTitulo.TabIndex = 0;
            lblTotalDineroTitulo.Text = "VALOR TOTAL DE MERCANCÍA:";
            // 
            // lblTotalDineroValor
            // 
            lblTotalDineroValor.AutoSize = true;
            lblTotalDineroValor.Font = new Font("Arial Rounded MT Bold", 64F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalDineroValor.ForeColor = Color.FromArgb(0, 192, 192);
            lblTotalDineroValor.Location = new Point(90, 150);
            lblTotalDineroValor.Name = "lblTotalDineroValor";
            lblTotalDineroValor.Size = new Size(273, 99);
            lblTotalDineroValor.TabIndex = 1;
            lblTotalDineroValor.Text = "$0.00";
            // 
            // lblKilosRes
            // 
            lblKilosRes.AutoSize = true;
            lblKilosRes.Font = new Font("Arial Rounded MT Bold", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKilosRes.ForeColor = Color.White;
            lblKilosRes.Location = new Point(100, 350);
            lblKilosRes.Name = "lblKilosRes";
            lblKilosRes.Size = new Size(235, 40);
            lblKilosRes.TabIndex = 2;
            lblKilosRes.Text = "🐑 Res: 0 KG";
            // 
            // lblKilosCerdo
            // 
            lblKilosCerdo.AutoSize = true;
            lblKilosCerdo.Font = new Font("Arial Rounded MT Bold", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKilosCerdo.ForeColor = Color.White;
            lblKilosCerdo.Location = new Point(100, 450);
            lblKilosCerdo.Name = "lblKilosCerdo";
            lblKilosCerdo.Size = new Size(275, 40);
            lblKilosCerdo.TabIndex = 3;
            lblKilosCerdo.Text = "🐖 Cerdo: 0 KG";
            // 
            // lblKilosOtros
            // 
            lblKilosOtros.AutoSize = true;
            lblKilosOtros.Font = new Font("Arial Rounded MT Bold", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKilosOtros.ForeColor = Color.White;
            lblKilosOtros.Location = new Point(100, 550);
            lblKilosOtros.Name = "lblKilosOtros";
            lblKilosOtros.Size = new Size(265, 40);
            lblKilosOtros.TabIndex = 4;
            lblKilosOtros.Text = "📦 Otros: 0 KG";
            // 
            // tpRes
            // 
            tpRes.BackColor = Color.FromArgb(30, 30, 30);
            tpRes.Controls.Add(dgvRes);
            tpRes.Location = new Point(4, 54);
            tpRes.Name = "tpRes";
            tpRes.Size = new Size(1192, 909);
            tpRes.TabIndex = 0;
            tpRes.Text = "🐑 RES";
            // 
            // dgvRes
            // 
            dgvRes.AllowUserToAddRows = false;
            dgvRes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRes.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvRes.BorderStyle = BorderStyle.None;
            dgvRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRes.Columns.AddRange(new DataGridViewColumn[] { colRID, colRProducto, colRCategoria, colRPrecio, colRStock });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle3.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRes.Dock = DockStyle.Fill;
            dgvRes.Location = new Point(0, 0);
            dgvRes.Name = "dgvRes";
            dgvRes.ReadOnly = true;
            dgvRes.RowHeadersVisible = false;
            dgvRes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRes.Size = new Size(1192, 909);
            dgvRes.TabIndex = 0;
            // 
            // colRID
            // 
            colRID.HeaderText = "ID PRODUCTO";
            colRID.Name = "colRID";
            colRID.ReadOnly = true;
            // 
            // colRProducto
            // 
            colRProducto.HeaderText = "PRODUCTO";
            colRProducto.Name = "colRProducto";
            colRProducto.ReadOnly = true;
            // 
            // colRCategoria
            // 
            colRCategoria.HeaderText = "CATEGORÍA";
            colRCategoria.Name = "colRCategoria";
            colRCategoria.ReadOnly = true;
            // 
            // colRPrecio
            // 
            dataGridViewCellStyle1.Format = "C3";
            colRPrecio.DefaultCellStyle = dataGridViewCellStyle1;
            colRPrecio.HeaderText = "PRECIO";
            colRPrecio.Name = "colRPrecio";
            colRPrecio.ReadOnly = true;
            // 
            // colRStock
            // 
            dataGridViewCellStyle2.Format = "N3";
            colRStock.DefaultCellStyle = dataGridViewCellStyle2;
            colRStock.HeaderText = "STOCK (KG)";
            colRStock.Name = "colRStock";
            colRStock.ReadOnly = true;
            // 
            // tpCerdo
            // 
            tpCerdo.BackColor = Color.FromArgb(30, 30, 30);
            tpCerdo.Controls.Add(dgvCerdo);
            tpCerdo.Location = new Point(4, 54);
            tpCerdo.Name = "tpCerdo";
            tpCerdo.Size = new Size(1192, 909);
            tpCerdo.TabIndex = 1;
            tpCerdo.Text = "🐖 CERDO";
            // 
            // dgvCerdo
            // 
            dgvCerdo.AllowUserToAddRows = false;
            dgvCerdo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCerdo.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvCerdo.BorderStyle = BorderStyle.None;
            dgvCerdo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCerdo.Columns.AddRange(new DataGridViewColumn[] { colCID, colCProducto, colCCategoria, colCPrecio, colCStock });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle6.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvCerdo.DefaultCellStyle = dataGridViewCellStyle6;
            dgvCerdo.Dock = DockStyle.Fill;
            dgvCerdo.Location = new Point(0, 0);
            dgvCerdo.Name = "dgvCerdo";
            dgvCerdo.ReadOnly = true;
            dgvCerdo.RowHeadersVisible = false;
            dgvCerdo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCerdo.Size = new Size(1192, 909);
            dgvCerdo.TabIndex = 0;
            // 
            // colCID
            // 
            colCID.HeaderText = "ID PRODUCTO";
            colCID.Name = "colCID";
            colCID.ReadOnly = true;
            // 
            // colCProducto
            // 
            colCProducto.HeaderText = "PRODUCTO";
            colCProducto.Name = "colCProducto";
            colCProducto.ReadOnly = true;
            // 
            // colCCategoria
            // 
            colCCategoria.HeaderText = "CATEGORÍA";
            colCCategoria.Name = "colCCategoria";
            colCCategoria.ReadOnly = true;
            // 
            // colCPrecio
            // 
            dataGridViewCellStyle4.Format = "C3";
            colCPrecio.DefaultCellStyle = dataGridViewCellStyle4;
            colCPrecio.HeaderText = "PRECIO";
            colCPrecio.Name = "colCPrecio";
            colCPrecio.ReadOnly = true;
            // 
            // colCStock
            // 
            dataGridViewCellStyle5.Format = "N3";
            colCStock.DefaultCellStyle = dataGridViewCellStyle5;
            colCStock.HeaderText = "STOCK (KG)";
            colCStock.Name = "colCStock";
            colCStock.ReadOnly = true;
            // 
            // tpOtros
            // 
            tpOtros.BackColor = Color.FromArgb(30, 30, 30);
            tpOtros.Controls.Add(dgvOtros);
            tpOtros.Location = new Point(4, 54);
            tpOtros.Name = "tpOtros";
            tpOtros.Size = new Size(1192, 909);
            tpOtros.TabIndex = 2;
            tpOtros.Text = "📦 OTROS";
            // 
            // dgvOtros
            // 
            dgvOtros.AllowUserToAddRows = false;
            dgvOtros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOtros.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvOtros.BorderStyle = BorderStyle.None;
            dgvOtros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOtros.Columns.AddRange(new DataGridViewColumn[] { colOID, colOProducto, colOCategoria, colOPrecio, colOSTOCK });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle9.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle9.ForeColor = Color.White;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle9.SelectionForeColor = Color.Black;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvOtros.DefaultCellStyle = dataGridViewCellStyle9;
            dgvOtros.Dock = DockStyle.Fill;
            dgvOtros.Location = new Point(0, 0);
            dgvOtros.Name = "dgvOtros";
            dgvOtros.ReadOnly = true;
            dgvOtros.RowHeadersVisible = false;
            dgvOtros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOtros.Size = new Size(1192, 909);
            dgvOtros.TabIndex = 0;
            // 
            // colOID
            // 
            colOID.HeaderText = "ID PRODUCTO ";
            colOID.Name = "colOID";
            colOID.ReadOnly = true;
            // 
            // colOProducto
            // 
            colOProducto.HeaderText = "PRODUCTO";
            colOProducto.Name = "colOProducto";
            colOProducto.ReadOnly = true;
            // 
            // colOCategoria
            // 
            colOCategoria.HeaderText = "CATEGORÍA";
            colOCategoria.Name = "colOCategoria";
            colOCategoria.ReadOnly = true;
            // 
            // colOPrecio
            // 
            dataGridViewCellStyle7.Format = "C3";
            colOPrecio.DefaultCellStyle = dataGridViewCellStyle7;
            colOPrecio.HeaderText = "PRECIO";
            colOPrecio.Name = "colOPrecio";
            colOPrecio.ReadOnly = true;
            // 
            // colOSTOCK
            // 
            dataGridViewCellStyle8.Format = "N3";
            colOSTOCK.DefaultCellStyle = dataGridViewCellStyle8;
            colOSTOCK.HeaderText = "STOCK ";
            colOSTOCK.Name = "colOSTOCK";
            colOSTOCK.ReadOnly = true;
            // 
            // tpGrafica
            // 
            tpGrafica.BackColor = Color.FromArgb(30, 30, 30);
            tpGrafica.Controls.Add(chartStock);
            tpGrafica.Controls.Add(btnFiltroGlobal);
            tpGrafica.Controls.Add(btnFiltroRes);
            tpGrafica.Controls.Add(btnFiltroCerdo);
            tpGrafica.Controls.Add(btnFiltroOtros);
            tpGrafica.Location = new Point(4, 54);
            tpGrafica.Name = "tpGrafica";
            tpGrafica.Size = new Size(1192, 909);
            tpGrafica.TabIndex = 3;
            tpGrafica.Text = "📊 ANÁLISIS";
            // 
            // chartStock
            // 
            chartStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            chartStock.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartStock.Legends.Add(legend1);
            chartStock.Location = new Point(0, 80);
            chartStock.Name = "chartStock";
            chartStock.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartStock.Series.Add(series1);
            chartStock.Size = new Size(1192, 829);
            chartStock.TabIndex = 0;
            // 
            // btnFiltroGlobal
            // 
            btnFiltroGlobal.BackColor = Color.FromArgb(30, 30, 30);
            btnFiltroGlobal.Cursor = Cursors.Hand;
            btnFiltroGlobal.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnFiltroGlobal.FlatAppearance.BorderSize = 2;
            btnFiltroGlobal.FlatStyle = FlatStyle.Flat;
            btnFiltroGlobal.Font = new Font("Arial Rounded MT Bold", 12F);
            btnFiltroGlobal.ForeColor = Color.White;
            btnFiltroGlobal.Location = new Point(90, 20);
            btnFiltroGlobal.Name = "btnFiltroGlobal";
            btnFiltroGlobal.Size = new Size(150, 45);
            btnFiltroGlobal.TabIndex = 4;
            btnFiltroGlobal.Text = "🌍 GLOBAL";
            btnFiltroGlobal.UseVisualStyleBackColor = false;
            btnFiltroGlobal.Click += btnFiltroGlobal_Click;
            // 
            // btnFiltroRes
            // 
            btnFiltroRes.BackColor = Color.FromArgb(30, 30, 30);
            btnFiltroRes.Cursor = Cursors.Hand;
            btnFiltroRes.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnFiltroRes.FlatAppearance.BorderSize = 2;
            btnFiltroRes.FlatStyle = FlatStyle.Flat;
            btnFiltroRes.Font = new Font("Arial Rounded MT Bold", 12F);
            btnFiltroRes.ForeColor = Color.White;
            btnFiltroRes.Location = new Point(260, 20);
            btnFiltroRes.Name = "btnFiltroRes";
            btnFiltroRes.Size = new Size(150, 45);
            btnFiltroRes.TabIndex = 5;
            btnFiltroRes.Text = "🐑 RES";
            btnFiltroRes.UseVisualStyleBackColor = false;
            btnFiltroRes.Click += btnFiltroRes_Click;
            // 
            // btnFiltroCerdo
            // 
            btnFiltroCerdo.BackColor = Color.FromArgb(30, 30, 30);
            btnFiltroCerdo.Cursor = Cursors.Hand;
            btnFiltroCerdo.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnFiltroCerdo.FlatAppearance.BorderSize = 2;
            btnFiltroCerdo.FlatStyle = FlatStyle.Flat;
            btnFiltroCerdo.Font = new Font("Arial Rounded MT Bold", 12F);
            btnFiltroCerdo.ForeColor = Color.White;
            btnFiltroCerdo.Location = new Point(430, 20);
            btnFiltroCerdo.Name = "btnFiltroCerdo";
            btnFiltroCerdo.Size = new Size(150, 45);
            btnFiltroCerdo.TabIndex = 6;
            btnFiltroCerdo.Text = "🐖 CERDO";
            btnFiltroCerdo.UseVisualStyleBackColor = false;
            btnFiltroCerdo.Click += btnFiltroCerdo_Click;
            // 
            // btnFiltroOtros
            // 
            btnFiltroOtros.BackColor = Color.FromArgb(30, 30, 30);
            btnFiltroOtros.Cursor = Cursors.Hand;
            btnFiltroOtros.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnFiltroOtros.FlatAppearance.BorderSize = 2;
            btnFiltroOtros.FlatStyle = FlatStyle.Flat;
            btnFiltroOtros.Font = new Font("Arial Rounded MT Bold", 12F);
            btnFiltroOtros.ForeColor = Color.White;
            btnFiltroOtros.Location = new Point(600, 20);
            btnFiltroOtros.Name = "btnFiltroOtros";
            btnFiltroOtros.Size = new Size(150, 45);
            btnFiltroOtros.TabIndex = 7;
            btnFiltroOtros.Text = "📦 OTROS";
            btnFiltroOtros.UseVisualStyleBackColor = false;
            btnFiltroOtros.Click += btnFiltroOtros_Click;
            // 
            // tpMermas
            // 
            tpMermas.BackColor = Color.FromArgb(30, 30, 30);
            tpMermas.Controls.Add(dgvMermas);
            tpMermas.Location = new Point(4, 54);
            tpMermas.Name = "tpMermas";
            tpMermas.Size = new Size(1192, 909);
            tpMermas.TabIndex = 5;
            tpMermas.Text = "MERMAS";
            // 
            // dgvMermas
            // 
            dgvMermas.AllowUserToAddRows = false;
            dgvMermas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMermas.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvMermas.BorderStyle = BorderStyle.None;
            dgvMermas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMermas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMermas.Columns.AddRange(new DataGridViewColumn[] { colMFecha, colMId, colMProducto, colMBruto, colMNeto, colMMerma, colMValor, colMNotas });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle10.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvMermas.DefaultCellStyle = dataGridViewCellStyle10;
            dgvMermas.Dock = DockStyle.Fill;
            dgvMermas.GridColor = Color.FromArgb(50, 50, 50);
            dgvMermas.Location = new Point(0, 0);
            dgvMermas.Name = "dgvMermas";
            dgvMermas.ReadOnly = true;
            dgvMermas.RowHeadersVisible = false;
            dgvMermas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMermas.Size = new Size(1192, 909);
            dgvMermas.TabIndex = 0;
            // 
            // colMFecha
            // 
            colMFecha.HeaderText = "FECHA";
            colMFecha.Name = "colMFecha";
            colMFecha.ReadOnly = true;
            // 
            // colMId
            // 
            colMId.HeaderText = "ID";
            colMId.Name = "colMId";
            colMId.ReadOnly = true;
            // 
            // colMProducto
            // 
            colMProducto.HeaderText = "PRODUCTO";
            colMProducto.Name = "colMProducto";
            colMProducto.ReadOnly = true;
            // 
            // colMBruto
            // 
            colMBruto.HeaderText = "BRUTO";
            colMBruto.Name = "colMBruto";
            colMBruto.ReadOnly = true;
            // 
            // colMNeto
            // 
            colMNeto.HeaderText = "NETO";
            colMNeto.Name = "colMNeto";
            colMNeto.ReadOnly = true;
            // 
            // colMMerma
            // 
            colMMerma.HeaderText = "MERMA";
            colMMerma.Name = "colMMerma";
            colMMerma.ReadOnly = true;
            // 
            // colMValor
            // 
            colMValor.HeaderText = "VALOR PERDIDO";
            colMValor.Name = "colMValor";
            colMValor.ReadOnly = true;
            // 
            // colMNotas
            // 
            colMNotas.HeaderText = "NOTAS";
            colMNotas.Name = "colMNotas";
            colMNotas.ReadOnly = true;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnAgregarProducto.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnAgregarProducto.FlatAppearance.BorderSize = 2;
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Font = new Font("Arial Rounded MT Bold", 16F);
            btnAgregarProducto.ForeColor = Color.White;
            btnAgregarProducto.Location = new Point(1650, 500);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(200, 70);
            btnAgregarProducto.TabIndex = 1;
            btnAgregarProducto.Text = "➕ AGREGAR PRODUCTO";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnModificarProducto.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnModificarProducto.FlatAppearance.BorderSize = 2;
            btnModificarProducto.FlatStyle = FlatStyle.Flat;
            btnModificarProducto.Font = new Font("Arial Rounded MT Bold", 16F);
            btnModificarProducto.ForeColor = Color.White;
            btnModificarProducto.Location = new Point(1650, 650);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(200, 70);
            btnModificarProducto.TabIndex = 2;
            btnModificarProducto.Text = "✏️ MODIFICAR PRODUCTO";
            btnModificarProducto.UseVisualStyleBackColor = false;
            btnModificarProducto.Click += btnModificarProducto_Click;
            // 
            // btnRegistrarMerma
            // 
            btnRegistrarMerma.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnRegistrarMerma.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnRegistrarMerma.FlatAppearance.BorderSize = 2;
            btnRegistrarMerma.FlatStyle = FlatStyle.Flat;
            btnRegistrarMerma.Font = new Font("Arial Rounded MT Bold", 16F);
            btnRegistrarMerma.ForeColor = Color.White;
            btnRegistrarMerma.Location = new Point(1650, 800);
            btnRegistrarMerma.Name = "btnRegistrarMerma";
            btnRegistrarMerma.Size = new Size(200, 70);
            btnRegistrarMerma.TabIndex = 3;
            btnRegistrarMerma.Text = "REGISTRAR MERMA";
            btnRegistrarMerma.UseVisualStyleBackColor = false;
            btnRegistrarMerma.Click += btnRegistrarMerma_Click;
            // 
            // UC_Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(btnRegistrarMerma);
            Controls.Add(btnModificarProducto);
            Controls.Add(btnAgregarProducto);
            Controls.Add(tcCategorias);
            Name = "UC_Inventario";
            Size = new Size(1706, 967);
            tcCategorias.ResumeLayout(false);
            tpResumen.ResumeLayout(false);
            tpResumen.PerformLayout();
            tpRes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRes).EndInit();
            tpCerdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCerdo).EndInit();
            tpOtros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOtros).EndInit();
            tpGrafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartStock).EndInit();
            tpMermas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMermas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcCategorias;
        private TabPage tpResumen;
        private TabPage tpRes;
        private TabPage tpCerdo;
        private TabPage tpOtros;
        private TabPage tpGrafica;
        private TabPage tpMermas;
        private DataGridView dgvRes;
        private DataGridView dgvCerdo;
        private DataGridView dgvOtros;
        private DataGridView dgvMermas;
        private Button btnAgregarProducto;
        private Button btnModificarProducto;
        private Button btnRegistrarMerma;
        private DataGridViewTextBoxColumn colCID;
        private DataGridViewTextBoxColumn colCProducto;
        private DataGridViewTextBoxColumn colCCategoria;
        private DataGridViewTextBoxColumn colCPrecio;
        private DataGridViewTextBoxColumn colCStock;
        private DataGridViewTextBoxColumn colOID;
        private DataGridViewTextBoxColumn colOProducto;
        private DataGridViewTextBoxColumn colOCategoria;
        private DataGridViewTextBoxColumn colOPrecio;
        private DataGridViewTextBoxColumn colOSTOCK;
        private DataGridViewTextBoxColumn colRID;
        private DataGridViewTextBoxColumn colRProducto;
        private DataGridViewTextBoxColumn colRCategoria;
        private DataGridViewTextBoxColumn colRPrecio;
        private DataGridViewTextBoxColumn colRStock;
        private DataGridViewTextBoxColumn colMFecha;
        private DataGridViewTextBoxColumn colMId;
        private DataGridViewTextBoxColumn colMProducto;
        private DataGridViewTextBoxColumn colMBruto;
        private DataGridViewTextBoxColumn colMNeto;
        private DataGridViewTextBoxColumn colMMerma;
        private DataGridViewTextBoxColumn colMValor;
        private DataGridViewTextBoxColumn colMNotas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private Button btnFiltroGlobal;
        private Button btnFiltroRes;
        private Button btnFiltroCerdo;
        private Button btnFiltroOtros;
        private Label lblTotalDineroTitulo;
        private Label lblTotalDineroValor;
        private Label lblKilosRes;
        private Label lblKilosCerdo;
        private Label lblKilosOtros;
    }
}
