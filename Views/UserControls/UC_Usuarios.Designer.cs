using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    partial class UC_Usuarios
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
            pnlContenedorTab = new Panel();
            tcUsuarios = new TabControl();
            tpGestion = new TabPage();
            pnlFormulario = new Panel();
            btnNuevo = new Button();
            btnBuscarUsuario = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGuardar = new Button();
            cmbRol = new ComboBox();
            lblRol = new Label();
            txtNombreCompleto = new TextBox();
            lblNombreCompleto = new Label();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblTituloForm = new Label();
            dgvUsuarios = new DataGridView();
            tpBitacora = new TabPage();
            btnBorrarBitacora = new Button();
            btnRefrescarLogs = new Button();
            dgvBitacora = new DataGridView();
            pnlContenedorTab.SuspendLayout();
            tcUsuarios.SuspendLayout();
            tpGestion.SuspendLayout();
            pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tpBitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            SuspendLayout();
            // 
            // pnlContenedorTab
            // 
            pnlContenedorTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlContenedorTab.BackColor = Color.FromArgb(30, 30, 30);
            pnlContenedorTab.Controls.Add(tcUsuarios);
            pnlContenedorTab.Location = new Point(400, 30);
            pnlContenedorTab.Name = "pnlContenedorTab";
            pnlContenedorTab.Size = new Size(1200, 900);
            pnlContenedorTab.TabIndex = 0;
            // 
            // tcUsuarios
            // 
            tcUsuarios.Controls.Add(tpGestion);
            tcUsuarios.Controls.Add(tpBitacora);
            tcUsuarios.Dock = DockStyle.Fill;
            tcUsuarios.Font = new Font("Arial Rounded MT Bold", 14F);
            tcUsuarios.ItemSize = new Size(350, 55);
            tcUsuarios.Location = new Point(0, 0);
            tcUsuarios.Name = "tcUsuarios";
            tcUsuarios.SelectedIndex = 0;
            tcUsuarios.Size = new Size(1200, 900);
            tcUsuarios.SizeMode = TabSizeMode.Fixed;
            tcUsuarios.TabIndex = 0;
            // 
            // tpGestion
            // 
            tpGestion.BackColor = Color.FromArgb(30, 30, 30);
            tpGestion.Controls.Add(pnlFormulario);
            tpGestion.Controls.Add(dgvUsuarios);
            tpGestion.ForeColor = Color.White;
            tpGestion.Location = new Point(4, 59);
            tpGestion.Name = "tpGestion";
            tpGestion.Size = new Size(1192, 837);
            tpGestion.TabIndex = 0;
            tpGestion.Text = "👥 CONTROL DE PERSONAL";
            // 
            // pnlFormulario
            // 
            pnlFormulario.BackColor = Color.FromArgb(35, 35, 35);
            pnlFormulario.Controls.Add(btnNuevo);
            pnlFormulario.Controls.Add(btnBuscarUsuario);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnActualizar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(cmbRol);
            pnlFormulario.Controls.Add(lblRol);
            pnlFormulario.Controls.Add(txtNombreCompleto);
            pnlFormulario.Controls.Add(lblNombreCompleto);
            pnlFormulario.Controls.Add(txtContrasena);
            pnlFormulario.Controls.Add(lblContrasena);
            pnlFormulario.Controls.Add(txtUsuario);
            pnlFormulario.Controls.Add(lblUsuario);
            pnlFormulario.Controls.Add(lblTituloForm);
            pnlFormulario.Location = new Point(25, 25);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(380, 780);
            pnlFormulario.TabIndex = 1;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Arial Rounded MT Bold", 10F);
            btnNuevo.ForeColor = Color.FromArgb(0, 192, 192);
            btnNuevo.Location = new Point(257, 19);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(114, 30);
            btnNuevo.TabIndex = 13;
            btnNuevo.Text = "📄 NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnBuscarUsuario
            // 
            btnBuscarUsuario.Cursor = Cursors.Hand;
            btnBuscarUsuario.FlatAppearance.BorderSize = 0;
            btnBuscarUsuario.FlatStyle = FlatStyle.Flat;
            btnBuscarUsuario.Font = new Font("Arial", 12F);
            btnBuscarUsuario.Location = new Point(335, 110);
            btnBuscarUsuario.Name = "btnBuscarUsuario";
            btnBuscarUsuario.Size = new Size(26, 26);
            btnBuscarUsuario.TabIndex = 11;
            btnBuscarUsuario.Text = "🔍";
            btnBuscarUsuario.UseVisualStyleBackColor = true;
            btnBuscarUsuario.Click += btnBuscarUsuario_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderColor = Color.Crimson;
            btnEliminar.FlatAppearance.BorderSize = 2;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Arial Rounded MT Bold", 11F);
            btnEliminar.ForeColor = Color.Crimson;
            btnEliminar.Location = new Point(20, 500);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(340, 45);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "🗑️ QUITAR USUARIO";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderColor = Color.Goldenrod;
            btnActualizar.FlatAppearance.BorderSize = 2;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Arial Rounded MT Bold", 12F);
            btnActualizar.ForeColor = Color.Goldenrod;
            btnActualizar.Location = new Point(20, 440);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(340, 45);
            btnActualizar.TabIndex = 12;
            btnActualizar.Text = "🔄 ACTUALIZAR DATOS";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnGuardar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnGuardar.FlatAppearance.BorderSize = 2;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Arial Rounded MT Bold", 12F);
            btnGuardar.ForeColor = Color.FromArgb(0, 192, 192);
            btnGuardar.Location = new Point(20, 380);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(340, 45);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "💾 CREAR USUARIO";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Arial", 12F);
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Empleado", "Admi" });
            cmbRol.Location = new Point(20, 320);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(340, 26);
            cmbRol.TabIndex = 8;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Arial Rounded MT Bold", 11F);
            lblRol.ForeColor = Color.DarkGray;
            lblRol.Location = new Point(20, 295);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(138, 17);
            lblRol.TabIndex = 7;
            lblRol.Text = "Rol de Seguridad:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Font = new Font("Arial", 12F);
            txtNombreCompleto.Location = new Point(20, 250);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(340, 26);
            txtNombreCompleto.TabIndex = 6;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font = new Font("Arial Rounded MT Bold", 11F);
            lblNombreCompleto.ForeColor = Color.DarkGray;
            lblNombreCompleto.Location = new Point(20, 225);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(144, 17);
            lblNombreCompleto.TabIndex = 5;
            lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Arial", 12F);
            txtContrasena.Location = new Point(20, 180);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(340, 26);
            txtContrasena.TabIndex = 4;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Arial Rounded MT Bold", 11F);
            lblContrasena.ForeColor = Color.DarkGray;
            lblContrasena.Location = new Point(20, 155);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(98, 17);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Arial", 12F);
            txtUsuario.Location = new Point(20, 110);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(310, 26);
            txtUsuario.TabIndex = 2;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Arial Rounded MT Bold", 11F);
            lblUsuario.ForeColor = Color.DarkGray;
            lblUsuario.Location = new Point(20, 85);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(154, 17);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Nombre de Usuario:";
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(0, 192, 192);
            lblTituloForm.Location = new Point(15, 23);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(239, 18);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "REGISTRO DE EMPLEADO";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 192, 192);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.GridColor = Color.FromArgb(50, 50, 50);
            dgvUsuarios.Location = new Point(430, 25);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(730, 780);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // tpBitacora
            // 
            tpBitacora.BackColor = Color.FromArgb(30, 30, 30);
            tpBitacora.Controls.Add(btnBorrarBitacora);
            tpBitacora.Controls.Add(btnRefrescarLogs);
            tpBitacora.Controls.Add(dgvBitacora);
            tpBitacora.Location = new Point(4, 59);
            tpBitacora.Name = "tpBitacora";
            tpBitacora.Size = new Size(1192, 837);
            tpBitacora.TabIndex = 1;
            tpBitacora.Text = "📜 BITÁCORA DE ENTRADAS";
            // 
            // btnBorrarBitacora
            // 
            btnBorrarBitacora.BackColor = Color.FromArgb(30, 30, 30);
            btnBorrarBitacora.Cursor = Cursors.Hand;
            btnBorrarBitacora.FlatAppearance.BorderColor = Color.Crimson;
            btnBorrarBitacora.FlatAppearance.BorderSize = 2;
            btnBorrarBitacora.FlatStyle = FlatStyle.Flat;
            btnBorrarBitacora.Font = new Font("Arial Rounded MT Bold", 11F);
            btnBorrarBitacora.ForeColor = Color.Crimson;
            btnBorrarBitacora.Location = new Point(665, 760);
            btnBorrarBitacora.Name = "btnBorrarBitacora";
            btnBorrarBitacora.Size = new Size(240, 45);
            btnBorrarBitacora.TabIndex = 2;
            btnBorrarBitacora.Text = "⚠️ LIMPIAR HISTORIAL";
            btnBorrarBitacora.UseVisualStyleBackColor = false;
            btnBorrarBitacora.Click += btnBorrarBitacora_Click;
            // 
            // btnRefrescarLogs
            // 
            btnRefrescarLogs.BackColor = Color.FromArgb(30, 30, 30);
            btnRefrescarLogs.Cursor = Cursors.Hand;
            btnRefrescarLogs.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnRefrescarLogs.FlatAppearance.BorderSize = 2;
            btnRefrescarLogs.FlatStyle = FlatStyle.Flat;
            btnRefrescarLogs.Font = new Font("Arial Rounded MT Bold", 12F);
            btnRefrescarLogs.ForeColor = Color.White;
            btnRefrescarLogs.Location = new Point(925, 762);
            btnRefrescarLogs.Name = "btnRefrescarLogs";
            btnRefrescarLogs.Size = new Size(240, 45);
            btnRefrescarLogs.TabIndex = 1;
            btnRefrescarLogs.Text = "🔄 ACTUALIZAR REGISTROS";
            btnRefrescarLogs.UseVisualStyleBackColor = false;
            btnRefrescarLogs.Click += btnRefrescarLogs_Click;
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBitacora.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvBitacora.BorderStyle = BorderStyle.None;
            dgvBitacora.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle2.ForeColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBitacora.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBitacora.GridColor = Color.FromArgb(50, 50, 50);
            dgvBitacora.Location = new Point(25, 25);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.Size = new Size(1140, 710);
            dgvBitacora.TabIndex = 0;
            // 
            // UC_Usuarios
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(pnlContenedorTab);
            Name = "UC_Usuarios";
            Size = new Size(1706, 967);
            pnlContenedorTab.ResumeLayout(false);
            tcUsuarios.ResumeLayout(false);
            tpGestion.ResumeLayout(false);
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tpBitacora.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContenedorTab;
        private TabControl tcUsuarios;
        private TabPage tpGestion;
        private TabPage tpBitacora;
        private DataGridView dgvUsuarios;
        private Panel pnlFormulario;
        private Label lblTituloForm;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private TextBox txtContrasena;
        private Label lblContrasena;
        private TextBox txtNombreCompleto;
        private Label lblNombreCompleto;
        private ComboBox cmbRol;
        private Label lblRol;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnGuardar;
        private DataGridView dgvBitacora;
        private Button btnRefrescarLogs;
        private Button btnBuscarUsuario;
        private Button btnNuevo;
        private Button btnBorrarBitacora;
    }
}