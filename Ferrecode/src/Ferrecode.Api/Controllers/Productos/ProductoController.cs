using Ferrecode.Application.Productos.CreateProducto;
using Ferrecode.Application.Productos.GetProductos;
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

            return CreatedAtAction(nameof(GetById), new { id = result.Value });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductoQuery(id);

            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : NotFound();
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] ProductoDto productoDto)
        //{
        //    // Lógica para actualizar un producto existente con el ID proporcionado
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    // Lógica para eliminar un producto existente con el ID proporcionado
        //}
    }
}
