namespace Carniceria.Interfaces
{
    public interface IProducto
    {
        string Id { get; set; }
        string Nombre { get; set; }
        decimal Precio { get; set; }
        decimal Stock { get; set; }
        string Categoria { get; set; }
        string UnidadMedida { get; set; }
    }

    // HERENCIA DE INTERFACES
    public interface IProductoMedible : IProducto
    {
        bool SeVendePorPieza { get; }
        string FormatearCantidad(decimal cantidad);
        bool CantidadValida(decimal cantidad);
    }
}
