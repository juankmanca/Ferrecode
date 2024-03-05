using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Producto.Events
{
    public sealed record DeleteProductDomainEvent(Guid IDProducto) : IDomainEvent
    {
    }
}
