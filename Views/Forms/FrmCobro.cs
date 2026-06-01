using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Carniceria.Views
{
    public partial class FrmCobro : Form
    {
        private decimal _totalCobrar;
        public bool VentaExitosa { get; private set; } = false;

        public string MetodoPagoSeleccionado { get; private set; } = "Efectivo";

        public FrmCobro(decimal total)
        {
            InitializeComponent();
            _totalCobrar = total;
            lblMontoTotal.Text = _totalCobrar.ToString("C2");
            btnFinalizar.Enabled = false;
        }

        private void rbMetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransferencia.Checked)
            {
                MetodoPagoSeleccionado = "Transferencia";
                txtEfectivo.Enabled = false;
                txtEfectivo.Text = _totalCobrar.ToString("0.##");
                lblMontoCambio.Text = "$0.00";
                lblMontoCambio.ForeColor = Color.SpringGreen;
                btnFinalizar.Enabled = true;
            }
            else
            {
                MetodoPagoSeleccionado = "Efectivo";
                txtEfectivo.Enabled = true;
                txtEfectivo.Clear();
                btnFinalizar.Enabled = false;
                txtEfectivo.Focus();
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("El efectivo solo acepta números.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txtEfectivo.Text.Contains(".") || txtEfectivo.Text.Contains(",")))
            {
                e.Handled = true;
                MessageBox.Show("El efectivo solo puede tener un decimal.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ValidarPuntoDecimal(KeyPressEventArgs e)
        {
            if (txtEfectivo.Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("El efectivo solo puede tener un decimal.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtEfectivo.Text.Contains(","))
            {
                e.Handled = true;
                MessageBox.Show("El efectivo solo puede tener un decimal.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.E && rbEfectivo.Checked)
            {
                e.SuppressKeyPress = true;
                txtEfectivo.Text = _totalCobrar.ToString("0.##");
                txtEfectivo.SelectionStart = txtEfectivo.Text.Length;
            }
            else if (e.KeyCode == Keys.C || e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (btnFinalizar.Enabled)
                {
                    IntentarCobrar();
                }
            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (rbTransferencia.Checked) return;

            if (string.IsNullOrWhiteSpace(txtEfectivo.Text))
            {
                lblMontoCambio.Text = "$0.00";
                lblMontoCambio.ForeColor = Color.White;
                btnFinalizar.Enabled = false;
                return;
            }

            try
            {
                if (decimal.TryParse(txtEfectivo.Text, out decimal efectivoRecibido))
                {
                    decimal cambio = efectivoRecibido - _totalCobrar;

                    if (cambio >= 0)
                    {
                        lblMontoCambio.Text = cambio.ToString("C2");
                        lblMontoCambio.ForeColor = Color.SpringGreen;
                        btnFinalizar.Enabled = true;
                    }
                    else
                    {
                        lblMontoCambio.Text = "Faltan " + Math.Abs(cambio).ToString("C2");
                        lblMontoCambio.ForeColor = Color.Crimson;
                        btnFinalizar.Enabled = false;
                    }
                }
                else
                {
                    lblMontoCambio.Text = "Monto inválido";
                    lblMontoCambio.ForeColor = Color.Red;
                    btnFinalizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al calcular el cambio: " + ex.Message);
                lblMontoCambio.Text = "Error";
                lblMontoCambio.ForeColor = Color.Red;
                btnFinalizar.Enabled = false;
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            IntentarCobrar();
        }

        private void IntentarCobrar()
        {
            // EXCEPCIONES
            try
            {
                if (string.IsNullOrWhiteSpace(txtEfectivo.Text))
                {
                    MessageBox.Show("Debes ingresar la cantidad con la que paga el cliente.", "Atención en Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEfectivo.Focus();
                    return;
                }

                if (!decimal.TryParse(txtEfectivo.Text.Replace(",", "."), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out decimal efectivoRecibido))
                {
                    MessageBox.Show("El formato del monto ingresado no es válido.", "Atención en Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEfectivo.Focus();
                    txtEfectivo.SelectAll();
                    return;
                }

                if (efectivoRecibido <= 0)
                {
                    MessageBox.Show("El monto recibido debe ser mayor que cero.", "Atención en Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEfectivo.Focus();
                    txtEfectivo.SelectAll();
                    return;
                }

                if (efectivoRecibido < _totalCobrar)
                {
                    MessageBox.Show($"Falta dinero. El efectivo ingresado ({efectivoRecibido:C2}) no cubre el total de la cuenta ({_totalCobrar:C2}).", "Atención en Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEfectivo.Focus();
                    txtEfectivo.SelectAll();
                    return;
                }

                VentaExitosa = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al procesar el cobro: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
