using Pizzalizya.Domain.Entities;

namespace Pizzalizya.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<bool> CriarPedidoAsync(Pedido pedido);
    }
}
