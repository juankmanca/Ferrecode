using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Clientes;
using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Application.Clientes.CreateCliente
{
    internal class CreateClienteCommandHandler : ICommandHandler<CreateClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPuntoDeVentaRepository _puntoDeVentaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository, IPuntoDeVentaRepository puntoDeVentaRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _puntoDeVentaRepository = puntoDeVentaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            // Llamamos al repository que se encarga de guardar en la base de datos
            PuntoDeVenta? storeExists = await _puntoDeVentaRepository.GetByIdAsync(request.IDPuntoDeVenta, cancellationToken);
            if (storeExists is null) return Result.Failure<Guid>(PuntoDeVentaErrors.NotFound);

            var cliente = Cliente.Create(
                    request.nombre,
                    request.documento,
                    request.direccion,
                    request.email,
                    request.IDPuntoDeVenta
                );

            _clienteRepository.Add(cliente);

            try
            {
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(cliente.ID);
            }
            catch (Exception ex)
            {
                return Result.Failure<Guid>(new Error("ErrorInesperado", ex.Message));
            }
        }
    }
}
