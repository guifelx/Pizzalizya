using Microsoft.VisualBasic;
using Pizzalizya.Domain.Entities.Base;
using Pizzalizya.Domain.Enums;
using Pizzalizya.Dto;
using Pizzalizya.Dto.Requests.Pedidos;
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
        public Endereco Endereco { get; private set; }

        private Pedido() { }
        protected Pedido(Guid idEmpresa, Guid idUsuario, DateTime dataPedido, decimal valorPedido, TipoPagamento tipoPagamento, bool delivery) : base(idEmpresa, idUsuario)
        {
            this.DataPedido = dataPedido;
            this.ValorPedido = valorPedido;
            this.MetodoPagamento = tipoPagamento;
            this.Delivery = delivery;
        }

        public static Pedido Criar(
            Guid idEmpresa,
            Guid idUsuario,
            DateTime dataPedido,
            ClienteDto cliente,
            IEnumerable<ItemDto> itens,
            decimal valorPedido,
            TipoPagamento tipoPagamento, 
            bool delivery, 
            EnderecoDto endereco)
        {
            var pedido = new Pedido(idEmpresa, idUsuario, dataPedido, valorPedido, tipoPagamento, delivery);

            foreach (var item in itens)
                pedido.AdicionarItens(item);

            pedido.AdicionarCliente(cliente);
            pedido.AdicionarEndereco(endereco);

            return pedido;
        }

        public static Pedido Alterar(Pedido pedido, PedidoAlteradoRequest pedidoASerAlterado)
        {
            pedido.DataPedido = pedidoASerAlterado.DataPedido; 
            pedido.ValorPedido = pedidoASerAlterado.ValorPedido; 
            pedido.MetodoPagamento = pedidoASerAlterado.MetodoPagamento; 
            pedido.Delivery = pedidoASerAlterado.Delivery;

            AlterarCliente(pedidoASerAlterado.Cliente, pedido);
            //AlterarItensPedido(pedidoASerAlterado.ItensPedido);

            return pedido; 
        }

        private static void AlterarCliente(ClienteDto cliente, Pedido pedido)
        {
            if (cliente is null)
                return;

            pedido.Cliente.Alterar(cliente.Nome, cliente.Cpf); 
        }


        private static void AlterarItensPedido(IEnumerable<ItemDto> itens, Pedido pedido)
        {
            if (!itens.Any())
                return;

            //foreach(ItemDto item in itens)
            //{
            //    if(pedido.ItensPedido.)
            //}
        }

        private void AdicionarItens(ItemDto item)
        {
            if (item is null)
                return;

            if (this.ItensPedido == null)
                this.ItensPedido = new List<Item>();

            this.ItensPedido.Add(Item.Criar(
                IdEmpresa,
                IdUsuario,
                item.NomeItem,
                item.TipoItem,
                item.ValorUnitario,
                this));
        }

        private void AdicionarCliente(ClienteDto cliente)
        {
            if (cliente is null)
                return;

            this.Cliente = Cliente.Criar(IdEmpresa, IdUsuario, cliente.Nome, cliente.Cpf, this);
        }

        private void AdicionarEndereco(EnderecoDto endereco)
        {
            if (endereco is null)
                return;

            this.Endereco = Endereco.Criar(IdEmpresa, 
                                            IdUsuario, 
                                            endereco.Rua, 
                                            endereco.Numero, 
                                            endereco.Bairro, 
                                            endereco.Cidade, 
                                            endereco.Estado, 
                                            endereco.Cep, 
                                            endereco.Complemento, 
                                            this); 
        }

        private void AlterarItens(IEnumerable<ItemDto> itens)
        {

        }
    }
}


