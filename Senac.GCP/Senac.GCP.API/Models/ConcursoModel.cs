using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoModel : Model
    {
        public int Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Descrição' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Descrição' Não Pode Superar 255 Caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Data Inicial da Inscricao' Deve Ser Informado Obrigatóriamente.")]
        [DataType(DataType.Date, ErrorMessage = "Data 'Data Inicial da Inscrição' inválida")]
        [DateOnly]
        public DateTime DataInicioInscricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Data Final da Inscrição' Deve Ser Informado Obrigatóriamente.")]
        [DataType(DataType.Date, ErrorMessage = "Data 'Data Final da Inscrição' inválida")]
        [DateOnly]
        public DateTime DataFinalInscricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Id Instituição Solicitante' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Campo 'Id Instituição Solicitante' Está Inválido!")]
        public long IdInstituicaoSolicitante { get; set; }

        [Required(ErrorMessage = "O Campo 'Id Instituição Organizadora' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Campo 'Id Instituição Organizadora' Está Inválido!")]
        public long IdInstituicaoOrganizadora { get; set; }

        [Required(ErrorMessage = "O Campo 'Prazo Final da Insenção do Valor da Inscrição' Deve Ser Informado Obrigatóriamente.")]
        [DataType(DataType.Date, ErrorMessage = "Data 'Prazo Final da Insenção do Valor da Inscrição' inválida")]
        [DateOnly]
        public DateTime PrazoFinalIsencaoValorInscricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Valor da Inscrição' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 0.01d, maximum: double.MaxValue, ErrorMessage = "Valor de inscrição inválido")]
        public decimal ValorInscricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Ativo' Deve Ser Informado Obrigatóriamente.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O Campo 'Quantidade de Vagas' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "O Campo 'Quantidade de Vagas' Está Inválido!")]
        public int QuantidadeVagas { get; set; }

        [Required(ErrorMessage = "O Campo 'Percentual da Quantidade de Vagas da Ampla Concorrencia' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: 100, ErrorMessage = "O Campo 'Percentual da Quantidade de Vagas da Ampla Concorrencia' Deve Ser menor ou igual a 1 (um) e menor ou igual a 100 (cem).")]
        public int PercentualQuantidadeVagasAmplaConcorrencia { get; set; }

        public string Observacoes { get; set; }

        public override void OnValidate()
        {
            if (!DataEhValida(DataInicioInscricao, DateTime.Today))
                throw new BusinessException("A Data de Inicio da Inscrição Não Pode Ser Menor Que a Data Corrente");

            if (!DataEhValida(DataFinalInscricao, DataInicioInscricao))
                throw new BusinessException("A Data Final da Inscrição Não Pode Ser Menor Que a Data de Inicio");

            if (!DataEhValida(PrazoFinalIsencaoValorInscricao, DataInicioInscricao))
                throw new BusinessException("O Prazo Final da Isenção da Inscrição Não Pode Ser Menor Que a Data de Inicio");

            if (!DataEhValida(DataFinalInscricao, PrazoFinalIsencaoValorInscricao))
                throw new BusinessException("O Prazo Final da Isenção da Inscrição Não Pode Ser Maior Que a Data Final");
        }

        private static bool DataEhValida(DateTime data, DateTime dataComparativa)
            => data > dataComparativa;
    }
}