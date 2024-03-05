using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Producto.Events
{
    public sealed record CreateProductoDomainEvent(Guid IDProducto) : IDomainEvent
    {
    }
}
