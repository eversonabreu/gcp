using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Enums;

namespace Senac.GCP.Domain.Entities
{
    public sealed class  CargoEntity: Entity
    {
        public string Descricao { get; set; }

        public int Codigo { get; set; }

        public NivelEscolaridadeEnum NivelEscolaridade { get; set; }

    }
}
