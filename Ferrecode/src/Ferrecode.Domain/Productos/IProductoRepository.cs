using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Domain.Productos
{
    public interface IProductoRepository
    {
        Task<Producto> GetByIdAsync(Guid id);
        Task<Producto?> GetByNameAsync(string Nombre);
        Task<List<Producto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task EditProductoAsync(Producto producto, CancellationToken cancellationToken = default);
        Task DeleteProducto(Producto producto, CancellationToken cancellationToken = default);
        void Add(Producto producto);
        Task<PuntoDeVenta?> GetStoreById(Guid ID);
    }
}
