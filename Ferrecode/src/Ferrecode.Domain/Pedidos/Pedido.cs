using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Pedidos
{
    public sealed class Pedido : Concepto
    {
        public DateTime FechaCierre { get; private set; }
        public DateTime FechaFacturacion { get; private set; }
        public Guid IDCliente { get; private set; }
        public Pedido(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion,
            DateTime fechaCierre, DateTime fechaFacturacion, Guid iDCliente) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
            FechaCierre = fechaCierre;
            FechaFacturacion = fechaFacturacion;
            IDCliente = iDCliente;
        }
    }
}
