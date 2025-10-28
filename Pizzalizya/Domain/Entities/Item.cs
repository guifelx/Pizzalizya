using Pizzalizya.Domain.Entities.Base;
using Pizzalizya.Domain.Enums;

namespace Pizzalizya.Domain.Entities
{
    public class Item : SubEntity
    {
        public string NomeItem { get; private set; }
        public TipoItem TipoItem { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public Item()
        { }

        public static Item Criar(string nomeItem, TipoItem tipoItem, decimal valorUnitario)
        {
            return new Item
            {
                NomeItem = nomeItem,
                TipoItem = tipoItem,
                ValorUnitario = valorUnitario
            };
        }
    }
}
