using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;


namespace Senac.GCP.API.Models
{
    public sealed class InscricaoModel : Model
    {
        public long IdPessoa { get; set; }

        public long IdConcursoCargo { get; set; }

        [DateOnly]
        public DateTime DataInscricao { get; set; }

        [Range(minimum: 1, maximum: 4, ErrorMessage = "Situação de inscrição inválida")]
        public SituacaoInscricaoEnum Situacao { get; set; }

        public bool ParticiparComoCotista { get; set; }

        public string MotivoRecusaInscricao { get; set; }

        [DateOnly]
        public DateTime? DataRecusaInscricao { get; set; }

        [Range(minimum: 0d, maximum: DecimalExtensions.MaxValueToDouble, ErrorMessage = "Valor inválido")]
        public decimal? ValorPago { get; set; }

        [DateOnly]
        public DateTime? DataPagamento { get; set; }

        [Range(minimum: 1, maximum: 2, ErrorMessage = "Tipo de pagamento da inscrição é inválida")]
        public TipoPagamentoEnum? TipoPagamento { get; set; }
        
        public override void OnValidate()
        {
            if (DataRecusaInscricao < DataInscricao)
                throw new BusinessException("A data de recusa da inscrição não pode ser menor que a data  de  inscrição");

            if (DataPagamento < DataInscricao)
                throw new BusinessException("A data de pagamento da inscrição não pode ser menor que a data  de inscrição");
        }
    }
}