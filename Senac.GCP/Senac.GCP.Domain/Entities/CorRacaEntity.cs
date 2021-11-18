using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{

    public sealed class CorRacaEntity : Entity
    {
        public string IdCodigo { get; set; }

        public string Descricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdCodigo))]
        public CargoEntity Codigoo { get; set; }
    }
}
