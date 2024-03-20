using Ferrecode.Application.Abstractions.Messaging;

namespace Ferrecode.Application.Productos.GetProductos
{
    public sealed record GetProductosQuery(Guid IDPuntoDeVenta) : IQuery<ProductosResponse>;
}

