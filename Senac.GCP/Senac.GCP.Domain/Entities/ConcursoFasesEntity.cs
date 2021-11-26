using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{

    [Constraint(Name = "FkConcursoFasesConcurso", ErrorMessage = "O campo 'Id Concurso' não é válido ou não foi atribuído corretamente.")]
    [Constraint(Name = "UkConcursoFases", ErrorMessage = "Não é possível salvar, porque já existe um registro para este concurso com esse Numero Fase.")]

    public sealed class ConcursoFasesEntity : Entity
    {
        public int NumeroFase { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public long IdConcurso { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcurso))]
        public ConcursoEntity Concurso { get; set; }
    }
}