using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UkSigla", ErrorMessage = "A sigla não é válido ou não foi atribuída corretamente")]
    public sealed class NivelEscolaridadeEntity : Entity
    {
        public string Sigla { get; set; }
        public string Descricao { get; set; }
    }
}