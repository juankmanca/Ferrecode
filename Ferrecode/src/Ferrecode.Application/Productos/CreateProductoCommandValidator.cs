﻿using FluentValidation;

namespace Ferrecode.Application.Productos
{
    internal class CreateProductoCommandValidator : AbstractValidator<CreateProductoCommand>
    {
        public CreateProductoCommandValidator()
        {
            //Establecer las reglas del command
            RuleFor(x => x.nombre).NotNull().NotEmpty();
            RuleFor(x => x.nombre).NotNull();
            RuleFor(x => x.medida).NotNull();
            RuleFor(x => x.peso).NotNull();
            RuleFor(x => x.IDPuntoDeVenta).NotNull().NotEmpty();
            RuleFor(x => x.volumenEmpaque).NotNull();
        }

    }
}
