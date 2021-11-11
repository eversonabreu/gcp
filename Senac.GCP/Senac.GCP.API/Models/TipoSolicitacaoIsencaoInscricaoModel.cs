using Senac.GCP.API.Models.Base;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class TipoSolicitacaoIsencaoInscricaoModel : Model
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PercentualIsencaoInscricao { get; set; }
    }
}