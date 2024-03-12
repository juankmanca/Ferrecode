using Ferrecode.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ferrecode.Infrastructure.Repositories
{
    // hay que considerar usar mejor este caso ya que no todas las clases heredan de Concepto
    //internal abstract class Repository<T> 
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _DbContext.Set<T>().FirstOrDefaultAsync(User => User.ID == id);
        }

        public void Add(T entity)
        {
            _DbContext.Add(entity);
        }
    }
}
