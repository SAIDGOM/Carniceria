using System;

namespace Carniceria.Models
{
    // CLASE PROPIA
    public class Venta
    {
        public string IdProducto { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal KilosVendidos { get; set; }
        public decimal TotalPagado { get; set; }
        public string Vendedor { get; set; }
        public string MetodoPago { get; set; }
    }
}
