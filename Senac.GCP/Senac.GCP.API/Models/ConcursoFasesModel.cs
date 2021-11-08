using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoFasesModel : Model
    {
        [DateOnly]
        public DateTime DataInicio { get; set; }

        [DateOnly]
        public DateTime DataTermino { get; set; }

        public long IdConcurso { get; set; }

        public override void AdditionalValidations()
        {
            if (DataInicio > DataTermino)
                throw new Exception("Não foi possível realizar, pois a data de inicio é maior que a data final");
        }
    }
}