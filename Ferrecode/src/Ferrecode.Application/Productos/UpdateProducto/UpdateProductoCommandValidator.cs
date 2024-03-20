using Ferrecode.Application.Productos.CreateProducto;
using FluentValidation;

namespace Ferrecode.Application.Productos.UpdateProducto
{
    internal sealed class UpdateProductoCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductoCommandValidator()
        {
            //Establecer las reglas del command
            RuleFor(x => x.nombre).NotNull().NotEmpty();
            RuleFor(x => x.medida).NotNull();   
            RuleFor(x => x.peso).NotNull();
            RuleFor(x => x.volumenEmpaque).NotNull();
            RuleFor(x => x.ID).NotNull();
        }
    }
}
