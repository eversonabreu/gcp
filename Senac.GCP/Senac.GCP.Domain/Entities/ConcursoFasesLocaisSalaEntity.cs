using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkConcursosFasesLocaisSalaIdConcursosFasesLocais", ErrorMessage = "A sala não é valida para a fase local deste concurso .")]
    public sealed class ConcursoFasesLocaisSalaEntity : Entity
    {
        public long IdConcursoFasesLocais { get; set; }

        public string Descricao { get; set; }

        public int QuantidadeDeCarteiras { get; set; }

        public int QuantidadeDeCarteirasPcd { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcursoFasesLocais))]
        public ConcursoFasesLocaisEntity ConcursoFasesLocais { get; set; }
    }
}