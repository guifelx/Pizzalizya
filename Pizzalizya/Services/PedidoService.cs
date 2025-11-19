using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
                                            request.Delivery,
                                            request.Endereco); 

            var result = await _pedidoRepository.CriarPedidoAsync(pedido); 

            if(!result)
                return false;

            return true;
        }

        public async Task<bool> AlterarPedidoAsync(PedidoAlteradoRequest pedidoASerAlterado)
        {
            var pedidoEntity = await _pedidoRepository.ObterPedidoInterno(pedidoASerAlterado.IdExterno);

            var pedidoAlterado = Pedido.Alterar(pedidoEntity, pedidoASerAlterado);

                //pedidoASerAlterado.Cliente;

            return true; 
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidos(Guid idEmpresa)
        {
            var pedidos = await _pedidoRepository.ObterPedidos(idEmpresa);

            if (pedidos.Count() == 0)
                return new List<PedidoDto>();

            return pedidos;
        }

        public async Task<PedidoDto> ObterPedido(Guid idPedido)
        {
            var pedido = await _pedidoRepository.ObterPedido(idPedido);

            return pedido;
        }

        public async Task<bool> ExcluirPedido(Guid idPedido)
        {
            var excluido = await _pedidoRepository.ExcluirPedido(idPedido);

            return excluido; 
        }
    }
}
