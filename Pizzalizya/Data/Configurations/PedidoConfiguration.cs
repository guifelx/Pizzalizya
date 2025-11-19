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
                   .WithOne(p => p.Pedido)
                   .HasForeignKey(i => i.IdPai);

            builder.HasOne(c => c.Cliente)
                .WithOne(p => p.Pedido)
                .HasForeignKey<Cliente>(p => p.IdPai);

            builder.HasOne(c => c.Endereco)
                .WithOne(p => p.Pedido)
                .HasForeignKey<Endereco>(p => p.IdPai);
        }
    }
}
