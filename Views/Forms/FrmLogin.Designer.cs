namespace Carniceria.Views
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pnlLogin = new Panel();
            btnClose = new Button();
            btnEntrar = new Button();
            txtContraseña = new TextBox();
            txtUser = new TextBox();
            lblContraseña = new Label();
            lblUser = new Label();
            lblBienvenida = new Label();
            tlpEstructura = new TableLayoutPanel();
            pnlLogin.SuspendLayout();
            tlpEstructura.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.Anchor = AnchorStyles.None;
            pnlLogin.BackColor = Color.FromArgb(180, 20, 20, 20);
            pnlLogin.Controls.Add(btnClose);
            pnlLogin.Controls.Add(btnEntrar);
            pnlLogin.Controls.Add(txtContraseña);
            pnlLogin.Controls.Add(txtUser);
            pnlLogin.Controls.Add(lblContraseña);
            pnlLogin.Controls.Add(lblUser);
            pnlLogin.Controls.Add(lblBienvenida);
            pnlLogin.Location = new Point(83, 27);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Padding = new Padding(3);
            pnlLogin.Size = new Size(634, 394);
            pnlLogin.TabIndex = 0;
            pnlLogin.Paint += pnlLogin_Paint;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImageLayout = ImageLayout.None;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 16F);
            btnClose.ForeColor = Color.Transparent;
            btnClose.Location = new Point(592, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(39, 35);
            btnClose.TabIndex = 6;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.FromArgb(180, 40, 40, 40);
            btnEntrar.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnEntrar.FlatAppearance.BorderSize = 2;
            btnEntrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnEntrar.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Arial Rounded MT Bold", 16F);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(207, 323);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(200, 45);
            btnEntrar.TabIndex = 5;
            btnEntrar.Text = "ENTRAR";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = SystemColors.ButtonHighlight;
            txtContraseña.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.ForeColor = Color.Black;
            txtContraseña.Location = new Point(203, 238);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(215, 29);
            txtContraseña.TabIndex = 4;
            txtContraseña.TextAlign = HorizontalAlignment.Center;
            // 
            // txtUser
            // 
            txtUser.BackColor = SystemColors.ButtonHighlight;
            txtUser.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.ForeColor = Color.Gray;
            txtUser.Location = new Point(209, 128);
            txtUser.Multiline = true;
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(200, 29);
            txtUser.TabIndex = 3;
            txtUser.TextAlign = HorizontalAlignment.Center;
            // 
            // lblContraseña
            // 
            lblContraseña.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblContraseña.AutoSize = true;
            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.ForeColor = Color.WhiteSmoke;
            lblContraseña.Location = new Point(204, 201);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(221, 26);
            lblContraseña.TabIndex = 2;
            lblContraseña.Text = "🔐 CONTRASEÑA : ";
            lblContraseña.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.BackColor = Color.Transparent;
            lblUser.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.WhiteSmoke;
            lblUser.Location = new Point(225, 87);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(167, 26);
            lblUser.TabIndex = 1;
            lblUser.Text = "👤 USUARIO : ";
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBienvenida
            // 
            lblBienvenida.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblBienvenida.AutoSize = true;
            lblBienvenida.BackColor = Color.Transparent;
            lblBienvenida.BorderStyle = BorderStyle.FixedSingle;
            lblBienvenida.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(163, 17);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(305, 39);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "INICIO DE SESIÓN";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpEstructura
            // 
            tlpEstructura.BackColor = Color.FromArgb(150, 30, 30, 30);
            tlpEstructura.ColumnCount = 3;
            tlpEstructura.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlpEstructura.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tlpEstructura.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tlpEstructura.Controls.Add(pnlLogin, 1, 1);
            tlpEstructura.Dock = DockStyle.Fill;
            tlpEstructura.Location = new Point(0, 0);
            tlpEstructura.Name = "tlpEstructura";
            tlpEstructura.RowCount = 3;
            tlpEstructura.RowStyles.Add(new RowStyle(SizeType.Percent, 4.569688F));
            tlpEstructura.RowStyles.Add(new RowStyle(SizeType.Percent, 90.88602F));
            tlpEstructura.RowStyles.Add(new RowStyle(SizeType.Percent, 4.54430056F));
            tlpEstructura.Size = new Size(800, 450);
            tlpEstructura.TabIndex = 0;
            // 
            // FormLogin
            // 
            AcceptButton = btnEntrar;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = Properties.Resources.CarniceriaFondo;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpEstructura);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogin";
            WindowState = FormWindowState.Maximized;
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            tlpEstructura.ResumeLayout(false);
            ResumeLayout(false);



        }

        #endregion

        private Panel pnlLogin;
        private Button btnEntrar;
        private TextBox txtContraseña;
        private TextBox txtUser;
        private Label lblContraseña;
        private Label lblUser;
        private Label lblBienvenida;
        private TableLayoutPanel tlpEstructura;
        private Button btnClose;
    }
}