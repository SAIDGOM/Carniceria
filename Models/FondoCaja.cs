using System;

namespace Carniceria.Models
{
    // CLASE PROPIA
    public class FondoCaja
    {
        public DateTime Fecha { get; set; }
        public decimal MontoInicial { get; set; }
        public string Responsable { get; set; }
        public DateTime Actualizado { get; set; }
    }
}
