using Ferrecode.Application.Abstractions.Messaging;

namespace Ferrecode.Application.Productos.ManagmentInventory
{
    public record UpdateStockCommand(Guid ID, int Cantidad) : ICommand
    {
    }
}
