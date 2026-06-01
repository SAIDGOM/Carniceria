namespace Carniceria.Views.Forms
{
    partial class FrmMerma
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
            this.lblTituloProducto = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.txtPesoBruto = new System.Windows.Forms.TextBox();
            this.txtPesoNeto = new System.Windows.Forms.TextBox();
            this.lblResultadoMerma = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.labelBruto = new System.Windows.Forms.Label();
            this.labelNeto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTituloProducto
            // 
            this.lblTituloProducto.AutoSize = true;
            this.lblTituloProducto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.lblTituloProducto.ForeColor = System.Drawing.Color.LightGray;
            this.lblTituloProducto.Location = new System.Drawing.Point(50, 30);
            this.lblTituloProducto.Text = "SELECCIONA PRODUCTO:";
            this.lblTituloProducto.Size = new System.Drawing.Size(200, 18);
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font = new System.Drawing.Font("Arial", 14F);
            this.cboProducto.Location = new System.Drawing.Point(50, 55);
            this.cboProducto.Size = new System.Drawing.Size(400, 30);
            // 
            // labelBruto
            // 
            this.labelBruto.AutoSize = true;
            this.labelBruto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.labelBruto.ForeColor = System.Drawing.Color.LightGray;
            this.labelBruto.Location = new System.Drawing.Point(50, 100);
            this.labelBruto.Text = "PESO BRUTO (KG):";
            // 
            // txtPesoBruto
            // 
            this.txtPesoBruto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.txtPesoBruto.Location = new System.Drawing.Point(50, 120);
            this.txtPesoBruto.Size = new System.Drawing.Size(190, 40);
            this.txtPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNeto
            // 
            this.labelNeto.AutoSize = true;
            this.labelNeto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.labelNeto.ForeColor = System.Drawing.Color.LightGray;
            this.labelNeto.Location = new System.Drawing.Point(260, 100);
            this.labelNeto.Text = "PESO NETO (KG):";
            // 
            // txtPesoNeto
            // 
            this.txtPesoNeto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.txtPesoNeto.Location = new System.Drawing.Point(260, 120);
            this.txtPesoNeto.Size = new System.Drawing.Size(190, 40);
            this.txtPesoNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblResultadoMerma
            // 
            this.lblResultadoMerma.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.lblResultadoMerma.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblResultadoMerma.Location = new System.Drawing.Point(50, 180);
            this.lblResultadoMerma.Size = new System.Drawing.Size(400, 40);
            this.lblResultadoMerma.Text = "MERMA: 0.000 KG";
            this.lblResultadoMerma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNotas
            // 
            this.txtNotas.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNotas.Location = new System.Drawing.Point(50, 240);
            this.txtNotas.Multiline = true;
            this.txtNotas.Size = new System.Drawing.Size(400, 80);
            this.txtNotas.PlaceholderText = "Notas (Ej. Grasa, Hueso...)";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(50, 350);
            this.btnGuardar.Size = new System.Drawing.Size(400, 60);
            this.btnGuardar.Text = "💾 GUARDAR MERMA";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // FrmMerma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.labelNeto);
            this.Controls.Add(this.labelBruto);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.lblResultadoMerma);
            this.Controls.Add(this.txtPesoNeto);
            this.Controls.Add(this.txtPesoBruto);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.lblTituloProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMerma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONTROL DE MERMA";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloProducto;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.TextBox txtPesoBruto;
        private System.Windows.Forms.TextBox txtPesoNeto;
        private System.Windows.Forms.Label lblResultadoMerma;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label labelBruto;
        private System.Windows.Forms.Label labelNeto;
    }
}