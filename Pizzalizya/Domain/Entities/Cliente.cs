using Pizzalizya.Domain.Entities.Base;
using Pizzalizya.Domain.Enums;
using System.Runtime.CompilerServices;

namespace Pizzalizya.Domain.Entities
{
    public class Cliente : SubEntity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Pedido Pedido { get; private set; }

        private Cliente (Guid idEmpresa, Guid idUsuario) : base (idEmpresa, idUsuario) { }
        private Cliente(Guid idEmpresa, Guid idUsuario, string nome, string cpf, Pedido pedido) : base(idEmpresa, idUsuario)
        {
            Nome = nome;
            Cpf = cpf;
            Pedido = pedido;
        }

        public static Cliente Criar(Guid idEmpresa, Guid idUsuario, string nome, string cpf, Pedido pedido)
        {
            return new Cliente(idEmpresa, idUsuario, nome, cpf, pedido); 
        }

        public void Alterar (string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = Cpf;
        }
    }
}
