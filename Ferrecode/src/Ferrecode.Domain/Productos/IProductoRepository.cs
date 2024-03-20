using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Domain.Productos
{
    public interface IProductoRepository
    {
        Task<Producto?> GetByIdAsync(Guid id, CancellationToken cancellation = default);
        Task<Producto?> GetByNameAsync(string Nombre, CancellationToken cancellationToken = default);
        Task<Producto?> UpdateAsync(Producto producto, CancellationToken cancellationToken = default);
        Task<Producto?> DeleteAsync(Producto producto, CancellationToken cancellationToken = default);
        void Add(Producto producto);
        Task<PuntoDeVenta?> GetStoreById(Guid ID, CancellationToken cancellationToken = default);
    }
}
