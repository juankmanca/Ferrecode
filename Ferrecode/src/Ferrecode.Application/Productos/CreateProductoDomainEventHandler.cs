using Ferrecode.Domain.Productos.Events;
using MediatR;

namespace Ferrecode.Application.Productos
{
    public sealed class CreateProductoDomainEventHandler : INotificationHandler<CreateProductoDomainEvent>
    {
        public Task Handle(CreateProductoDomainEvent notification, CancellationToken cancellationToken)
        {
            // Modificar el Stock en caso de ser necesario
            return Task.CompletedTask;
        }
    }
}
