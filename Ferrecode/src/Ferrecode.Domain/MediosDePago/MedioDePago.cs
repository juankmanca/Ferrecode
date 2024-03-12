using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.MediosDePago
{
    public sealed class MedioDePago : Concepto
    {
        public ValorMaxPorDia? ValorMaxPorDia { get; private set; }
        public Descripcion? Descripcion { get; private set; }

        public MedioDePago(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion,
            ValorMaxPorDia? valorMaxPorDia, Descripcion? descripcion) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
            ValorMaxPorDia = valorMaxPorDia;
            Descripcion = descripcion;
        }
    }
}
