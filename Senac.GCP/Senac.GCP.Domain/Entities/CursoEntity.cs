using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Enums;

namespace Senac.GCP.Domain.Entities
{
    public sealed class  CursoEntity: Entity
    {
        public string Descricao { get; set; }

        public int Codigo { get; set; }
    }
}
