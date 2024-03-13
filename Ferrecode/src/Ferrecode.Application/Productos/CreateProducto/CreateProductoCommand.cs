using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Productos;

namespace Ferrecode.Application.Productos.CreateProducto
{
    public record CreateProductoCommand
        (
            string? nombre, 
            Precio? precio, 
            Medida? medida, 
            Peso? peso, 
            VolumenEmpaque? volumenEmpaque, 
            Guid IDPuntoDeVenta

        ) : ICommand<Guid>;
}
