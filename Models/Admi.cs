using System.Windows.Forms;

namespace Carniceria.Models
{
    // HERENCIA DE CLASES
    public class Admi : Usuario
    {
        public override string Rol
        {
            get
            {
                return "Admi";
            }
        }

        public override void ConfigurarPermisos( Button btnVenta, Button btnInventario, Button btnCorteDeCaja, Button btnUsuarios)
        {
            btnVenta.Visible = true;
            btnInventario.Visible = true;
            btnCorteDeCaja.Visible = true;
            btnUsuarios.Visible = true;
        }
    }
}
