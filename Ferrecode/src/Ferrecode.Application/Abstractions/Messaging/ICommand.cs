using Ferrecode.Domain.Abstractions;
using MediatR;

namespace Ferrecode.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {

    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }

    // Esta interfaz me permite en el futuro agregar constrains de Validación
    public interface IBaseCommand
    { }
}
