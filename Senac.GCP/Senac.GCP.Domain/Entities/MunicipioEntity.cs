using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKMunicipioEstado", ErrorMessage = "O 'Id Estado' digitado não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "UkMunicipio", ErrorMessage = "O 'Municipio' não é válido ou não foi atribuído corretamente")]
    public sealed class MunicipioEntity : Entity
    {
        public string Nome { get; set; }

        public int CodigoIBGE { get; set; }

        public long IdEstado { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdEstado))]
        public EstadoEntity Estado { get; set; }
    }
}