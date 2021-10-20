using Senac.GCP.Domain.Entities.Base;
using System;

namespace Senac.GCP.Domain.Entities
{
    public sealed class UsuarioEntity : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Senha { get; set; }
        
        public DateTime DataCadastramento { get; set; }
        
        public bool Administrador { get; set; }

        public bool Ativo { get; set; }
    }
}
