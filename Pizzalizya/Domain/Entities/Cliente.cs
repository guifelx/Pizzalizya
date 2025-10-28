using Pizzalizya.Domain.Entities.Base;
using Pizzalizya.Domain.Enums;

namespace Pizzalizya.Domain.Entities
{
    public class Cliente : SubEntity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        public Cliente()
        { }

        public static Cliente Criar(string nome, string cpf)
        {
            return new Cliente
            {
                Nome = nome, 
                Cpf = cpf
            };
        }
    }
}
