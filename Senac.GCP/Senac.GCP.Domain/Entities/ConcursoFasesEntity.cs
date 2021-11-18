using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    
    public sealed class ConcursoFasesEntity : Entity
    {
        [NotUpdated]
        public int NumeroFase { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public long IdConcurso { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcurso))]
        public ConcursoEntity Concurso { get; set; }
    }
}