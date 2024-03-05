using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Producto.Events
{
    public sealed record EditProductoDomainEvent(Guid IDProducto) : IDomainEvent
    {
    }
}
