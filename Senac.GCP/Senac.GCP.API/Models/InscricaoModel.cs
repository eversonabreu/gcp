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

        //validar se as datas são iguais ou maiores que a data de início do concurso
        //validar dar se as datas são iguais ou menores que a data de finalização de inscrição do concurso
        //validar se data a data de recusa da inscrição é igual ou superior a data de inscrição
        //validar se data a data de pagamento é igual ou superior a data de inscrição
        
    }
}