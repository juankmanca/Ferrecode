using Azure.Core;
using Ferrecode.Api.Controllers.Productos;
using Ferrecode.Application.Clientes.CreateCliente;
using Ferrecode.Application.Clientes.DeleteCliente;
using Ferrecode.Application.Clientes.GetClientes;
using Ferrecode.Domain.Clientes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ferrecode.Api.Controllers.Clientes
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private readonly ISender _sender;

        public ClientesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateClienteCommand(
                    request.Nombre,
                    new Documento(request.NumeroDocumento, request.TipoDocumento),
                    new Direccion(request.Direccion, request.IDCiudad, request.IDDepartamento),
                    new Email(request.Email),
                    request.IDPuntoDeVenta
                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetClienteQuery(id);

            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : NotFound();
        }

        [HttpGet("{IDPuntoDeVenta}")]
        public async Task<IActionResult> GetAll(Guid IDPuntoDeVenta, CancellationToken cancellationToken)
        {
            var query = new GetClientesQuery(IDPuntoDeVenta);

            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : NotFound();
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateProductoRequest request, CancellationToken cancellationToken)
        //{
        //    var query = new UpdateProductCommand(
        //                        request.Nombre,
        //                        new Precio(request.Precio),
        //                        new Medida(request.Medida, request.UnidadDeMedida),
        //                        new Peso(request.Peso),
        //                        new VolumenEmpaque(request.VolumenEmpaque),
        //                        request.ID
        //                         );

        //    var result = await _sender.Send(query, cancellationToken);

        //    if (result.IsFailure) return BadRequest(result.Error);

        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteClienteCommand(id);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok();
        }

    }
}
