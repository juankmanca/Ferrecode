using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Clientes;

namespace Ferrecode.Application.Clientes.DeleteCliente
{
    internal class DeleteClienteCommandHandler : ICommandHandler<DeleteClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.ID, cancellationToken);
            if (cliente is null) return Result.Failure(ClienteErrors.NotFound);

            cliente.Status = false;

            await _clienteRepository.UpdateAsync(cliente);

            try
            {
                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure<Guid>(new Error("ErrorInesperado", ex.Message));
            }
        }
    }
}
