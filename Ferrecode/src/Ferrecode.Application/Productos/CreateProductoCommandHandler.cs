using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Application.Exceptions;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Application.Productos
{
    internal sealed class CreateProductoCommandHandler : ICommandHandler<CreateProductoCommand, Guid>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductoCommandHandler(IProductoRepository productoRepository, IInventarioRepository inventarioRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _inventarioRepository = inventarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            // Llamamos al repository que se encarga de guardar en la base de datos
            PuntoDeVenta storeExists = await _productoRepository.GetStoreById(request.IDPuntoDeVenta);
            if (storeExists is null) return Result.Failure<Guid>(PuntoDeVentaErrors.NotFound);

            Producto product = await _productoRepository.GetByNameAsync(request.nombre!);
            if (product is not null) return Result.Failure<Guid>(ProductoErrors.Duplicated);

            try
            {
                var producto = Producto.Create(
                        request.nombre,
                        request.precio,
                        request.medida,
                        request.peso,
                        request.volumenEmpaque
                    );

                bool isSuccess = _inventarioRepository.AddNewProduct(producto, storeExists);

                if (isSuccess)
                {
                    _productoRepository.Add(producto);
                    await _unitOfWork.SaveChangesAsync();
                    return product.ID;
                }
                else
                {
                    return Result.Failure<Guid>(ProductoErrors.ErrorSavingProduct);
                }
            }
            catch (ConcurrencyException ex)
            {
                return Result.Failure<Guid>(ProductoErrors.Overlap);
            }

        }
    }
}
