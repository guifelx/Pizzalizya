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
        IPedidoRepository _pedidoRepository; 

        private PedidoService(IPedidoRepository pedidoRepository)
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
                                            request.MetodoPagamento); 

            var result = await _pedidoRepository.CriarPedidoAsync(pedido); 

            if(!result)
                return false;

            return true;
        }
    }
}
