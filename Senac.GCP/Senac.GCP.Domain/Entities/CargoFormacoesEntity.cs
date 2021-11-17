using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UKCargoIdCargo", ErrorMessage = "Não é possível salvar este cargo, porque este cargo ja esta sendo utilizado.")]
    [Constraint(Name = "UKCursoIdCurso", ErrorMessage = "Não é possível salvar este curso, porque este curso ja esta sendo utilizado.")]
    public sealed class CargoFormacoesEntity : Entity
    {

        public long IdCargo { get; set; }

        public long IdCurso { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdCargo))]
        public CargoEntity Cargo { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdCurso))]
        public CursoEntity Curso { get; set; }
    }
}
