namespace Ferrecode.Domain.PuntosDeVenta
{
    public interface IPuntoDeVentaRepository
    {
        Task<PuntoDeVenta?> GetByIdAsync(Guid ID, CancellationToken cancellationToken = default);
    }
}
