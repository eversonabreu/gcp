using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Senac.GCP.API.Models
{
    public sealed class PessoaModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Nome' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Nome' aceita no máximo 255 caracteres")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'DataNascimento' não foi preenchido")]
        public DateTime DataNascimento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'CPF' não foi preenchido")]
        [StringLength(maximumLength: 14, ErrorMessage = "O campo 'CPF' aceita no máximo 14 caracteres")]
        public string CPF { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'RG' não foi preenchido")]
        [StringLength(maximumLength: 7, ErrorMessage = "O campo 'RG' aceita no máximo 7 caracteres")]
        public string RG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'DataEmissaoRG' não foi preenchido")]
        public DateTime DataEmissaoRG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Orgão Emissor' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Orgão Emissor' aceita no máximo 255 caracteres")]
        public string OrgaoEmissorRG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Genero' não foi preenchido")]
        [StringLength(maximumLength: 1, ErrorMessage = "O campo 'Genero' aceita no máximo 1 caracteres")]
        public char Genero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Email' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Email' aceita no máximo 255 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O conteúdo informado para o campo 'Email' não representa um e-mail válido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Telefone' não foi preenchido")]
        [StringLength(maximumLength: 11, ErrorMessage = "O campo 'Telefone' aceita no máximo 11 caracteres")]
        public string Telefone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'PCD' não foi preenchido")]
        [StringLength(maximumLength: 1, ErrorMessage = "O campo 'PCD' aceita no máximo 1 caracteres")]
        public bool PCD { get; set; }

        public long IdNacionalidade { get; set; }

        public long IdClassificacaoDoenca { get; set; }

        public long IdCorRaca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Rua' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Rua' Não Pode Superar 150 Caracteres.")]
        public string EnderecoRua { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "O campo 'Número' aceita no máximo 20 caracteres")]
        public string EnderecoNumero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'Bairro' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Bairro' Não Pode Superar 150 Caracteres.")]
        public string EnderecoBairro { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "O Tamanho do Campo 'Complemento' Não Pode Superar 150 Caracteres.")]
        public string EnderecoComplemento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo 'CEP' Deve Ser Informado Obrigatóriamente.")]
        [StringLength(maximumLength: 10, ErrorMessage = "O Tamanho do Campo 'CEP' Não Pode Superar 10 Caracteres.")]
        public string EnderecoCEP { get; set; }

        public long IdMunicipio { get; set; }

        public bool Ativo { get; set; }

        public string ChaveAcesso { get; set; }

        public long IdArquivoFoto { get; set; }

        public long IdNaturalidade { get; set; }

    }
}
