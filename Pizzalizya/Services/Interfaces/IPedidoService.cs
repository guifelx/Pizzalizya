using Pizzalizya.Domain.Entities;
using Pizzalizya.Dto.Requests.Pedidos;

namespace Pizzalizya.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<bool> CriarPedidoAsync(AdicionarPedidoRequest pedido);
    }
}
