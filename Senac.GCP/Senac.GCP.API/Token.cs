using System;

namespace Senac.GCP.API
{
    public sealed class Token
    {
        public long IdUsuario { get; set; }

        public bool Administrador { get; set; }

        public DateTime DataExpiracao { get; set; }
    }
}
