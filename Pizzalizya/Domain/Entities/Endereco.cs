using Pizzalizya.Domain.Entities.Base;
using Pizzalizya.Dto;

namespace Pizzalizya.Domain.Entities
{
    public class Endereco : SubEntity
    {
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        public string Complemento { get; private set; }
        public Pedido Pedido { get; private set; }

        protected Endereco() { }

        private Endereco(Guid idEmpresa, Guid idUsuario) : base(idEmpresa, idUsuario) { }

        public Endereco(Guid idEmpresa, Guid idUsuario, string rua, string numero, string bairro, string cidade, string estado, string cep, string complemento, Pedido pedido) : base(idEmpresa, idUsuario)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
            Pedido = pedido;
        }

        public static Endereco Criar(Guid idEmpresa, Guid idUsuario, string rua, string numero, string bairro, string cidade, string estado, string cep, string complemento, Pedido pedido)
        {
            return new Endereco(idEmpresa, idUsuario, rua, numero, bairro, cidade, estado, cep, complemento, pedido);
        }


        public void Alterar(string rua, string numero, string bairro, string cidade, string estado, string cep, string complemento)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
        }
    }

}
