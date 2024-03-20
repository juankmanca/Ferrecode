﻿using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Application.Exceptions;
using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Application.Productos.UpdateProducto
{
    internal sealed class UpdateProductCommandHandle : ICommandHandler<UpdateProductCommand, Guid>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IInventarioRepository _inventarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandle(IProductoRepository productoRepository, IInventarioRepository inventarioRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _inventarioRepository = inventarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Producto? product = await _productoRepository.GetByIdAsync(request.ID);
            if (product is null) return Result.Failure<Guid>(ProductoErrors.NotFound);

            product.Update(
                request.nombre,
                request.precio,
                request.medida,
                request.peso,
                request.volumenEmpaque
                );

            try
            {
                await _productoRepository.UpdateAsync(product);

                await _unitOfWork.SaveChangesAsync();

                return product.ID;

            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(ProductoErrors.Overlap);
            }
        }
    }
}
