using Pizzalizya.Domain.Entities;
using Pizzalizya.Dto;

namespace Pizzalizya.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<bool> CriarPedidoAsync(Pedido pedido);
        Task<IEnumerable<PedidoDto>> ObterPedidos(Guid idEmpresa);
    }
}
