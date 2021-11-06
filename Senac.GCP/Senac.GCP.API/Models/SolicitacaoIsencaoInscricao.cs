using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class SolicitacaoIsencaoInscricaoModel : Model
    {
      
        public long IdInscricoes { get; set; }

        public DateTime DataSolicitacao { get; set; }

        [Required(ErrorMessage = "O campo 'data da solicitação' deve ser informado obrigatóriamente.")]
        [DateOnly]

        public int SituacaoSolicitacao { get; set; }
    }
 
}