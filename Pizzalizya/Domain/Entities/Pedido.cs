using Pizzalizya.Domain.Entities.Base;
using Pizzalizya.Domain.Enums;
using Pizzalizya.Dto;
using System.Runtime.CompilerServices;

namespace Pizzalizya.Domain.Entities
{
    public class Pedido : Entity
    {
        public DateTime DataPedido { get; private set; }
        public Cliente Cliente { get; private set; }
        public decimal ValorPedido { get; private set; }
        public TipoPagamento MetodoPagamento { get; private set; }
        public ICollection<Item> ItensPedido { get; private set; }
        public bool Delivery { get; private set; }

        private Pedido() { }
        private Pedido(Guid idEmpresa, Guid idUsuario, DateTime dataPedido, decimal valorPedido, TipoPagamento tipoPagamento) : base(idEmpresa, idUsuario)
        {
            this.DataPedido = dataPedido;
            this.ValorPedido = valorPedido;
            this.MetodoPagamento = tipoPagamento;
        }

        public static Pedido Criar(
            Guid idEmpresa,
            Guid idUsuario,
            DateTime dataPedido,
            ClienteDto cliente,
            IEnumerable<ItemDto> itens,
            decimal valorPedido,
            TipoPagamento tipoPagamento)
        {
            var pedido = new Pedido(idEmpresa, idUsuario, dataPedido, valorPedido, tipoPagamento);

            foreach (var item in itens)
                pedido.AdicionarItens(item);

            pedido.AdicionarCliente(cliente);

            return pedido;
        }

        private void AdicionarItens(ItemDto item)
        {
            if (item is null)
                return;

            if (this.ItensPedido == null)
                this.ItensPedido = new List<Item>();

            this.ItensPedido.Add(Item.Criar(
                item.NomeItem,
                item.TipoItem,
                item.ValorUnitario));
        }

        private void AdicionarCliente(ClienteDto cliente)
        {
            if (cliente is null)
                return;

            this.Cliente = Cliente.Criar(cliente.Nome, cliente.Cpf); 
        }
    }
}


