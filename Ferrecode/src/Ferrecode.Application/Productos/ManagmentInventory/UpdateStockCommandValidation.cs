using FluentValidation;

namespace Ferrecode.Application.Productos.ManagmentInventory
{
    internal class UpdateStockCommandValidation : AbstractValidator<UpdateStockCommand>
    {
        public UpdateStockCommandValidation()
        {
            RuleFor(x => x.Cantidad).LessThanOrEqualTo(1000000).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ID).NotNull();
        }
    }
}
