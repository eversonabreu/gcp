using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UkSigla", ErrorMessage = "A sigla informada já esta sendo usada.")]
    public sealed class NivelEscolaridadeEntity : Entity
    {
        public string Sigla { get; set; }

        public string Descricao { get; set; }
    }
}