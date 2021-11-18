using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UKCodigoCargo", ErrorMessage = "A 'SiglaUF' não é válido ou não foi atribuído corretamente")]

    public sealed class EstadoEntity : Entity
    {
        public string Nome { get; set; }

        public string SiglaUF { get; set; }
    }
}