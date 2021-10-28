using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class TipoCotaEntity : Entity
    {
        public string Codigo { get; set; }

        public string Descricao { get; set; }

    }
}
