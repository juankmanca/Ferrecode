using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Infrastructure.Repositories
{
    internal class InventarioRepository : Repository<Inventario>, IInventarioRepository
    {
        public InventarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
