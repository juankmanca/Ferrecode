using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.PuntosDeVenta
{
    public static class PuntoDeVentaErrors
    {
        public static Error NotFound = new("PuntoDeVenta.NotFound", "no existe el punto de venta");
    }
}
