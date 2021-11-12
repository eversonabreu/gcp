using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkIdConcursoCargo", ErrorMessage = "O 'Id Concurso Cargo' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkIdConcursoFase", ErrorMessage = "O 'Id Concurso Fase' não é válido ou não foi atribuído corretamente")]

    public sealed class  ConcursoFaseCargoEntity: Entity
    {
        public long IdConcursoCargo { get; set; }

        public long IdConcursoFase { get; set; }
    }
}
