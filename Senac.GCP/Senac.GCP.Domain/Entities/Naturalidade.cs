using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class NaturalidadeEntity : Entity
    {
        public long IdMunicipio { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdMunicipio))]
        public MunicipioEntity Municipio { get; set; }
    }
}