using Microsoft.EntityFrameworkCore;
using Pizzalizya.Domain.Entities;

namespace Pizzalizya.Data
{
    public class PizzalizyaContext : DbContext
    {
        public PizzalizyaContext(DbContextOptions<PizzalizyaContext> options) : base(options)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}

