using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;

namespace Ferrecode.Domain.Inventarios
{
    public interface IInventarioRepository
    {
        bool AddNewProduct(Producto producto, PuntoDeVenta puntoDeVenta);
    }
}
