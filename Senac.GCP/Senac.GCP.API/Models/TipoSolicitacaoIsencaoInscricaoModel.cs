using Senac.GCP.API.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class TipoSolicitacaoIsencaoInscricaoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Código' deve ser informado obrigatoriamente.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O 'Código' não pode superar 50 Caracteres.")]
        public string Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A 'descrição' deve ser informado obrigatoriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "A 'descrição' não pode superar 255 Caracteres.")]
        public string Descricao { get; set; }

        [Range(minimum: 0.01d, maximum: 100.00d, ErrorMessage = "O 'Percentual de Isenção da Inscrição' deve estar entre '0,01%' e '100,00%'.")]
        public decimal PercentualIsencaoInscricao { get; set; }
    }
}