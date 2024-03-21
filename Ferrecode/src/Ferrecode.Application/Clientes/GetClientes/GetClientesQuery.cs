using Ferrecode.Application.Abstractions.Messaging;

namespace Ferrecode.Application.Clientes.GetClientes
{
    public sealed record GetClientesQuery(Guid IDPuntoDeVenta) : IQuery<GetClientesResponse>
    {
    }
}
