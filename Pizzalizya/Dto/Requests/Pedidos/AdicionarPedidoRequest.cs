using Pizzalizya.Domain.Entities;
using Pizzalizya.Domain.Enums;

namespace Pizzalizya.Dto.Requests.Pedidos
{
    public class AdicionarPedidoRequest
    {
        public Guid IdEmpresa { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataPedido { get; set; }
        public ClienteDto Cliente { get; set; }
        public decimal ValorPedido { get; set; }
        public TipoPagamento MetodoPagamento { get; set; }
        public ICollection<ItemDto> ItensPedido { get; set; }
    }
}
