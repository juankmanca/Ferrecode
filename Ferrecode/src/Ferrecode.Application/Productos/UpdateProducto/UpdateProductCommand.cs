using Ferrecode.Application.Abstractions.Messaging;
using Ferrecode.Domain.Productos;

namespace Ferrecode.Application.Productos.UpdateProducto
{
    public record UpdateProductCommand
    (
            string? nombre,
            Precio? precio,
            Medida? medida,
            Peso? peso,
            VolumenEmpaque? volumenEmpaque,
            Guid ID

        ) : ICommand<Guid>;
}
