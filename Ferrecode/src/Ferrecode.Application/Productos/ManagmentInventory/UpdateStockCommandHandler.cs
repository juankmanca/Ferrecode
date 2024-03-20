using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Application.Exceptions;
using Ferrecode.Application.Productos.CreateProducto;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;
using FluentValidation;

namespace Ferrecode.Application.Productos.ManagmentInventory
{
    internal class UpdateStockCommandHandler : ICommandHandler<UpdateStockCommand>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStockCommandHandler(IProductoRepository productoRepository, IInventarioRepository inventarioRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _inventarioRepository = inventarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            Producto? product = await _productoRepository.GetByIdAsync(request.ID);
            if (product is null) return Result.Failure<Guid>(ProductoErrors.NotFound);

            Inventario? inventario = await _inventarioRepository.GetByProductIdAsync(product.ID);
            if (inventario is null) return Result.Failure<Guid>(ProductoErrors.NotFound);

            var validator = new UpdateStockCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.FirstOrDefault();

                return Result.Failure<Guid>(new Error(error!.ErrorCode, error!.ErrorMessage));
            }

            inventario.Cantidad = new(request.Cantidad);

            await _inventarioRepository.UpdateAsync(inventario, cancellationToken);

            try
            {
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(InventarioErrors.Overlap);
            }
        }
    }
}
