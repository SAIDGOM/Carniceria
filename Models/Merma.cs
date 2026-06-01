using System;

namespace Carniceria.Models
{
    // CLASE PROPIA
    public class Merma
    {
        public DateTime Fecha { get; set; }
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal CantidadMerma
        {
            get
            {
                decimal merma = PesoBruto - PesoNeto;

                if (merma < 0)
                {
                    return 0;
                }

                return merma;
            }
        }

        public decimal PrecioUnitario { get; set; }
        public decimal ValorPerdido
        {
            get
            {
                return CantidadMerma * PrecioUnitario;
            }
        }
        public string UnidadMedida { get; set; } = "KG";
        public string Notas { get; set; }

        public string FormatearCantidad(decimal cantidad)
        {
            if (UnidadMedida == "PZA")
            {
                return cantidad.ToString("N0") + " PZA";
            }

            return cantidad.ToString("N3") + " KG";
        }
    }
}
