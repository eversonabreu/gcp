using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkCursoNivelEscolaridade", ErrorMessage = "O nivel escolaridade não foi atribuído corretamente")]
    public sealed class  CursoEntity: Entity
    {
        public string Descricao { get; set; }

        public int Codigo { get; set; }
        public long IdNivelEscolaridade { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdNivelEscolaridade))]
        public NivelEscolaridadeEntity NivelEscolaridade { get; set; }
    }
}
