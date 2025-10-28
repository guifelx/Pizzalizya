namespace Pizzalizya.Domain.Entities.Base
{
    public class Entity
    {
        public long Id { get; protected set; }
        public Guid IdExterno { get; protected set; }
        public Guid IdUsuario { get; protected set; }
        public Guid IdEmpresa { get; protected set; }

        protected Entity() { }

        protected Entity(Guid empresaId, Guid idUsuario)
        {
            this.IdExterno = Guid.NewGuid();
            this.IdUsuario = idUsuario;
            this.IdEmpresa = empresaId;
        }
    }
}
