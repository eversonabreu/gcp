using Senac.GCP.Domain.Entities.Base;
using System;

namespace Senac.GCP.Domain.Entities
{
    public sealed class SolicitacaoIsencaoInscricaoEntity : Entity
    {
        public long IdInscricao { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public int SituacaoSolicitacao { get; set; }
    }
}