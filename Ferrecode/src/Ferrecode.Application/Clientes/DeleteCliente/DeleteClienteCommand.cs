using Ferrecode.Application.Abstractions.Messaging;

namespace Ferrecode.Application.Clientes.DeleteCliente
{
    public sealed record DeleteClienteCommand(Guid ID) : ICommand
    {
    }
}
