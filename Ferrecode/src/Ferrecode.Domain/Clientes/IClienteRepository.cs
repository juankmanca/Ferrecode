namespace Ferrecode.Domain.Clientes
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(Guid id, CancellationToken cancellation = default);
        Task<Cliente?> GetByNameAsync(string Nombre, CancellationToken cancellationToken = default);
        Task<Cliente?> UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default);
        Task<Cliente?> DeleteAsync(Cliente cliente, CancellationToken cancellationToken = default);
        void Add(Cliente cliente);
    }
}
