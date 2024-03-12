using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Infrastructure.Repositories
{
    internal sealed class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task DeleteProducto(Producto producto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task EditProductoAsync(Producto producto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetByNameAsync(string Nombre)
        {
            throw new NotImplementedException();
        }

        public Task<PuntoDeVenta> GetStoreById(Guid ID)
        {
            throw new NotImplementedException();
        }
    }
}
