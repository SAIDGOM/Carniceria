using System;
using System.Windows.Forms;

namespace Carniceria
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();

            using (var ms = new System.IO.MemoryStream(Carniceria.Properties.Resources.icono_carniceria))
            {
                Icon = new System.Drawing.Icon(ms);
            }
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            // EXCEPCIONES
            try
            {
                picLogo.Image = Properties.Resources.logo_carniceria;
            }
            catch
            {
                MessageBox.Show("Error al cargar el logo de la carnicería.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timerSplash.Start();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            timerSplash.Stop();
            Close();
        }
    }
}