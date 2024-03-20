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

        public async Task<Producto?> GetByNameAsync(string Nombre, CancellationToken cancellationToken = default)
        {
            var product = await _DbContext.Set<Producto>().FirstOrDefaultAsync(x => x.Nombre!.ToLower() == Nombre.ToLower(), cancellationToken);

            return product;
        }

        public async Task<PuntoDeVenta?> GetStoreById(Guid ID, CancellationToken cancellationToken = default)
        {
            var store = await _DbContext.Set<PuntoDeVenta>().FirstOrDefaultAsync(x => x.ID == ID, cancellationToken);

            return store;
        }
    }
}
