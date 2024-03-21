using Ferrecode.Application.Productos.CreateProducto;
using Ferrecode.Application.Productos.DeleteProducto;
using Ferrecode.Application.Productos.GetProductos;
using Ferrecode.Application.Productos.ManagmentInventory;
using Ferrecode.Application.Productos.UpdateProducto;
using Ferrecode.Domain.Productos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ferrecode.Api.Controllers.Productos
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductoController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductoController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearProductoRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateProductoCommand(
                    request.Nombre,
                    new Precio(request.Precio),
                    new Medida(request.Medida, request.UnidadDeMedida),
                    new Peso(request.Peso),
                    new VolumenEmpaque(request.VolumenEmpaque),
                    request.IDPuntoDeVenta
                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductoQuery(id);

            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : NotFound();
        }

        [HttpGet("{IDPuntoDeVenta}")]
        public async Task<IActionResult> GetAll(Guid IDPuntoDeVenta, CancellationToken cancellationToken)
        {
            var query = new GetProductosQuery(IDPuntoDeVenta);

            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductoRequest request, CancellationToken cancellationToken)
        {
            var query = new UpdateProductCommand(
                                request.Nombre,
                                new Precio(request.Precio),
                                new Medida(request.Medida, request.UnidadDeMedida),
                                new Peso(request.Peso),
                                new VolumenEmpaque(request.VolumenEmpaque),
                                request.ID
                                 );

            var result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductoCommand(id);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockRequest updateStockRequest, CancellationToken cancellationToken)
        {
            var request = new UpdateStockCommand(
                updateStockRequest.IDProducto,
                updateStockRequest.Cantidad
                );

            var result = await _sender.Send(request, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok();
        }
    }
}
