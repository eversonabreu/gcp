using Senac.GCP.Domain.Entities.Base;

namespace Senac.GCP.Domain.Entities
{
    public sealed class TipoSolicitacaoIsencaoInscricaoEntity : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PercentualIsencaoInscricao { get; set; }
    }
}
