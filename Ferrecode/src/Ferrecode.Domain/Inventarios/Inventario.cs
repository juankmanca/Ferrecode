using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Inventarios
{
    public sealed class Inventario : Entity
    {
        private Inventario()
        {

        }

        public Guid IDPuntoDeVenta { get; private set; }
        public Guid IDProductos { get; private set; }
        public Cantidad? Cantidad { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
    }
}
