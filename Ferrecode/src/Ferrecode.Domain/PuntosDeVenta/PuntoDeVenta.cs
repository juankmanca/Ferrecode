using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.PuntosDeVenta
{
    public sealed class PuntoDeVenta : Concepto
    {
        private PuntoDeVenta()
        {
            
        }

        public PuntoDeVenta(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
        }
    }
}
