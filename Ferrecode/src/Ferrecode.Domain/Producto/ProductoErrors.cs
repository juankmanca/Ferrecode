using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Producto
{
    public static class ProductoErrors
    {
        public static Error NotFound = new ("Producto.NotFound", "No existe el producto con este id");
        public static Error Duplicated = new("Producto.Duplicated", "Este producto ya existe");
        public static Error Block = new("Producto.Block", "Este producto ya esta eliminado");
    }
}
