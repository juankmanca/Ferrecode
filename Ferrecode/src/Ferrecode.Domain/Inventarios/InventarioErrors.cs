using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Inventarios
{
    public static class InventarioErrors
    {
        public static Error NotFound = new("Inventario.NotFound", "Producto no econtrado en el Inventario");
        public static Error Overlap = new("Inventario.Overlap", "El Stock esta siendo tomado por dos o mas clientes al mismo tiempo en la misma fecha");
    }
}
