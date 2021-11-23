using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Enums;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class SolicitacaoIsencaoInscricaoModel : Model
    {
        public long IdInscricao { get; set; }

        public long IdTipoSolicitacaoIsencaoInscricao { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public SituacaoSolicitacaoIsencaoInscricaoEnum SituacaoSolicitacao { get; set; }

        public DateTime? DataRespostaSolicitacao { get; set; }

        public string MotivoRecusaSolicitacaoIsencaoInscricao { get; set; }
    }
}