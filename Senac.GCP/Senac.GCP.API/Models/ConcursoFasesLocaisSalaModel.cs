using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoFasesLocaisSalaModel : Model
    {
        public long IdConcursoFasesLocais { get; set; }

        [StringLength(maximumLength: 255,
            ErrorMessage = "O tamanho do campo 'Descrição' não pode superar 255 Caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Descrição' deve ser informado obrigatoriamente.")]
        public string Descricao { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantidade inválida de carteiras")]
        public int QuantidadeDeCarteiras { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantidade inválida de carteiras (PCD)")]
        public int QuantidadeDeCarteirasPcd { get; set; }

        public override void OnValidate()
        {
            if (QuantidadeDeCarteiras == 0 && QuantidadeDeCarteirasPcd == 0)
                throw new BusinessException("É necessário ter no mínimo 1 (uma) carteira para uso normal ou 1 (uma) para uso PCD");
        }
    }
}