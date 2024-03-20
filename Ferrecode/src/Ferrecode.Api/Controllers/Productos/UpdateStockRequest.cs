namespace Ferrecode.Api.Controllers.Productos
{
    public sealed record UpdateStockRequest
    {
        public Guid IDProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
