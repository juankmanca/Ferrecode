namespace Ferrecode.Domain.Inventarios
{
    public interface IInventarioRepository
    {
        Task<Inventario?> GetByProductIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Inventario?> UpdateAsync(Inventario entity, CancellationToken cancellationToken = default);
        void Add(Inventario inventario);
    }
}
