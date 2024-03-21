using Ferrecode.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferrecode.Infrastructure.Configurations
{
    internal class TiposDeDocumentoConfiguration : IEntityTypeConfiguration<TipoDeDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDeDocumento> builder)
        {
            builder.ToTable("TiposDeDocumento");
            builder.HasKey(x => x.ID); //Se mapea automaticamente por convención de EF al llamrse 'ID' y ser de tipo int
            builder.Property(x => x.Nombre);
            builder.Property(x => x.Acronimo);
        }
    }
}
