using Ferrecode.Domain.Clientes;
using Ferrecode.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferrecode.Infrastructure.Configurations
{
    internal class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nombre);
            builder.Property(x => x.FechaActualizacion);
            builder.Property(x => x.FechaCreacion);
            builder.Property(x => x.Status);
            builder.Property(x => x.FechaCierre);
            builder.Property(x => x.FechaFacturacion);

            builder.HasOne<Cliente>()
               .WithMany()
               .HasForeignKey(cliente => cliente.IDCliente);

        }
    }
}
