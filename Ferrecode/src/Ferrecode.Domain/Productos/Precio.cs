using System.ComponentModel.DataAnnotations;

namespace Ferrecode.Domain.Productos
{
    public record Precio
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor que cero.")]
        public decimal Value { get; set; }

        public Precio(decimal value)
        {
            Value = value;
        }
    }
}
