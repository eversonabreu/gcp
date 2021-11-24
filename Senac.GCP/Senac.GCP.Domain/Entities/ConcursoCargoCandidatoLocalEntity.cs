using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKConcursoFaseLocais", ErrorMessage = "O 'ID Concurso Fases Locais' não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkInscricao", ErrorMessage = "o 'ID Inscrição' não é válidO ou não foi atribuídO corretamente")]
    [Constraint(Name = "UkConcursoCargoCandidatoLocal", ErrorMessage = "Não é possível salvar, porque já existe um registro para este concurso com esse Local.")]
    public sealed class ConcursoCargoCandidatoLocalEntity : Entity
    {
        public long IdInscricao { get; set; }

        public long IdConcursoFasesLocais { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdInscricao))]
        public InscricaoEntity Inscricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcursoFasesLocais))]
        public ConcursoFasesLocaisEntity ConcursoFaseLocais { get; set; }

    }
}