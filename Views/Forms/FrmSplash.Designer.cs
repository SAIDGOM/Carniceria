using System.Drawing;
using System.Windows.Forms;

namespace Carniceria
{
    partial class FrmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplash));
            picLogo = new PictureBox();
            lblCargando = new Label();
            pnlProgreso = new Panel();
            lblTitulo = new Label();
            timerSplash = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Location = new Point(147, 42);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(320, 320);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblCargando
            // 
            lblCargando.AutoSize = true;
            lblCargando.Font = new Font("Arial Rounded MT Bold", 11F);
            lblCargando.ForeColor = Color.DarkGray;
            lblCargando.Location = new Point(240, 345);
            lblCargando.Name = "lblCargando";
            lblCargando.Size = new Size(150, 17);
            lblCargando.TabIndex = 1;
            lblCargando.Text = "Iniciando sistema...";
            // 
            // pnlProgreso
            // 
            pnlProgreso.BackColor = Color.FromArgb(0, 192, 192);
            pnlProgreso.Location = new Point(0, 395);
            pnlProgreso.Name = "pnlProgreso";
            pnlProgreso.Size = new Size(600, 5);
            pnlProgreso.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(2, 305);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(600, 30);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "MEGA CARNICERÍA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerSplash
            // 
            timerSplash.Interval = 3000;
            timerSplash.Tick += timerSplash_Tick;
            // 
            // FrmSplash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(600, 400);
            Controls.Add(lblTitulo);
            Controls.Add(pnlProgreso);
            Controls.Add(lblCargando);
            Controls.Add(picLogo);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSplash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSplash";
            Load += FrmSplash_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label lblCargando;
        private Panel pnlProgreso;
        private Label lblTitulo;
        private System.Windows.Forms.Timer timerSplash;
    }
}