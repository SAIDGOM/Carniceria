using Carniceria.Interfaces;

namespace Carniceria.Models
{
    // CLASES PROPIAS / HERENCIA DE INTERFACES
    public class ProductoRes : IProductoMedible
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Categoria { get; set; } = "Res";
        public string UnidadMedida { get; set; }

        public bool SeVendePorPieza
        {
            get
            {
                return UnidadMedida == "PZA";
            }
        }

        public string FormatearCantidad(decimal cantidad)
        {
            if (SeVendePorPieza)
            {
                return cantidad.ToString("N0") + " PZA";
            }

            return cantidad.ToString("N3") + " KG";
        }

        public bool CantidadValida(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                return false;
            }

            if (SeVendePorPieza)
            {
                if (cantidad % 1 != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

    // CLASES PROPIAS / HERENCIA DE INTERFACES
    public class ProductoCerdo : IProductoMedible
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Categoria { get; set; } = "Cerdo";
        public string UnidadMedida { get; set; }

        public bool SeVendePorPieza
        {
            get
            {
                return UnidadMedida == "PZA";
            }
        }

        public string FormatearCantidad(decimal cantidad)
        {
            if (SeVendePorPieza)
            {
                return cantidad.ToString("N0") + " PZA";
            }

            return cantidad.ToString("N3") + " KG";
        }

        public bool CantidadValida(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                return false;
            }

            if (SeVendePorPieza)
            {
                if (cantidad % 1 != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }


    // CLASES PROPIAS / HERENCIA DE INTERFACES:
    public class ProductoOtros : IProductoMedible
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Categoria { get; set; }
        public string UnidadMedida { get; set; }
        public bool SeVendePorPieza
        {
            get
            {
                return UnidadMedida == "PZA";
            }
        }

        public string FormatearCantidad(decimal cantidad)
        {
            if (SeVendePorPieza)
            {
                return cantidad.ToString("N0") + " PZA";
            }

            return cantidad.ToString("N3") + " KG";
        }

        public bool CantidadValida(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                return false;
            }

            if (SeVendePorPieza)
            {
                if (cantidad % 1 != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
