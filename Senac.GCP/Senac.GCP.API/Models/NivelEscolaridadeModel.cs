using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class NivelEscolaridadeModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "A 'Sigla' deve ser informada obrigatoriamente.")]
        [StringLength(maximumLength: 10, ErrorMessage = "O tamanho do campo 'Sigla' não pode superar 10 caractéres.")]
        [StringOptions(TrimSpace = Domain.Enums.TrimSpaceEnum.Both)]
        public string Sigla { get; set; }

        [StringOptions(TrimSpace = Domain.Enums.TrimSpaceEnum.Both)]
        public string Descricao { get; set; }
    }
}
