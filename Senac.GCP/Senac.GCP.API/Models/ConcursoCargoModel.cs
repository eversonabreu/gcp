using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoCargoModel : Model
    {
        public long IdCargo { get; set; }

        public long IdConcurso { get; set; }

        public int QuantidadeVagas { get; set; }

        public int QuantidadeVagasPCD { get; set; }

        public override void AdditionalValidations()
        {
            if (QuantidadeVagas< 0 || QuantidadeVagasPCD < 0)
                throw new BusinessException("O valor inserido em uma das colunas de quantidade é inferior a 0 ");

            if(QuantidadeVagas == 0 && QuantidadeVagasPCD == 0)
                throw new BusinessException("Os valores inseridos não correspondem a um Concurso Cargo Valido, pois não possui vagas ");
        }
    }
}
