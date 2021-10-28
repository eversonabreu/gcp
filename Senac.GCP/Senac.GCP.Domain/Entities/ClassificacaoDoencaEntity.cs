using Senac.GCP.Domain.Entities.Base;

namespace Senac.GCP.Domain.Entities
{
    public sealed class ClassificacaoDoencaEntity : Entity
    {
        public string CID { get; set; }

        public string Descricao { get; set; }
    }
}
