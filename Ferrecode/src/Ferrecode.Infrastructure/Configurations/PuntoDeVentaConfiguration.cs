using Ferrecode.Domain.PuntosDeVenta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferrecode.Infrastructure.Configurations
{
    internal sealed class PuntoDeVentaConfiguration : IEntityTypeConfiguration<PuntoDeVenta>
    {
        public void Configure(EntityTypeBuilder<PuntoDeVenta> builder)
        {
            builder.ToTable("PuntosDeVenta");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nombre);
            builder.Property(x => x.FechaActualizacion);
            builder.Property(x => x.FechaCreacion);
        }
    }
}
