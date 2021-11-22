using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKNivelEscolaridadeCargo", ErrorMessage = "O 'Nivel Escolaridade' digitado não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "UKCodigoCargo", ErrorMessage = "O 'codigo' não é válido ou não foi atribuído corretamente")]
    public sealed class CargoEntity : Entity
    {
        public string Descricao { get; set; }

        public long IdNivelEscolaridade { get; set; }

        public int Codigo { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdNivelEscolaridade))]
        public NivelEscolaridadeEntity NivelEscolaridade { get; set; }
    }
}
