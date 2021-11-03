﻿using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoModel : Model
    {
        public int Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Descrição' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Descrição' Não Pode Superar 255 Caracteres.")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O Campo 'Data Inicial da Inscricao' Deve Ser Informado Obrigatóriamente.")]
        public DateTime DataInicioInscricao { get; set; }


        [Required(ErrorMessage = "O Campo 'Data Final da Inscrição' Deve Ser Informado Obrigatóriamente.")]
        public DateTime DataFinalInscricao { get; set; }


        [Required(ErrorMessage = "O Campo 'Id Instituição Solicitante' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Campo 'Id Instituição Solicitante' Está Inválido!")]
        public long IdInstituicaoSolicitante { get; set; }


        [Required(ErrorMessage = "O Campo 'Id Instituição Organizadora' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Campo 'Id Instituição Organizadora' Está Inválido!")]
        public long IdInstituicaoOrganizadora { get; set; }


        [Required(ErrorMessage = "O Campo 'Prazo Final da Insenção do Valor da Inscrição' Deve Ser Informado Obrigatóriamente.")]
        public DateTime PrazoFinalIsencaoValorInscricao { get; set; }


        [RegularExpression(@"^(0 *[1 - 9][0 - 9] * (\.[0-9]+)?|0+\.[0-9]*[1 - 9][0 - 9]*)$", ErrorMessage = "O Valor Informado Deve Ser Maior Que Zero.")]
        [Required(ErrorMessage = "O Campo 'Valor da Inscrição' Deve Ser Informado Obrigatóriamente.")]
        public decimal ValorInscricao { get; set; }


        [Required(ErrorMessage = "O Campo 'Ativo' Deve Ser Informado Obrigatóriamente.")]
        public bool Ativo { get; set; }


        [Required(ErrorMessage = "O Campo 'Quantidade de Vagas' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "O Campo 'Quantidade de Vagas' Está Inválido!")]
        public int QuantidadeVagas { get; set; }


        [Required(ErrorMessage = "O Campo 'Percentual da Quantidade de Vagas da Ampla Concorrencia' Deve Ser Informado Obrigatóriamente.")]
        public int PercentualQuantidadeVagasAmplaConcorrencia { get; set; }


        public string Observacoes { get; set; }

        public override void AdditionalValidations()
        {
            if (!ValidadorPercentualVagasConcurso.Validar(PercentualQuantidadeVagasAmplaConcorrencia, out int percentual))
            {
                throw new Exception("O Percentual Informado Ultrapassa A Somatória Total de Vagas");
            }
            PercentualQuantidadeVagasAmplaConcorrencia = percentual;

            if (!ValidarDatasDoConcurso(DataInicioInscricao, DateTime.Today))
            {
                throw new Exception("A Data de Inicio da Inscrição Não Pode Ser Menor Que a Data Corrente");
            }

            if (!ValidarDatasDoConcurso(DataFinalInscricao, DataInicioInscricao))
            {
                throw new Exception("A Data Final da Inscrição Não Pode Ser Menor Que a Data de Inicio");
            }

            if (!ValidarDatasDoConcurso(PrazoFinalIsencaoValorInscricao, DataInicioInscricao))
            {
                throw new Exception("O Prazo Final da Isenção da Inscrição Não Pode Ser Menor Que a Data de Inicio");
            }

            if (!ValidarDatasDoConcurso(DataFinalInscricao, PrazoFinalIsencaoValorInscricao))
            {
                throw new Exception("O Prazo Final da Isenção da Inscrição Não Pode Ser Maior Que a Data Final");
            }
        }

        public bool ValidarDatasDoConcurso(DateTime dataParametro, DateTime dataComparativa)
        {            
            if(dataParametro <= dataComparativa)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}