namespace Ferrecode.Domain.Facturas
{
    public sealed class Factura
    {
        public Guid ID { get; private set; }
        public Guid IDCliente { get; private set; }
        public Guid IDPedido { get; private set; }
        public Guid IDMedioDePago { get; private set; }
        public Guid IDUsuario { get; private set; }
        public ValorTotal? ValorTotal { get; private set; }
        public RangoConsecutivosDIAN? RangoConsecutivosDIAN { get; private set; }
        public ResolucionDIAN? ResolucionDIAN { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public Factura(Guid iD, Guid iDCliente, Guid iDPedido, Guid iDMedioDePago, Guid iDUsuario, ValorTotal? valorTotal, RangoConsecutivosDIAN? rangoConsecutivosDIAN, ResolucionDIAN? resolucionDIAN, DateTime fechaCreacion)
        {
            ID = iD;
            IDCliente = iDCliente;
            IDPedido = iDPedido;
            IDMedioDePago = iDMedioDePago;
            IDUsuario = iDUsuario;
            ValorTotal = valorTotal;
            RangoConsecutivosDIAN = rangoConsecutivosDIAN;
            ResolucionDIAN = resolucionDIAN;
            FechaCreacion = fechaCreacion;
        }
    }
}
