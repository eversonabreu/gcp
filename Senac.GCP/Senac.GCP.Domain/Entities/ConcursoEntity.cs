using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkInstituicaoSolicitante", ErrorMessage = "O 'ID da Instituicao Solicitante' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkInstituicaoOrganizadora", ErrorMessage = "O 'ID da Instituicao Organizadora' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "UkCodigo", ErrorMessage = "O 'ID do Codigo' não é válido ou não foi atribuído corretamente")]

    public sealed class ConcursoEntity : Entity
    {
        [NotUpdated]
        public int Numero { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicioInscricao { get; set; }

        public DateTime DataFinalInscricao { get; set; }

        public long IdInstituicaoSolicitante { get; set; }

        public long IdInstituicaoOrganizadora { get; set; }

        public DateTime PrazoFinalIsencaoValorInscricao { get; set; }

        public decimal ValorInscricao { get; set; }

        public bool Ativo { get; set; }

        public int QuantidadeVagas { get; set; }

        public int PercentualQuantidadeVagasAmplaConcorrencia { get; set; }

        public string Observacoes { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdInstituicaoOrganizadora))]
        public InstituicaoEntity InstituicaoOrganizadora { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdInstituicaoSolicitante))]
        public InstituicaoEntity InstituicaoSolicitante { get; set; }
    }
}