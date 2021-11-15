using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UKSolicitacaoIsencaoInscricaoIdInscricao", ErrorMessage = "Não é possível salvar, porque já existe um registro nesta inscrição")]
    [Constraint(Name = "FKIdInscricao", ErrorMessage = "a inscriçao não é válida ou não foi atribuído corretamente")]
    [Constraint(Name = "FKTipoSolicitacaoIsencaoInscricao", ErrorMessage = "O tipo de solicitação de isenção da inscrição não é válido ou não foi atribuído corretamente")]
    public sealed class SolicitacaoIsencaoInscricaoEntity : Entity
    {
        public long IdInscricao { get; set; }

        public long IdTipoSolicitacaoIsencaoInscricao { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public int SituacaoSolicitacao { get; set; }

        public DateTime? DataRespostaSolicitacao { get; set; }

        public string MotivoRecusaSolicitacaoIsensaoInscricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdInscricao))]
        public InscricaoEntity Inscricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdTipoSolicitacaoIsencaoInscricao))]
        public TipoSolicitacaoIsencaoInscricaoEntity TipoSolicitacaoIsencaoInscricao { get; set; }
    }
}