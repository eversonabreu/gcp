using Senac.GCP.API.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class TipoSolicitacaoIsencaoInscricaoModel : Model
    {

        public string Codigo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'descrição' deve ser informado obrigatoriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho do campo 'descrição' não pode superar 255 Caracteres.")]
        public string Descricao { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Percentual Isenção da Inscrição' deve ser informado obrigatoriamente.")]
        [Range(minimum: 0.1, maximum: 100, ErrorMessage = "O campo 'Percentual Isenção da Inscrição' deve ser maior que 0.1 (zero ponto um) e menor ou igual a 100 (cem).")]
        public decimal PercentualIsencaoInscricao { get; set; }
    }
}