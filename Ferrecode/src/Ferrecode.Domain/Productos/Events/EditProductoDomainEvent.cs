using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Productos.Events
{
    public sealed record EditProductoDomainEvent(Guid IDProducto) : IDomainEvent
    {
    }
}
