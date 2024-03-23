using FluentValidation;

namespace Ferrecode.Application.Clientes.CreateCliente
{
    internal sealed class CreateClienteCommandValidation : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidation()
        {
            RuleFor(x => x.email).ChildRules(y => y.RuleFor(z => z!.Value).EmailAddress().WithMessage("el correo electronico no tiene el formato valido").NotNull());
            RuleFor(x => x.documento).ChildRules(y => y.RuleFor(z => z!.TipoDocumento).IsInEnum()).NotNull();
            RuleFor(x => x.telefono).ChildRules(y => y.RuleFor(z => z!.Value).NotEmpty()
            .WithMessage("El teléfono es requerido.")
            .NotNull()
            .WithMessage("El teléfono es requerido.")
            .Matches(@"^\d{0,15}$")
            .WithMessage("El número de teléfono no tiene el formato correcto.")
            );
            RuleFor(x => x.direccion).ChildRules(y => y.RuleFor(z => z!.Value).NotNull());
            RuleFor(x => x.nombre).NotNull();
            RuleFor(x => x.IDPuntoDeVenta).NotNull();
            RuleFor(x => x.direccion).ChildRules(y => y.RuleFor(z => z!.Value)
            .Matches(@"^(Calle|Carrera|Diagonal|Transversal|Avenida)\s\d{1,5}([A-Za-z]|\-\d{1,5})?$")
            .WithMessage("la dirección no tiene el formato correcto")
           .NotEmpty().WithMessage("La dirección es requerida."));

            /*
            ejemplos de direcciones Validos
            Calle 123
            Avenida Principal 456
            Carrera 789-A
             */
        }
    }
}
