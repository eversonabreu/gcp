using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkConcursoTipoCotasConcurso", ErrorMessage = "O concurso não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkConcursoTipoCotasTipoConta", ErrorMessage = "O tipo de cota não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "UkConcursoTipoCotas", ErrorMessage = "Não é possível salvar porque já existe um concurso com este tipo de cota")]
    public sealed class ConcursoTipoCotasEntity : Entity
    {
        public long IdConcurso { get; set; }

        public long IdTipoCota { get; set; }

        public int PercentualVagas { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcurso))]
        public ConcursoEntity Concurso { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdTipoCota))]
        public TipoCotaEntity TipoCota { get; set; }
    }
}