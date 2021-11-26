using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Exceptions;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoFasesModel : Model
    {
        public int NumeroFase { get; set; }

        //ConstraintAttribute[]
        [DateOnly]
        public DateTime DataInicio { get; set; }

        [DateOnly]
        public DateTime DataTermino { get; set; }

        public long IdConcurso { get; set; }

        public override void OnValidate()
        {
            if (DataInicio > DataTermino)
                throw new BusinessException("A data de inicio não pode ser superior a data de término!");
        }
    }
}