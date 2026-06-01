using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    partial class UC_Ventas
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvVenta = new DataGridView();
            colIDproducto = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colKG = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            btnQuitar = new Button();
            btnLimpiar = new Button();
            btnCobrar = new Button();
            lblTotal = new Label();
            btnAgregar = new Button();
            lblStock = new Label();
            lblCategoria = new Label();
            txtPeso = new TextBox();
            lblPeso = new Label();
            lblTiempo = new Label();
            lblPrecioProducto = new Label();
            lblNombreProducto = new Label();
            lblEstadoProducto = new Label();
            lblInstruccionID = new Label();
            txtIdProducto = new TextBox();
            timerReloj = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            SuspendLayout();
            // 
            // dgvVenta
            // 
            dgvVenta.AllowUserToAddRows = false;
            dgvVenta.Anchor = AnchorStyles.Top;
            dgvVenta.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvVenta.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenta.Columns.AddRange(new DataGridViewColumn[] { colIDproducto, colProducto, colKG, colPrecio, colSubtotal });
            dgvVenta.EnableHeadersVisualStyles = false;
            dgvVenta.GridColor = Color.FromArgb(64, 64, 64);
            dgvVenta.Location = new Point(891, 146);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.ReadOnly = true;
            dgvVenta.RowHeadersVisible = false;
            dgvVenta.Size = new Size(795, 621);
            dgvVenta.TabIndex = 20;
            // 
            // colIDproducto
            // 
            colIDproducto.HeaderText = "ID PRODUCTO";
            colIDproducto.Name = "colIDproducto";
            colIDproducto.ReadOnly = true;
            colIDproducto.Width = 165;
            // 
            // colProducto
            // 
            colProducto.HeaderText = "PRODUCTO";
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            colProducto.Width = 200;
            // 
            // colKG
            // 
            dataGridViewCellStyle2.Format = "N3";
            colKG.DefaultCellStyle = dataGridViewCellStyle2;
            colKG.HeaderText = "KG";
            colKG.Name = "colKG";
            colKG.ReadOnly = true;
            colKG.Width = 130;
            // 
            // colPrecio
            // 
            dataGridViewCellStyle3.Format = "C2";
            colPrecio.DefaultCellStyle = dataGridViewCellStyle3;
            colPrecio.HeaderText = "PRECIO";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 150;
            // 
            // colSubtotal
            // 
            dataGridViewCellStyle4.Format = "C2";
            colSubtotal.DefaultCellStyle = dataGridViewCellStyle4;
            colSubtotal.HeaderText = "SUBTOTAL";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            colSubtotal.Width = 152;
            // 
            // btnQuitar
            // 
            btnQuitar.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnQuitar.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnQuitar.FlatAppearance.BorderSize = 2;
            btnQuitar.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnQuitar.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnQuitar.FlatStyle = FlatStyle.Flat;
            btnQuitar.Font = new Font("Arial Rounded MT Bold", 16F);
            btnQuitar.ForeColor = Color.White;
            btnQuitar.Location = new Point(435, 786);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(372, 67);
            btnQuitar.TabIndex = 19;
            btnQuitar.Text = "🗑️ QUITAR UN PRODUCTO\r\n";
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top;
            btnLimpiar.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnLimpiar.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnLimpiar.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Arial Rounded MT Bold", 16F);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(1406, 872);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(280, 70);
            btnLimpiar.TabIndex = 18;
            btnLimpiar.Text = "🗑️ CANCELAR VENTA";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCobrar
            // 
            btnCobrar.Anchor = AnchorStyles.Top;
            btnCobrar.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnCobrar.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnCobrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnCobrar.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.Font = new Font("Arial Rounded MT Bold", 16F);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.Location = new Point(1406, 792);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(280, 70);
            btnCobrar.TabIndex = 17;
            btnCobrar.Text = "💰 COBRAR";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top;
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(891, 799);
            lblTotal.Margin = new Padding(10, 10, 0, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(344, 55);
            lblTotal.TabIndex = 16;
            lblTotal.Text = "TOTAL: $0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnAgregar.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnAgregar.FlatAppearance.BorderSize = 2;
            btnAgregar.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnAgregar.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Arial Rounded MT Bold", 16F);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(435, 700);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(372, 67);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "💸AGREGAR\r\n";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.BackColor = Color.Transparent;
            lblStock.Font = new Font("Arial Rounded MT Bold", 22F);
            lblStock.ForeColor = Color.WhiteSmoke;
            lblStock.Location = new Point(435, 404);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(250, 34);
            lblStock.TabIndex = 13;
            lblStock.Text = "En Stock : 40 kg";
            lblStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.BackColor = Color.Transparent;
            lblCategoria.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoria.ForeColor = Color.WhiteSmoke;
            lblCategoria.Location = new Point(435, 450);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(149, 28);
            lblCategoria.TabIndex = 21;
            lblCategoria.Text = "Categoría: -";
            lblCategoria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPeso
            // 
            txtPeso.BackColor = SystemColors.ButtonFace;
            txtPeso.Font = new Font("Arial Rounded MT Bold", 54.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPeso.ForeColor = Color.Black;
            txtPeso.Location = new Point(435, 590);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(372, 92);
            txtPeso.TabIndex = 12;
            txtPeso.TextAlign = HorizontalAlignment.Center;
            txtPeso.KeyDown += txtPeso_KeyDown;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.BackColor = Color.Transparent;
            lblPeso.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeso.ForeColor = Color.WhiteSmoke;
            lblPeso.Location = new Point(435, 560);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(124, 24);
            lblPeso.TabIndex = 11;
            lblPeso.Text = "Peso (KG) :";
            lblPeso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.BackColor = Color.Transparent;
            lblTiempo.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTiempo.ForeColor = Color.WhiteSmoke;
            lblTiempo.Location = new Point(435, 500);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(238, 24);
            lblTiempo.TabIndex = 10;
            lblTiempo.Text = "Martes 5 de mayo 2026";
            lblTiempo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrecioProducto
            // 
            lblPrecioProducto.AutoSize = true;
            lblPrecioProducto.BackColor = Color.Transparent;
            lblPrecioProducto.Font = new Font("Arial Rounded MT Bold", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrecioProducto.ForeColor = Color.WhiteSmoke;
            lblPrecioProducto.Location = new Point(435, 353);
            lblPrecioProducto.Name = "lblPrecioProducto";
            lblPrecioProducto.Size = new Size(85, 43);
            lblPrecioProducto.TabIndex = 9;
            lblPrecioProducto.Text = "160";
            lblPrecioProducto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.BackColor = Color.Transparent;
            lblNombreProducto.Font = new Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreProducto.ForeColor = Color.WhiteSmoke;
            lblNombreProducto.Location = new Point(435, 303);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(320, 33);
            lblNombreProducto.TabIndex = 8;
            lblNombreProducto.Text = "Nombre Del Producto";
            lblNombreProducto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEstadoProducto
            // 
            lblEstadoProducto.AutoSize = true;
            lblEstadoProducto.BackColor = Color.Transparent;
            lblEstadoProducto.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstadoProducto.ForeColor = Color.WhiteSmoke;
            lblEstadoProducto.Location = new Point(435, 266);
            lblEstadoProducto.Name = "lblEstadoProducto";
            lblEstadoProducto.Size = new Size(283, 26);
            lblEstadoProducto.TabIndex = 7;
            lblEstadoProducto.Text = "Esperando Producto.......";
            lblEstadoProducto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInstruccionID
            // 
            lblInstruccionID.AutoSize = true;
            lblInstruccionID.BackColor = Color.Transparent;
            lblInstruccionID.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstruccionID.ForeColor = Color.WhiteSmoke;
            lblInstruccionID.Location = new Point(420, 155);
            lblInstruccionID.Name = "lblInstruccionID";
            lblInstruccionID.Size = new Size(500, 26);
            lblInstruccionID.TabIndex = 6;
            lblInstruccionID.Text = "INGRESA ID O NOMBRE DEL PRODUCTO 🍖 :";
            lblInstruccionID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtIdProducto
            // 
            txtIdProducto.BackColor = SystemColors.ButtonHighlight;
            txtIdProducto.Font = new Font("Arial Rounded MT Bold", 32F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIdProducto.ForeColor = Color.Black;
            txtIdProducto.Location = new Point(435, 190);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.Size = new Size(372, 57);
            txtIdProducto.TabIndex = 4;
            txtIdProducto.TextAlign = HorizontalAlignment.Center;
            txtIdProducto.KeyDown += txtIdProducto_KeyDown;
            // 
            // timerReloj
            // 
            timerReloj.Tick += timerReloj_Tick;
            // 
            // UC_Ventas
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(dgvVenta);
            Controls.Add(btnQuitar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCobrar);
            Controls.Add(lblTotal);
            Controls.Add(btnAgregar);
            Controls.Add(lblStock);
            Controls.Add(lblCategoria);
            Controls.Add(txtPeso);
            Controls.Add(lblPeso);
            Controls.Add(lblTiempo);
            Controls.Add(lblPrecioProducto);
            Controls.Add(lblNombreProducto);
            Controls.Add(lblEstadoProducto);
            Controls.Add(lblInstruccionID);
            Controls.Add(txtIdProducto);
            Name = "UC_Ventas";
            Size = new Size(1706, 967);
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button btnQuitar;
        private Button btnLimpiar;
        private Button btnCobrar;
        private Label lblTotal;
        private Button btnAgregar;
        private Label lblStock;
        private Label lblCategoria;
        private TextBox txtPeso;
        private Label lblPeso;
        private Label lblTiempo;
        private Label lblPrecioProducto;
        private Label lblNombreProducto;
        private Label lblEstadoProducto;
        private Label lblInstruccionID;
        private TextBox txtIdProducto;
        private DataGridView dgvVenta;
        private System.Windows.Forms.Timer timerReloj;
        private DataGridViewTextBoxColumn colIDproducto;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colKG;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colSubtotal;
    }
}