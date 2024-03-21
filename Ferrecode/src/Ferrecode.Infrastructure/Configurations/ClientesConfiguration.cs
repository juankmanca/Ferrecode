using Ferrecode.Domain.Clientes;
using Ferrecode.Domain.PuntosDeVenta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferrecode.Infrastructure.Configurations
{
    internal sealed class ClientesConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nombre);
            builder.Property(x => x.FechaActualizacion);
            builder.Property(x => x.FechaCreacion);
            builder.Property(x => x.Status);

            builder.OwnsOne(cliente => cliente.Documento,
                doc =>
            {
                doc.Property(m => m.NumeroDocumento)
                      .HasColumnName("NumeroDocumento");

                doc.Property(m => m.TipoDocumento)
                      .HasColumnName("IDTipoDocumento");
            });

            builder.OwnsOne(cliente => cliente.Direccion,
                dir =>
                {
                    dir.Property(m => m.Value)
                          .HasColumnName("Direccion");

                    dir.Property(m => m.IDCiudad)
                          .HasColumnName("IDCiudad");

                    dir.Property(m => m.IDDepartamento)
                          .HasColumnName("IDDepartamento");
                });

            builder.Property(x => x.Email).HasConversion(x => x!.Value, value => new Email(value));

            builder.HasOne<PuntoDeVenta>()
                .WithMany()
                .HasForeignKey(cliente => cliente.IDPuntoDeVenta);

        }
    }
}
