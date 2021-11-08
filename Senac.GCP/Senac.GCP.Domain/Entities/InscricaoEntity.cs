using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKInscricaoConcurso", ErrorMessage = "O concurso não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkInscricaoPessoa", ErrorMessage = "A pessoa não foi atribuída corretamente")]
    [Constraint(Name = "UkInscricao", ErrorMessage = "Não é possível salvar, porque já existe um registro para este concurso com esta pessoa")]
    public sealed class InscricaoEntity : Entity
    {
        public long IdPessoa { get; set; }

        public long IdConcurso { get; set; }

        public DateTime DataInscricao { get; set; }

        public string NumeroInscricao { get; set; }

        public int Situacao { get; set; }

        public bool ParticiparComoCotista { get; set; }

        public string MotivoRecusaInscricao { get; set; }

        public DateTime DataRecusaInscricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdPessoa))]
        public PessoaEntity Pessoa { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcurso))]
        public ConcursoEntity Concurso { get; set; }
    }
}