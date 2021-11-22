using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UkConcursoCargo", ErrorMessage = "O 'Id Concurso Cargo' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "UkCargo", ErrorMessage = "Não é possível salvar, porque já existe um registro para este concurso com esta pessoa")]

    public sealed class  ConcursoFaseCargoEntity: Entity
    {
        public long IdCargo { get; set; }

        public long IdConcursoCargo { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcursoCargo))]
        public ConcursoCargoEntity ConcursoCargo { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdCargo))]
        public CargoEntity Cargo { get; set; }
    }
}
