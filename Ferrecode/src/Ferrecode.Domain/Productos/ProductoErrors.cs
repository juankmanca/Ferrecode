using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Productos
{
    public static class ProductoErrors
    {
        public static Error NotFound = new ("Producto.NotFound", "No existe el producto con este id");
        public static Error ErrorSavingProduct = new ("Producto.ErrorInesperado", "Error inesperado guardando un nuevo producto en el inventario");
        public static Error Duplicated = new("Producto.Duplicated", "Este producto ya existe");
        public static Error Block = new("Producto.Block", "Este producto ya esta eliminado");
        public static Error Overlap = new Error("Producto.Overlap", "El Producto esta siendo tomado por dos o mas clientes al mismo tiempo en la misma fecha");

    }
}
