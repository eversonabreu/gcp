using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;

namespace Senac.GCP.Domain.Entities
{
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