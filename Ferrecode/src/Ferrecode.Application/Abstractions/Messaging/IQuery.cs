using Ferrecode.Domain.Abstractions;
using MediatR;

namespace Ferrecode.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
