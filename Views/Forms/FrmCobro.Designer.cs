using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    partial class FrmCobro
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
            lblTitulo1 = new Label();
            lblMontoTotal = new Label();
            lblTitulo2 = new Label();
            txtEfectivo = new TextBox();
            lblTitulo3 = new Label();
            lblMontoCambio = new Label();
            btnFinalizar = new Button();
            rbEfectivo = new RadioButton();
            rbTransferencia = new RadioButton();
            SuspendLayout();
            // 
            // lblTitulo1
            // 
            lblTitulo1.AutoSize = true;
            lblTitulo1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            lblTitulo1.ForeColor = System.Drawing.Color.LightGray;
            lblTitulo1.Location = new System.Drawing.Point(40, 20);
            lblTitulo1.Name = "lblTitulo1";
            lblTitulo1.Size = new System.Drawing.Size(161, 18);
            lblTitulo1.TabIndex = 0;
            lblTitulo1.Text = "TOTAL A COBRAR:";
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F);
            lblMontoTotal.ForeColor = System.Drawing.Color.White;
            lblMontoTotal.Location = new System.Drawing.Point(35, 45);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new System.Drawing.Size(155, 55);
            lblMontoTotal.TabIndex = 1;
            lblMontoTotal.Text = "$0.00";
            // 
            // rbEfectivo
            // 
            rbEfectivo.AutoSize = true;
            rbEfectivo.Checked = true;
            rbEfectivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            rbEfectivo.ForeColor = System.Drawing.Color.White;
            rbEfectivo.Location = new System.Drawing.Point(40, 120);
            rbEfectivo.Name = "rbEfectivo";
            rbEfectivo.Size = new System.Drawing.Size(144, 30);
            rbEfectivo.TabIndex = 7;
            rbEfectivo.TabStop = true;
            rbEfectivo.Text = "💵 Efectivo";
            rbEfectivo.UseVisualStyleBackColor = true;
            rbEfectivo.CheckedChanged += new System.EventHandler(rbMetodoPago_CheckedChanged);
            // 
            // rbTransferencia
            // 
            rbTransferencia.AutoSize = true;
            rbTransferencia.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            rbTransferencia.ForeColor = System.Drawing.Color.White;
            rbTransferencia.Location = new System.Drawing.Point(210, 120);
            rbTransferencia.Name = "rbTransferencia";
            rbTransferencia.Size = new System.Drawing.Size(207, 30);
            rbTransferencia.TabIndex = 8;
            rbTransferencia.Text = "📱 Transferencia";
            rbTransferencia.UseVisualStyleBackColor = true;
            rbTransferencia.CheckedChanged += new System.EventHandler(rbMetodoPago_CheckedChanged);
            // 
            // lblTitulo2
            // 
            lblTitulo2.AutoSize = true;
            lblTitulo2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            lblTitulo2.ForeColor = System.Drawing.Color.LightGray;
            lblTitulo2.Location = new System.Drawing.Point(40, 180);
            lblTitulo2.Name = "lblTitulo2";
            lblTitulo2.Size = new System.Drawing.Size(181, 18);
            lblTitulo2.TabIndex = 2;
            lblTitulo2.Text = "EFECTIVO RECIBIDO:";
            // 
            // txtEfectivo
            // 
            txtEfectivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28F);
            txtEfectivo.Location = new System.Drawing.Point(40, 205);
            txtEfectivo.MaxLength = 10;
            txtEfectivo.Name = "txtEfectivo";
            txtEfectivo.Size = new System.Drawing.Size(400, 51);
            txtEfectivo.TabIndex = 3;
            txtEfectivo.TextAlign = HorizontalAlignment.Center;
            txtEfectivo.ContextMenuStrip = new ContextMenuStrip(components);
            txtEfectivo.TextChanged += new System.EventHandler(txtEfectivo_TextChanged);
            txtEfectivo.KeyDown += new KeyEventHandler(txtEfectivo_KeyDown);
            txtEfectivo.KeyPress += new KeyPressEventHandler(txtEfectivo_KeyPress);
            // 
            // lblTitulo3
            // 
            lblTitulo3.AutoSize = true;
            lblTitulo3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            lblTitulo3.ForeColor = System.Drawing.Color.LightGray;
            lblTitulo3.Location = new System.Drawing.Point(40, 290);
            lblTitulo3.Name = "lblTitulo3";
            lblTitulo3.Size = new System.Drawing.Size(157, 18);
            lblTitulo3.TabIndex = 4;
            lblTitulo3.Text = "SU CAMBIO ES DE:";
            // 
            // lblMontoCambio
            // 
            lblMontoCambio.AutoSize = true;
            lblMontoCambio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F);
            lblMontoCambio.ForeColor = System.Drawing.Color.White;
            lblMontoCambio.Location = new System.Drawing.Point(35, 315);
            lblMontoCambio.Name = "lblMontoCambio";
            lblMontoCambio.Size = new System.Drawing.Size(155, 55);
            lblMontoCambio.TabIndex = 5;
            lblMontoCambio.Text = "$0.00";
            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            btnFinalizar.Enabled = false;
            btnFinalizar.FlatAppearance.BorderSize = 0;
            btnFinalizar.FlatStyle = FlatStyle.Flat;
            btnFinalizar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            btnFinalizar.ForeColor = System.Drawing.Color.White;
            btnFinalizar.Location = new System.Drawing.Point(40, 400);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new System.Drawing.Size(400, 60);
            btnFinalizar.TabIndex = 6;
            btnFinalizar.Text = "✔️ COMPLETAR VENTA";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += new System.EventHandler(btnFinalizar_Click);
            // 
            // FrmCobro
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            ClientSize = new System.Drawing.Size(484, 490);
            Controls.Add(rbTransferencia);
            Controls.Add(rbEfectivo);
            Controls.Add(btnFinalizar);
            Controls.Add(lblMontoCambio);
            Controls.Add(lblTitulo3);
            Controls.Add(txtEfectivo);
            Controls.Add(lblTitulo2);
            Controls.Add(lblMontoTotal);
            Controls.Add(lblTitulo1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCobro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PAGO EN CAJA";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label lblTitulo1;
        private Label lblMontoTotal;
        private Label lblTitulo2;
        private TextBox txtEfectivo;
        private Label lblTitulo3;
        private Label lblMontoCambio;
        private Button btnFinalizar;
        private RadioButton rbEfectivo;
        private RadioButton rbTransferencia;
    }
}