using Ferrecode.Domain.Inventarios;
using Ferrecode.Domain.Productos;
using Ferrecode.Domain.PuntosDeVenta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferrecode.Infrastructure.Configurations
{
    internal sealed class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventarios");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Cantidad).HasConversion(x => x!.Value, value => new Cantidad(value)).IsRequired();
            builder.Property(x => x.FechaActualizacion);

            builder.HasOne<Producto>()
                .WithMany()
                .HasForeignKey(inv => inv.IDProductos);

            builder.HasOne<PuntoDeVenta>()
                .WithMany()
                .HasForeignKey(inv => inv.IDPuntoDeVenta);

        }
    }
}
