using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{ 
    public sealed class ConcursoFaseCargoModel : Model
    {
        public long IdCargo { get; set; }

        public long IdConcursoCargo { get; set; }
    }
}
