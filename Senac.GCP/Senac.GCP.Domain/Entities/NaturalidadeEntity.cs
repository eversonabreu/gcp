using Senac.GCP.Domain.Entities.Base;

namespace Senac.GCP.Domain.Entities
{
    public sealed class NaturalidadeEntity : Entity
    {
        public long IdMunicipio { get; set; }

        public string Nome { get; set; }
    }
}