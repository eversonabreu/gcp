using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoFasesLocaisModel : Model
    {
        [Required(ErrorMessage = "O campo 'IdConcursoFases' não foi preenchido")]
        public long IdConcursoFases { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'NomeLocal' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'NomeLocal' aceita no máximo 255 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both, AlterCase = AlterCaseEnum.Upper)]
        public string NomeLocal { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoRua' não foi preenchido")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoRua' aceita no máximo 150 caracteres")]
        public string EnderecoRua { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "O campo 'EnderecoNumero' aceita no máximo 20 caracteres")]
        public string EnderecoNumero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoBairro' não foi preenchido")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoBairro' aceita no máximo 150 caracteres")]
        public string EnderecoBairro { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoComplemento' aceita no máximo 150 caracteres")]
        public string EnderecoComplemento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoCEP' não foi preenchido")]
        [StringLength(maximumLength: 10, ErrorMessage = "O campo 'EnderecoCEP' aceita no máximo 10 caracteres")]
        public string EnderecoCEP { get; set; }

        [Required(ErrorMessage = "O campo 'IdMunicipioEndereco' não foi preenchido")]
        public long IdMunicipioEndereco { get; set; }

        [StringLength(maximumLength: 11, ErrorMessage = "O campo 'Telefone' aceita no máximo 11 caracteres")]
        public string Telefone { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Email' aceita no máximo 255 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O conteúdo informado para o campo 'Email' não representa um e-mail válido")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both, AlterCase = AlterCaseEnum.Upper)]
        public string Email { get; set; }

    }
}