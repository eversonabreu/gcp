using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class PessoaFormacoesModel : Model
    {
        public long IdPessoa { get; set; }

        public long IdCurso { get; set; }

        [DateOnly]
        public DateTime AnoConclusao { get; set; }

        public override void AdditionalValidations()
        {
            if (AnoConclusao.Year < DateTime.Now.Year)
                throw new Exception("O ano de conclusão informado não é válido. Ele é menor que o ano atual.");
        }
    }
}