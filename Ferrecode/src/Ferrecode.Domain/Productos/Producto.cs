using Ferrecode.Domain.Abstractions;
using Ferrecode.Domain.Productos.Events;

namespace Ferrecode.Domain.Productos
{
    public class Producto : Concepto
    {
        public Precio? Precio { get; private set; }
        public Medida? Medida { get; private set; }
        public Peso? Peso { get; private set; }
        public VolumenEmpaque? VolumenEmpaque { get; private set; }

        public Producto()
        {

        }

        private Producto(Guid iD, string? nombre, DateTime fechaCreacion, DateTime fechaActualizacion,
            Precio? precio, Medida? medida, Peso? peso, VolumenEmpaque? volumenEmpaque
            ) : base(iD, nombre, fechaCreacion, fechaActualizacion)
        {
            Precio = precio;
            Medida = medida;
            Peso = peso;
            VolumenEmpaque = volumenEmpaque;
        }

        public static Producto Create(string? nombre, Precio? precio, Medida? medida, Peso? peso, VolumenEmpaque? volumenEmpaque)
        {
            var producto = new Producto(
                Guid.NewGuid(),
                nombre,
                DateTime.Now,
                DateTime.Now,
                precio,
                medida,
                peso,
                volumenEmpaque
                );

            producto.RaiseDomainEvent(new CreateProductoDomainEvent(producto.ID));
            return producto;
        }

        public static void Delete()
        {

        }

        public static void Update()
        {

        }

        public static void DiscountFromInventory()
        {

        }

    }
}
