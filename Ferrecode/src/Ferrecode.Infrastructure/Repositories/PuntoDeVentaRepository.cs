using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Infrastructure.Repositories
{
    internal class PuntoDeVentaRepository : Repository<PuntoDeVenta>, IPuntoDeVentaRepository
    {
        public PuntoDeVentaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
