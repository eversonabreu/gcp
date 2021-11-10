using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "UkUsuarioCPF", ErrorMessage = "O CPF informado já está sendo utilizado por outro registro")]
    [Constraint(Name = "UkUsuarioEmail", ErrorMessage = "O E-mail informado já está sendo utilizado por outro registro")]
    public sealed class UsuarioEntity : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        [NotUpdated]
        public string Senha { get; set; }

        [NotUpdated]
        public DateTime DataCadastramento { get; set; }

        public bool Administrador { get; set; }

        public bool Ativo { get; set; }
    }
}