namespace Ferrecode.Application.Productos.GetProductos
{
    public sealed class GetProductosResponse
    {
        public List<ProductoSQLResponse> products { get; set; } = new List<ProductoSQLResponse>(); 
    }

    public sealed class ProductoSQLResponse
    {
        public Guid ID { get; init; }
        public string Nombre { get; init; } = string.Empty;
        public decimal? Precio { get; init; }
        public int Cantidad { get; init; }
    }

}
