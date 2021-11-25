using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKPessoaFormacoesIdPessoa", ErrorMessage = "O 'ID da Pessoa' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FKPessoaFormacoesIdCurso", ErrorMessage = "O curso não é válido ou não foi atribuído corretamente")]
    public sealed class PessoaFormacoesEntity : Entity
    {
        public long IdPessoa { get; set; }

        public long IdCurso { get; set; }

        public int AnoConclusao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdPessoa))]
        public PessoaEntity Pessoa { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdCurso))]
        public CursoEntity Curso { get; set; }
    }
}