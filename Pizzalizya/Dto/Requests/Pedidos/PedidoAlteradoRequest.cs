using Pizzalizya.Domain.Enums;

namespace Pizzalizya.Dto.Requests.Pedidos
{
    public class PedidoAlteradoRequest
    {
        public Guid IdExterno { get; set; }
        public Guid IdEmpresa { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataPedido { get; set; }
        public ClienteDto Cliente { get; set; }
        public decimal ValorPedido { get; set; }
        public TipoPagamento MetodoPagamento { get; set; }
        public ICollection<ItemDto> ItensPedido { get; set; }
        public bool Delivery { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
