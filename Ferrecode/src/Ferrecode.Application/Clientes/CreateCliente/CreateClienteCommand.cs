using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Clientes;

namespace Ferrecode.Application.Clientes.CreateCliente
{
    public sealed record CreateClienteCommand(

        string? nombre,
        Documento? documento, 
        Direccion? direccion, 
        Email? email,
        Guid IDPuntoDeVenta

        ) : ICommand<Guid>;
}
