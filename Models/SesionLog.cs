using System;

namespace Carniceria.Models
{
    // CLASE PROPIA
    public class SesionLog
    {
        public string Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Accion { get; set; }
        public string Rol { get; set; }
        
    }
}
