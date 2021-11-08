using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class InstituicaoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Nome da Instituição' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Nome da Instituição' Não Pode Superar 255 Caracteres.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'CNPJ' Deve Ser Informado Obrigatóriamente.")]
        public string CNPJ { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Rua' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Rua' Não Pode Superar 150 Caracteres.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoRua { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Bairro' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Bairro' Não Pode Superar 150 Caracteres.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoBairro { get; set; }

        public long IdMunicipio { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'CEP' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 10, ErrorMessage = "O Tamanho do Campo 'CEP' Não Pode Superar 10 Caracteres.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoCEP { get; set; }

        public bool Ativo { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "O Tamanho do Campo 'Número' Não Pode Superar 20 Caracteres.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoNumero { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Complemento' Não Pode Superar 150 Caracteres.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoComplemento { get; set; }

        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string Observacoes { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Email' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O Tamanho do Campo 'Email' Não Pode Superar 255 Caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O 'Email' Informado Não é Valido.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both, AlterCase = AlterCaseEnum.Upper)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Telefone' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 20, ErrorMessage = "O Tamanho do Campo 'Telefone' Não Pode Superar 20 Caracteres.")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string Telefone { get; set; }

        public override void AdditionalValidations()
        {
            if (!ValidadorCNPJ.Validar(CNPJ, out string cnpj))
            {
                throw new BusinessException("O CNPJ informado não é válido");
            }

            CNPJ = cnpj;
        }
    }
}