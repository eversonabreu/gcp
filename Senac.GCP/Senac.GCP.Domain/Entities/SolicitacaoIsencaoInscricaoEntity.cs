using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class SolicitacaoIsencaoInscricaoEntity : Entity
    {
        public long IdInscricoes { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public int SituacaoSolicitacao { get; set; }

        //[NotMapped]
        //[Dependency(NameForeignKey = nameof(IdInscricoes))]

        //public InscricoesEntity Inscricoes { get; set; }

    }
}