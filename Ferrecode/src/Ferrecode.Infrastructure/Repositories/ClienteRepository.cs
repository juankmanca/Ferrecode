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

        public async Task<Cliente?> GetByDocAsync(string documento, CancellationToken cancellationToken = default)
        {
            // TODO: Como arreglar esta validacion???
            var cliente = await _DbContext.Set<Cliente>().FirstOrDefaultAsync(x => x.Documento!.NumeroDocumento! == documento && x.Status, cancellationToken);

            return cliente;
        }
    }
}
