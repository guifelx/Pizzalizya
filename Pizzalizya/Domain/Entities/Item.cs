using Pizzalizya.Domain.Entities.Base;
using Pizzalizya.Domain.Enums;

namespace Pizzalizya.Domain.Entities
{
    public class Item : SubEntity
    {
        public string NomeItem { get; private set; }
        public TipoItem TipoItem { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public Pedido Pedido { get; private set; }
        private Item(Guid idEmpresa, Guid idUsuario) : base(idEmpresa, idUsuario) { }
        private Item (Guid idEmpresa, Guid idUsuario, string nomeItem, TipoItem tipoItem, decimal valorUnitario, Pedido pedido) : base(idEmpresa, idUsuario)
        {
            NomeItem = nomeItem;
            TipoItem = tipoItem;
            ValorUnitario = valorUnitario;
            Pedido = pedido;
        }

        public static Item Criar(Guid idEmpresa, Guid idUsuario, string nomeItem, TipoItem tipoItem, decimal valorUnitario, Pedido pedido)
        {
            return new Item(idEmpresa, idUsuario, nomeItem, tipoItem, valorUnitario, pedido); 

        }
    }
}
