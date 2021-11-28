using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkCursoNivelEscolaridade", ErrorMessage = "O nivel escolaridade não foi atribuído corretamente")]
    [Constraint(Name = "UkCursoNivelEscolaridade", ErrorMessage = "O código do nível de escolaridade deve ser único")]
    public sealed class CursoEntity : Entity
    {
        public string Descricao { get; set; }

        public int Codigo { get; set; }

        public long IdNivelEscolaridade { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdNivelEscolaridade))]
        public NivelEscolaridadeEntity NivelEscolaridade { get; set; }
    }
}