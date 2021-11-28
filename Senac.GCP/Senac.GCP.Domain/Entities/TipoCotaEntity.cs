using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UkCodigo", ErrorMessage = "Não é possível salvar, porque já existe um registro para este concurso com esta pessoa")]

    public sealed class TipoCotaEntity : Entity
    {
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public string DeclaracaoCiencia { get; set; }
    }
}