using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class PessoaModel : Model
    {
        public long IdArquivoFoto { get; set; }

        public long IdNacionalidade { get; set; }

        public long? IdClassificacaoDoenca { get; set; }

        public long IdCorRaca { get; set; }

        public long IdMunicipioEndereco { get; set; }

        public long? IdMunicipioNaturalidade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Nome' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Nome' aceita no máximo 255 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string Nome { get; set; }

        [DateOnly]
        public DateTime DataNascimento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'CPF' não foi preenchido")]
        public string CPF { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'RG' não foi preenchido")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string RG { get; set; }

        [DateOnly]
        public DateTime DataEmissaoRG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'OrgaoEmissorRG' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'OrgaoEmissorRG' aceita no máximo 255 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string OrgaoEmissorRG { get; set; }

        public char Genero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Email' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Email' aceita no máximo 255 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O conteúdo informado para o campo 'Email' não representa um e-mail válido")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both, AlterCase = AlterCaseEnum.Upper)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Telefone' não foi preenchido")]
        [StringLength(maximumLength: 11, ErrorMessage = "O campo 'Telefone' aceita no máximo 11 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string Telefone { get; set; }

        public bool PCD { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoRua' não foi preenchido")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoRua' aceita no máximo 150 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoRua { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoNumero' não foi preenchido")]
        [StringLength(maximumLength: 20, ErrorMessage = "O campo 'EnderecoNumero' aceita no máximo 20 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoNumero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoBairro' não foi preenchido")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoBairro' aceita no máximo 150 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoBairro { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoComplemento' aceita no máximo 150 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoComplemento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoCEP' não foi preenchido")]
        [StringLength(maximumLength: 10, ErrorMessage = "O campo 'EnderecoCEP' aceita no máximo 10 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string EnderecoCEP { get; set; }

        public NivelEscolaridadeEnum NivelEscolaridade { get; set; }

        public override void AdditionalValidations()
        {
            if (Genero != 'F' && Genero != 'M')
                throw new BusinessException("O Gênero informado é inválido. Deve ser 'F' para 'Feminino' ou 'M' para 'Masculino'");

            if (DataNascimento.AddYears(18) >= DateTime.Today)
                throw new Exception("A data de nascimento informada não é válida. A pessoa deve ter 18 anos ou mais.");            

            if (!ValidadorCPF.Validar(CPF, out string cpf))
                throw new BusinessException("O CPF informado não é válido");

            CPF = cpf;

            if (DataNascimento.AddYears(18) > DateTime.Today)
                throw new BusinessException("É necessário ter 18 anos completos para o cadastramento no sistema");

            if (DataEmissaoRG < DataNascimento || DataEmissaoRG > DateTime.Today)
                throw new BusinessException("A data de emissão do RG não é válida");
        }
    }
}