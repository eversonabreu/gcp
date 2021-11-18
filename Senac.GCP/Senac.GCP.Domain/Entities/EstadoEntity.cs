using Senac.GCP.Domain.Entities.Base;
using Xunit;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UKCodigoCargo", ErrorMessage = "O 'codigo' não é válido ou não foi atribuído corretamente")]

    public sealed class EstadoEntity : Entity
    {
        public string Nome { get; set; }

        public string SiglaUF { get; set; }
    }
}