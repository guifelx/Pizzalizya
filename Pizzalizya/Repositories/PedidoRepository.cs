using Pizzalizya.Data;
using Pizzalizya.Domain.Entities;
using Pizzalizya.Repositories.Interfaces;

namespace Pizzalizya.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private PizzalizyaContext _context; 
        private PedidoRepository(PizzalizyaContext context)
        {
            _context = context; 
        }

        public async Task<bool> CriarPedidoAsync(Pedido pedido)
        {
            if (pedido is null)
                return false;

            await _context.Pedidos.AddAsync(pedido); 

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
