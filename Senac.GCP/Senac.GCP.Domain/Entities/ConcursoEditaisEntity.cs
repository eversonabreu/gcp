using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkConcursoEditaisArquivo", ErrorMessage = "O 'ID do arquivo do edital' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkConcursoEditaisConcurso", ErrorMessage = "O concurso não é válido ou não foi atribuído corretamente")]
    public sealed class ConcursoEditaisEntity : Entity
    {
        public DateTime DataEdital { get; set; }

        public string Descricao { get; set; }

        public long IdConcurso { get; set; }

        public long IdArquivo { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcurso))]
        public ConcursoEntity Concurso { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdArquivo))]
        public ArquivoEntity Arquivo { get; set; }
    }
}
