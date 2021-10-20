using Senac.GCP.API.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class UsuarioModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Nome' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Nome' aceita no máximo 255 caracteres")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Email' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Email' aceita no máximo 255 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O conteúdo informado para o campo 'Email' não representa um e-mail válido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'CPF' não foi preenchido")]
        public string CPF { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastramento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Administrador' não foi definido")]
        public bool Administrador { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Ativo' não foi definido")]
        public bool Ativo { get; set; }

        public override void AdditionalValidations()
        {
            string CPFAuxiliar = string.Empty;
            foreach (char ch in CPF)
                if (char.IsDigit(ch))
                    CPFAuxiliar += ch;

            if (CPFAuxiliar.Length != 11)
                throw new Exception("O CPF é inválido!");

            CPF = CPFAuxiliar;
        }
    }
}
