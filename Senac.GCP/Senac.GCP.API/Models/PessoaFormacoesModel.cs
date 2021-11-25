using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Exceptions;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class PessoaFormacoesModel : Model
    {
        public long IdPessoa { get; set; }

        public long IdCurso { get; set; }

        public int AnoConclusao { get; set; }

        public override void OnValidate()
        {
            if (AnoConclusao > DateTime.Now.Year)
                throw new BusinessException("O ano de conclusão informado não é válido. Ele é maior que o ano atual.");
        }
    }
}