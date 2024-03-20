using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Application.Exceptions;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Application.Productos.CreateProducto
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
            PuntoDeVenta? storeExists = await _productoRepository.GetStoreById(request.IDPuntoDeVenta, cancellationToken);
            if (storeExists is null) return Result.Failure<Guid>(PuntoDeVentaErrors.NotFound);

            Producto? product = await _productoRepository.GetByNameAsync(request.nombre!, cancellationToken);
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

                var Inventory = Inventario.Create(
                        storeExists.ID,
                        producto.ID
                    );

                _productoRepository.Add(producto);
                _inventarioRepository.Add(Inventory);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return producto!.ID;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(ProductoErrors.Overlap);
            }

        }
    }
}
