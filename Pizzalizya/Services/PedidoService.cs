using Pizzalizya.Domain.Entities;
using Pizzalizya.Domain.Enums;
using Pizzalizya.Dto;
using Pizzalizya.Dto.Requests.Pedidos;
using Pizzalizya.Repositories.Interfaces;
using Pizzalizya.Services.Interfaces;

namespace Pizzalizya.Services
{
    public class PedidoService : IPedidoService
    {
        public IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository; 
        }

        public async Task<bool> CriarPedidoAsync(AdicionarPedidoRequest request)
        {
            var pedido = Pedido.Criar(request.IdEmpresa, 
                                            request.IdUsuario, 
                                            request.DataPedido,
                                            request.Cliente, 
                                            request.ItensPedido, 
                                            request.ValorPedido, 
                                            request.MetodoPagamento,
                                            request.Delivery); 

            var result = await _pedidoRepository.CriarPedidoAsync(pedido); 

            if(!result)
                return false;

            return true;
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidos(Guid idEmpresa)
        {
            var pedidos = await _pedidoRepository.ObterPedidos(idEmpresa);

            if (pedidos.Count() == 0)
                return new List<PedidoDto>();

            return pedidos;
        }
    }
}
