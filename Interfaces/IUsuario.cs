using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Carniceria.Interfaces
{
    //HERENCIA DE INTERFACES
    public interface IUsuario
    {
        string Nombre { get; set; }

        string Username { get; }

        string Rol { get; }

        void ConfigurarPermisos(Button btnVenta, Button btnInventario, Button btnCorteDeCaja, Button btnUsuarios);
    }
}
