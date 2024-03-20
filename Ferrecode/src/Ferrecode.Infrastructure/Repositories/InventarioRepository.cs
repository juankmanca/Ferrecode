using Ferrecode.Domain.Inventarios;
using Microsoft.EntityFrameworkCore;

namespace Ferrecode.Infrastructure.Repositories
{
    internal class InventarioRepository : Repository<Inventario>, IInventarioRepository
    {
        public InventarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Inventario?> GetByProductIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var Inventory = await _DbContext.Set<Inventario>().FirstOrDefaultAsync(x => x.IDProducto == id, cancellationToken);

            return Inventory;
        }
    }
}
