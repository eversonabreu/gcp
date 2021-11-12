using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class DocumentosSolicitacaoIsencaoInscricaoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdArquivo' não foi preenchido")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both, AlterCase = AlterCaseEnum.Upper)]
        public long IdArquivo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdSolicitacaoIsencaoInscricao' não foi preenchido")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both, AlterCase = AlterCaseEnum.Upper)]
        public long IdSolicitacaoIsencaoInscricao{ get; set; }
    }
}