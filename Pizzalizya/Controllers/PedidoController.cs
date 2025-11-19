using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Pizzalizya.Dto.Requests.Pedidos;
using Pizzalizya.Services.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzalizya.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }


        [HttpGet("obter-pedidos/{idEmpresa}")]
        public async Task<IActionResult> ObterPedidos([FromRoute] Guid idEmpresa)
        {
            var result = await _pedidoService.ObterPedidos(idEmpresa);

            return Ok(result); 
        }

        [HttpGet("obter-pedido/{idExternoPedido}")]
        public async Task<IActionResult> ObterPedido([FromRoute] Guid idExternoPedido)
        {
            var result = await _pedidoService.ObterPedido(idExternoPedido);

            if (result is null)
                return NotFound("Pedido não encotnrado.");

            return Ok(result); 
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] AdicionarPedidoRequest request)
        {
            await _pedidoService.CriarPedidoAsync(request); 

            return Ok(); 
        }

        [HttpPut]
        public async Task<IActionResult> AlterarPedido(PedidoAlteradoRequest pedido)
        {
            await _pedidoService.AlterarPedidoAsync(pedido); 

            return Ok();    
        }

        [HttpDelete("excluir-pedido/{idPedido}")]
        public async Task<IActionResult> Delete(Guid idPedido)
        {
            var excluido = await _pedidoService.ExcluirPedido(idPedido);

            if (!excluido)
                return NotFound("Não foi possível excluir o pedido")
;
            return Ok(); 
        }
    }
}
