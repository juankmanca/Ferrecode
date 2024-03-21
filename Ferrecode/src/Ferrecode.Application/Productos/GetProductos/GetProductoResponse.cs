namespace Ferrecode.Application.Productos.GetProductos
{
    // Aqui se utilizan datos primitivos
    public sealed class GetProductoResponse
    {
        public Guid ID { get; init; }
        public string Nombre { get; init; } = string.Empty;
        public decimal? Precio { get; init; }

    }
}
