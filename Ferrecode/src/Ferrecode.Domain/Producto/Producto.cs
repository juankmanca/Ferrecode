using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Producto
{
    public sealed class Producto : Concepto
    {
        public Precio? Precio { get; private set; }
        public Medida? Medida { get; private set; }
        public Peso? Peso { get; private set; }
        public VolumenEmpaque? VolumenEmpaque { get; private set; }

        public Producto()
        {

        }

        public Producto(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion,
            Precio? precio, Medida? medida, Peso? peso, VolumenEmpaque? volumenEmpaque
            ) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
            Precio = precio;
            Medida = medida;
            Peso = peso;
            VolumenEmpaque = volumenEmpaque;
        }

    }
}
