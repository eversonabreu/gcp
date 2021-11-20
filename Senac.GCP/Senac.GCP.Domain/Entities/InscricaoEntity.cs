using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKConcursoCargoInscricao", ErrorMessage = "O concurso cargo não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkInscricaoPessoa", ErrorMessage = "A pessoa não foi atribuída corretamente")]
    [Constraint(Name = "UkInscricao", ErrorMessage = "Não é possível salvar, porque já existe um registro para este concurso com esta pessoa")]
    public sealed class InscricaoEntity : Entity
    {
        public long IdPessoa { get; set; }

        public long IdConcursoCargo { get; set; }

        public DateTime DataInscricao { get; set; }

        [NotUpdated]
        public string NumeroInscricao { get; set; }

        public SituacaoInscricaoEnum Situacao { get; set; }

        public bool ParticiparComoCotista { get; set; }

        public string MotivoRecusaInscricao { get; set; }

        public DateTime? DataRecusaInscricao { get; set; }

        public decimal? ValorPago { get; set; }

        public DateTime? DataPagamento { get; set; }

        public TipoPagamentoEnum? TipoPagamento { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdPessoa))]
        public PessoaEntity Pessoa { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcursoCargo))]
        public ConcursoCargoEntity ConcursoCargo { get; set; }

    }
}