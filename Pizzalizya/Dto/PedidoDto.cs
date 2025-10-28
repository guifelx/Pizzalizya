using Pizzalizya.Domain.Entities;
using Pizzalizya.Domain.Enums;

namespace Pizzalizya.Dto
{
    public class PedidoDto
    {
        public Guid? IdExterno { get; set; }
        public DateTime DataPedido { get; set; }
        public ClienteDto Cliente { get; set; }
        public decimal ValorPedido { get; set; }
        public TipoPagamento MetodoPagamento { get; set; }
        public ICollection<ItemDto> ItensPedido { get; set; }
        public bool Delivery { get; set; }
    }
}
