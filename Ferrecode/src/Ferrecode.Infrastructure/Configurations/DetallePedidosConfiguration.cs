using Ferrecode.Domain.DetallePedidos;
using Ferrecode.Domain.Pedidos;
using Ferrecode.Domain.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferrecode.Infrastructure.Configurations
{
    internal class DetallePedidosConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.ToTable("DetallePedidos");
            builder.HasKey(x => x.ID);

            builder.HasOne<Pedido>()
            .WithMany()
            .HasForeignKey(Detalle => Detalle.IDPedido);

            builder.HasOne<Producto>()
            .WithMany()
            .HasForeignKey(Detalle => Detalle.IDProducto);

            builder.Property(x => x.Cantidad).HasConversion(x => x.Value, value => new Cantidad(value));
        }
    }
}
