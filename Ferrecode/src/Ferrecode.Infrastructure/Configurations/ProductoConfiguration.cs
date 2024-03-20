using Ferrecode.Domain.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferrecode.Infrastructure.Configurations
{
    internal sealed class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nombre);
            builder.Property(x => x.FechaActualizacion);
            builder.Property(x => x.FechaCreacion);
            builder.Property(x => x.Status);

            //builder.OwnsOne(x => x.Precio).Property(x => x.Value).HasColumnName("Precio");
            builder.Property(x => x.Precio).HasConversion(x => x!.Value, value => new Precio(value));

            // Para propiedades complejas dentro de la entidad a mapear
            builder.OwnsOne(producto => producto.Medida, medida =>
            {
                // Configuración para la propiedad Value de Medida
                medida.Property(m => m.Value)
                      .HasColumnName("ValorMedida");

                // Configuración para la propiedad UnidadDeMedida de Medida
                medida.Property(m => m.UnidadDeMedida)
                      .HasColumnName("UnidadDeMedida") // Nombre de la columna en la base de datos
                      .HasMaxLength(50); // Define la longitud máxima del campo
                                         // Aquí también puedes añadir .IsRequired() si es necesario
            });

            builder.Property(x => x.Peso).HasConversion(x => x!.Value, value => new Peso(value));
            builder.Property(x => x.VolumenEmpaque).HasConversion(x => x!.Value, value => new VolumenEmpaque(value));
        }
    }
}
