namespace Pizzalizya.Domain.Entities.Base
{
    public class SubEntity : Entity
    {
        public long IdPai { get; protected set; }

        protected SubEntity() { }

        public SubEntity(Guid idEmpresa, Guid idUsuario) : base(idEmpresa, idUsuario)
        {

        }
    }
}
