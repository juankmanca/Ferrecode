using Ferrecode.Domain.Clientes;
using Microsoft.EntityFrameworkCore;

namespace Ferrecode.Infrastructure.Repositories
{
    internal sealed class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<Cliente?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cliente = await _DbContext.Set<Cliente>().FirstOrDefaultAsync(x =>  x.ID == id && x.Status, cancellationToken);

            return cliente;
        }

        public async Task<Cliente?> GetByNameAsync(string Nombre, CancellationToken cancellationToken = default)
        {
            var cliente = await _DbContext.Set<Cliente>().FirstOrDefaultAsync(x => x.Nombre!.ToLower() == Nombre.ToLower() && x.Status, cancellationToken);

            return cliente;
        }
    }
}
