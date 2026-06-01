using System.Windows.Forms;

namespace Carniceria.Models
{
    // HERENCIA DE CLASES
    public class Empleado : Usuario
    {
        public override string Rol
        {
            get
            {
                return "Empleado";
            }
        }

        public override void ConfigurarPermisos(Button btnVenta, Button btnInventario, Button btnCorteDeCaja, Button btnUsuarios)
        {
            btnVenta.Visible = true;
            btnInventario.Visible = true;
            btnCorteDeCaja.Visible = false;
            btnUsuarios.Visible = false;
        }
    }
}
