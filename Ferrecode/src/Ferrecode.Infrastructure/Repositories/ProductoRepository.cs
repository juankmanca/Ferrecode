using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Producto?> GetByNameAsync(string Nombre)
        {
            var product = await _DbContext.Set<Producto>().FirstOrDefaultAsync(x => x.Nombre!.ToLower() == Nombre.ToLower());

            return product;
        }

        public async Task<PuntoDeVenta?> GetStoreById(Guid ID)
        {
            var store = await _DbContext.Set<PuntoDeVenta>().FirstOrDefaultAsync(x => x.ID == ID);

            return store;
        }
    }
}
