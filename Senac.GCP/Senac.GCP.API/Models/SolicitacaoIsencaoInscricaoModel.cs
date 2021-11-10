using Senac.GCP.API.Models.Base;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class SolicitacaoIsencaoInscricaoModel : Model
    {
        public long IdInscricao { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public int SituacaoSolicitacao { get; set; }
    }
}