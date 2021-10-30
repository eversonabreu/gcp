using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
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
