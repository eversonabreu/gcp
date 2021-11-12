using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    //[Constraint(Name = "FkIdCargo", ErrorMessage = "O 'Id Cargo' não é válido ou não foi atribuído corretamente")]
    //[Constraint(Name = "FkIdConcurso", ErrorMessage = "O 'Id Concurso' não é válido ou não foi atribuído corretamente")]

    public sealed class  ConcursoFaseCargoEntity: Entity
    {
        public long IdConcursoCargo { get; set; }

        public long IdConcursoFase { get; set; }

        public int QuantidadeVagas { get; set; }

        /*[NotMapped]
        [Dependency(NameForeignKey = nameof(IdCargo))]
        public CargoEntity Cargo { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcurso))]
        public ConcursoEntity Concurso { get; set; }
        */
    }
}
