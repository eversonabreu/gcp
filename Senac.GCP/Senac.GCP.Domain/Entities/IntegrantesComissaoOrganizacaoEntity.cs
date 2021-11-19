using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKConcurso", ErrorMessage = "O 'Concurso' digitado não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FKUsuario", ErrorMessage = "O 'Usuario' digitado não é válido ou não foi atribuído corretamente")]

    public sealed class IntegrantesComissaoOrganizacaoEntity : Entity
    {
        public long IdConcurso { get; set; }

        public long IdUsuario { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdUsuario))]
        public UsuarioEntity Usuario { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcurso))]
        public ConcursoEntity Concurso { get; set; }
    }
}
