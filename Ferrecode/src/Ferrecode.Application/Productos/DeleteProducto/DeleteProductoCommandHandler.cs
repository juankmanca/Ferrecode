using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Application.Exceptions;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;

namespace Ferrecode.Application.Productos.DeleteProducto
{
    internal sealed class DeleteProductoCommandHandler : ICommandHandler<DeleteProductoCommand, Producto>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductoCommandHandler(IProductoRepository productoRepository, IInventarioRepository inventarioRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _inventarioRepository = inventarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Producto>> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            Producto? product = await _productoRepository.GetByIdAsync(request.IDProducto!, cancellationToken);
            if (product is null) return Result.Failure<Producto>(ProductoErrors.NotFound);

            product.Status = false;

            await _productoRepository.UpdateAsync(product, cancellationToken);

            try
            {
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return product;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Producto>(ProductoErrors.ErrorDeleteProduct);
            }
        }
    }
}
