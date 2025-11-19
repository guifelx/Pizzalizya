using Pizzalizya.Domain.Entities;
using Pizzalizya.Dto;
using Pizzalizya.Dto.Requests.Pedidos;

namespace Pizzalizya.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<bool> CriarPedidoAsync(AdicionarPedidoRequest pedido);
        Task<IEnumerable<PedidoDto>> ObterPedidos(Guid idEmpresa);
        Task<PedidoDto> ObterPedido(Guid idPedido);
        Task<bool> ExcluirPedido(Guid idPedido);
        Task<bool> AlterarPedidoAsync(PedidoAlteradoRequest idPedido);
    }
}
