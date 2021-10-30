using Senac.GCP.API.Models.Base;
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

        [Required(ErrorMessage = "O Campo 'Valor da Inscrição' Deve Ser Informado Obrigatóriamente.")]
        public Decimal ValorInscricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Ativo' Deve Ser Informado Obrigatóriamente.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O Campo 'Quantidade de Vagas' Deve Ser Informado Obrigatóriamente.")]
        public int QuantidadeVagas { get; set; }

        [Required(ErrorMessage = "O Campo 'Percentual da Quantidade de Vagas da Ampla Concorrencia' Deve Ser Informado Obrigatóriamente.")]
        public int PercentualQuantidadeVagasAmplaConcorrencia { get; set; }

        public string Observacoes { get; set; }



        /*
        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Nome da Instituição' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Nome da Instituição' Não Pode Superar 255 Caracteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'CNPJ' Deve Ser Informado Obrigatóriamente.")]
        public string CNPJ { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Rua' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Rua' Não Pode Superar 150 Caracteres.")]
        public string EnderecoRua { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Bairro' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Bairro' Não Pode Superar 150 Caracteres.")]
        public string EnderecoBairro { get; set; }

        [Required(ErrorMessage = "O Campo 'Id Municipio' Deve Ser Informado Obrigatóriamente.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Campo 'Id Municipio' Está Inválido!")]
        public int Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'CEP' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 10, ErrorMessage = "O Tamanho do Campo 'CEP' Não Pode Superar 10 Caracteres.")]
        public string EnderecoCEP { get; set; }

        [Required(ErrorMessage = "O Campo 'Ativo' Deve Ser Informado Obrigatóriamente.")]
        public bool Ativo { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "O Tamanho do Campo 'Número' Não Pode Superar 20 Caracteres.")]
        public string EnderecoNumero { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Complemento' Não Pode Superar 150 Caracteres.")]
        public string EnderecoComplemento { get; set; }

        public string Observacoes { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Email' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Email' Não Pode Superar 255 Caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O 'Email' Informado Não é Valido.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Telefone' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 20, ErrorMessage = "O Tamanho do Campo 'Telefone' Não Pode Superar 20 Caracteres.")]
        public string Telefone { get; set; }

        public override void AdditionalValidations()
        {
            if (!ValidadorCNPJ.Validar(CNPJ, out string cnpj))
            {
                throw new Exception("O CNPJ informado não é válido");
            }

            CNPJ = cnpj;
            Email = Email.Trim();
            Nome = Nome.Trim();
        }
        */
    }
}