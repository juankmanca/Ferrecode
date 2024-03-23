using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Application.Productos.ManagmentInventory;
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

            // Validamos que no exita el usuario
            Cliente? clienteExistente = await _clienteRepository.GetByDocAsync(request.nombre!, cancellationToken);
            if (clienteExistente is not null) return Result.Failure<Guid>(ClienteErrors.Duplicated);

            var cliente = Cliente.Create(
                    request.nombre,
                    request.telefono,
                    request.documento,
                    request.direccion,
                    request.email,
                    request.IDPuntoDeVenta
                );

            // Validacion de cedula
            var validDocument = cliente.Documento!.IsValid();
            if (!validDocument) return Result.Failure<Guid>(ClienteErrors.InvalidDocuemnt);

            var validator = new CreateClienteCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.FirstOrDefault();

                return Result.Failure<Guid>(new Error(error!.ErrorCode, error!.ErrorMessage));
            }

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
