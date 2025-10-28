using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzalizya.Domain.Entities;

namespace Pizzalizya.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(p => p.ItensPedido)
                   .WithOne()
                   .HasForeignKey(i => i.IdPai)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
