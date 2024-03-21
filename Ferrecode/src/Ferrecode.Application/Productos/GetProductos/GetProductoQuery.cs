using Ferrecode.Application.Abstractions.Messaging;

namespace Ferrecode.Application.Productos.GetProductos
{
    public sealed record GetProductoQuery(Guid IDProducto) : IQuery<GetProductoResponse>
    {
    }
}
