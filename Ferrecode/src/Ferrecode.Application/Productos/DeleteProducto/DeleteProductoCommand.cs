using Ferrecode.Application.Abstractions.Messaging;

namespace Ferrecode.Application.Productos.DeleteProducto
{
    public record DeleteProductoCommand(Guid IDProducto) : ICommand<Domain.Productos.Producto>
    {

    }
}
