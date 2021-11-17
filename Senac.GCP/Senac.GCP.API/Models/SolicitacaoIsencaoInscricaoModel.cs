using Senac.GCP.API.Models.Base;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class SolicitacaoIsencaoInscricaoModel : Model
    {
        public long IdInscricao { get; set; }

        public long IdTipoSolicitacaoIsencaoInscricao { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public int SituacaoSolicitacao { get; set; }

        public DateTime? DataRespostaSolicitacao { get; set; }

        public string MotivoRecusaSolicitacaoIsensaoInscricao { get; set; }
    }
}