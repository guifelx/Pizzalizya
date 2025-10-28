using Pizzalizya.Domain.Enums;

namespace Pizzalizya.Dto
{
    public class ItemDto
    {
        public Guid IdExterno { get; set; }
        public string NomeItem { get; set; }
        public TipoItem TipoItem { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
