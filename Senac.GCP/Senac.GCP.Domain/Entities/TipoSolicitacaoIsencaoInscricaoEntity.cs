using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UkTipoSolicitacaoIsencaoInscricao", ErrorMessage = "O Codigo digitado nao e valido")]
    public sealed class TipoSolicitacaoIsencaoInscricaoEntity : Entity
    {
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public decimal PercentualIsencaoInscricao { get; set; }
    }
}
