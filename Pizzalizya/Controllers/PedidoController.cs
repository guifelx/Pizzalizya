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

        // GET: api/<PedidoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PedidoController>/5
        [HttpGet("{idEmpresa}")]
        public async Task<IActionResult> ObterPedidos([FromRoute] Guid idEmpresa)
        {
            var result = await _pedidoService.ObterPedidos(idEmpresa);

            return Ok(result); 
        }

        // POST api/<PedidoController>
        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] AdicionarPedidoRequest request)
        {
            await _pedidoService.CriarPedidoAsync(request); 

            return Ok(); 
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
