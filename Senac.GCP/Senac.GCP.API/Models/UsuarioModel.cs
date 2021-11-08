using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class UsuarioModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Nome' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Nome' aceita no máximo 255 caracteres")]
        [StringOptions(TrimSpace = TrimSpaceEnum.Both)]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Email' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Email' aceita no máximo 255 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O conteúdo informado para o campo 'Email' não representa um e-mail válido")]
        [StringOptions(AlterCase = AlterCaseEnum.Upper, TrimSpace = TrimSpaceEnum.Both)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'CPF' não foi preenchido")]
        public string CPF { get; set; }

        public bool Administrador { get; set; }

        public bool Ativo { get; set; }

        public override void AdditionalValidations()
        {
            if (!ValidadorCPF.Validar(CPF, out string cpf))
            {
                throw new Exception("O CPF informado não é válido");
            }

            CPF = cpf;
        }
    }
}