using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    partial class FrmProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProducto));
            lblTitulo = new Label();
            lblID = new Label();
            txtID = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblUnidad = new Label();
            cmbUnidad = new ComboBox();
            lblPrecio = new Label();
            numPrecio = new NumericUpDown();
            lblStock = new Label();
            numStock = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Rounded MT Bold", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(0, 192, 192);
            lblTitulo.Location = new Point(150, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(278, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NUEVO PRODUCTO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Arial Rounded MT Bold", 12F);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(60, 85);
            lblID.Name = "lblID";
            lblID.Size = new Size(108, 18);
            lblID.TabIndex = 1;
            lblID.Text = "ID Producto:";
            // 
            // txtID
            // 
            txtID.BackColor = Color.FromArgb(45, 45, 45);
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.Font = new Font("Arial", 12F);
            txtID.ForeColor = Color.White;
            txtID.Location = new Point(63, 110);
            txtID.Name = "txtID";
            txtID.Size = new Size(430, 26);
            txtID.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Arial Rounded MT Bold", 12F);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(60, 155);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(76, 18);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(45, 45, 45);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Arial", 12F);
            txtNombre.ForeColor = Color.White;
            txtNombre.Location = new Point(63, 180);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(430, 26);
            txtNombre.TabIndex = 4;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Arial Rounded MT Bold", 12F);
            lblCategoria.ForeColor = Color.White;
            lblCategoria.Location = new Point(60, 225);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(92, 18);
            lblCategoria.TabIndex = 5;
            lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.FromArgb(45, 45, 45);
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.Font = new Font("Arial", 12F);
            cmbCategoria.ForeColor = Color.White;
            cmbCategoria.Location = new Point(63, 250);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(430, 26);
            cmbCategoria.TabIndex = 6;
            // 
            // lblUnidad
            // 
            lblUnidad.AutoSize = true;
            lblUnidad.Font = new Font("Arial Rounded MT Bold", 12F);
            lblUnidad.ForeColor = Color.White;
            lblUnidad.Location = new Point(60, 295);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(154, 18);
            lblUnidad.TabIndex = 7;
            lblUnidad.Text = "Unidad de Medida:";
            // 
            // cmbUnidad
            // 
            cmbUnidad.BackColor = Color.FromArgb(45, 45, 45);
            cmbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidad.FlatStyle = FlatStyle.Flat;
            cmbUnidad.Font = new Font("Arial", 12F);
            cmbUnidad.ForeColor = Color.White;
            cmbUnidad.Items.AddRange(new object[] { "Kilos (KG)", "Piezas (PZA)" });
            cmbUnidad.Location = new Point(63, 320);
            cmbUnidad.Name = "cmbUnidad";
            cmbUnidad.Size = new Size(430, 26);
            cmbUnidad.TabIndex = 8;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Arial Rounded MT Bold", 12F);
            lblPrecio.ForeColor = Color.White;
            lblPrecio.Location = new Point(60, 365);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(91, 18);
            lblPrecio.TabIndex = 9;
            lblPrecio.Text = "Precio ($):";
            // 
            // numPrecio
            // 
            numPrecio.BackColor = Color.FromArgb(45, 45, 45);
            numPrecio.DecimalPlaces = 2;
            numPrecio.Font = new Font("Arial", 12F);
            numPrecio.ForeColor = Color.White;
            numPrecio.Location = new Point(63, 390);
            numPrecio.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(200, 26);
            numPrecio.TabIndex = 10;
            numPrecio.TextAlign = HorizontalAlignment.Center;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Arial Rounded MT Bold", 12F);
            lblStock.ForeColor = Color.White;
            lblStock.Location = new Point(290, 365);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(110, 18);
            lblStock.TabIndex = 11;
            lblStock.Text = "Stock Inicial:";
            // 
            // numStock
            // 
            numStock.BackColor = Color.FromArgb(45, 45, 45);
            numStock.DecimalPlaces = 3;
            numStock.Font = new Font("Arial", 12F);
            numStock.ForeColor = Color.White;
            numStock.Location = new Point(293, 390);
            numStock.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(200, 26);
            numStock.TabIndex = 12;
            numStock.TextAlign = HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(30, 30, 30);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnGuardar.FlatAppearance.BorderSize = 2;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Arial Rounded MT Bold", 12F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(63, 460);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(190, 45);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "💾 GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(30, 30, 30);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(210, 50, 50);
            btnCancelar.FlatAppearance.BorderSize = 2;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Rounded MT Bold", 12F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(303, 460);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(190, 45);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "❌ CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(20, 20, 20);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderColor = Color.Red;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Arial Rounded MT Bold", 10F);
            btnEliminar.ForeColor = Color.LightCoral;
            btnEliminar.Location = new Point(185, 525);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(180, 35);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "🗑️ BORRAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(560, 585);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(numStock);
            Controls.Add(lblStock);
            Controls.Add(numPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(cmbUnidad);
            Controls.Add(lblUnidad);
            Controls.Add(cmbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtID);
            Controls.Add(lblID);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProducto";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Formulario Producto";
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblID;
        private TextBox txtID;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblUnidad;
        private ComboBox cmbUnidad;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private Label lblStock;
        private NumericUpDown numStock;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnEliminar;
    }
}