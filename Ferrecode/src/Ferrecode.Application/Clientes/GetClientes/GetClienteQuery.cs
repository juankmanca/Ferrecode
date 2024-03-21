using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Clientes;

namespace Ferrecode.Application.Clientes.GetClientes
{
    public sealed record GetClienteQuery(Guid ID) : IQuery<GetClienteResponse>
    {
    }
}
