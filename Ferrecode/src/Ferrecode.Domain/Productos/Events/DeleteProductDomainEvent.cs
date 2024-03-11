using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Productos.Events
{
    public sealed record DeleteProductDomainEvent(Guid IDProducto) : IDomainEvent
    {
    }
}
