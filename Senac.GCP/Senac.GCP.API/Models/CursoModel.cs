using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class CursoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Descrição' deve ser informado obrigatóriamente.")]
        public string Descricao { get; set; }

        public int Codigo { get; set; }

        public long IdNivelEscolaridade { get; set; }

    }
}
