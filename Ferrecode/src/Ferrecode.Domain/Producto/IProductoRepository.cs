namespace Ferrecode.Domain.Producto
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task EditProductoAsync(Producto producto, CancellationToken cancellationToken = default);
        Task DeleteProducto(Producto producto, CancellationToken cancellationToken = default);
        void Add(Producto producto);
    }
}
