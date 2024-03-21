namespace Ferrecode.Domain.DetallePedidos
{
    public sealed class DetallePedido
    {
        public Guid ID { get; private set; }
        public Guid IDPedido { get; private set; }
        public Guid IDProducto { get; private set; }
        public Cantidad? Cantidad { get; private set; }
    }
}
