namespace Ferrecode.Domain.DetallePedido
{
    public sealed class DetallePedido
    {
        public Guid IDPedidos { get; private set; }
        public Guid IDProductos { get; private set; }
        public Cantidad? Cantidad { get; private set; }
    }
}
