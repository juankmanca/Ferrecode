using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Inventarios
{
    public sealed class Inventario : Entity
    {
        public static Inventario Create(Guid iDPuntoDeVenta, Guid iDProductos)
        {
            var Inventory = new Inventario(
                iDPuntoDeVenta,
                iDProductos,
                new Cantidad(0),
                DateTime.UtcNow,
                Guid.NewGuid()
                );

            return Inventory;
        }

        private Inventario()
        {

        }

        private Inventario(Guid iDPuntoDeVenta, Guid iDProductos, Cantidad? cantidad, DateTime fechaActualizacion, Guid ID) : base(ID)
        {
            IDPuntoDeVenta = iDPuntoDeVenta;
            IDProductos = iDProductos;
            Cantidad = cantidad;
            FechaActualizacion = fechaActualizacion;
        }

        public Guid IDPuntoDeVenta { get; private set; }
        public Guid IDProductos { get; private set; }
        public Cantidad? Cantidad { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
    }
}
