using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
<<<<<<< HEAD
    [Constraint(Name = "FkIdConcursoCargo", ErrorMessage = "O 'Id Concurso Cargo' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkIdConcursoFase", ErrorMessage = "O 'Id Concurso Fase' não é válido ou não foi atribuído corretamente")]
=======
    //[Constraint(Name = "FkIdCargo", ErrorMessage = "O 'Id Cargo' não é válido ou não foi atribuído corretamente")]
    //[Constraint(Name = "FkIdConcurso", ErrorMessage = "O 'Id Concurso' não é válido ou não foi atribuído corretamente")]
>>>>>>> 740243cc1b75e4bd28c0382570a27f0bac986808

    public sealed class  ConcursoFaseCargoEntity: Entity
    {
        public long IdConcursoCargo { get; set; }

        public long IdConcursoFase { get; set; }
    }
}
