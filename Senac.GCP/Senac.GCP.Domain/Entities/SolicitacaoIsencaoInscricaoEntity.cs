using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UKSolicitacaoIsencaoInscricaoIdInscricao", ErrorMessage = "Não é possível salvar, porque já existe uma solicitação de isenção de inscrição.")]
    [Constraint(Name = "FKIdInscricao", ErrorMessage = "a inscriçao não é válida ou não foi atribuída corretamente.")]
    [Constraint(Name = "FKTipoSolicitacaoIsencaoInscricao", ErrorMessage = "O tipo de solicitação de isenção da inscrição não é válido ou não foi atribuída corretamente.")]
    public sealed class SolicitacaoIsencaoInscricaoEntity : Entity
    {
        public long IdInscricao { get; set; }

        public long IdTipoSolicitacaoIsencaoInscricao { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public SituacaoSolicitacaoIsencaoInscricaoEnum SituacaoSolicitacao { get; set; }

        public DateTime? DataRespostaSolicitacao { get; set; }

        public string? MotivoRecusaSolicitacaoIsensaoInscricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdInscricao))]
        public InscricaoEntity Inscricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdTipoSolicitacaoIsencaoInscricao))]
        public TipoSolicitacaoIsencaoInscricaoEntity TipoSolicitacaoIsencaoInscricao { get; set; }
    }
}