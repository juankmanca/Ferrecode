using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Productos.Events
{
    public sealed record CreateProductoDomainEvent(Guid IDProducto) : IDomainEvent
    {
    }
}
