using Carniceria.Interfaces;
using System.Windows.Forms;

namespace Carniceria.Models
{
    // HERENCIA DE CLASES / HERENCIA DE INTERFACES
    public abstract class Usuario : IUsuario
    {
        public string Nombre { get; set; }
        public string Username { get; set; }
        public abstract string Rol { get; }
        public abstract void ConfigurarPermisos(
            Button btnVenta,
            Button btnInventario,
            Button btnCorteDeCaja,
            Button btnUsuarios);
    }
}
