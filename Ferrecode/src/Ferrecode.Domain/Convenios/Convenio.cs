using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Convenios
{
    public sealed class Convenio : Concepto
    {
        public Descripcion? Descripcion { get; private set; }
        public PorcentajeDescuento? PorcentajeDescuento { get; private set; }
        public Guid IDCliente { get; private set; }
        
        public Convenio(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion,
            Descripcion? descripcion, PorcentajeDescuento? porcentajeDescuento, Guid iDCliente) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
            Descripcion = descripcion;
            PorcentajeDescuento = porcentajeDescuento;
            IDCliente = iDCliente;
        }
    }
}
