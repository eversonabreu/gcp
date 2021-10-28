using Senac.GCP.Domain.Entities.Base;

namespace Senac.GCP.Domain.Entities
{
    public sealed class EstadoEntity : Entity
    {
        public string Nome { get; set; }

        public string SiglaUF { get; set; }
    }
}