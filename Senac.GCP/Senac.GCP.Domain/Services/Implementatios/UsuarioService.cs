using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementatios
{
    public sealed class UsuarioService : Service<UsuarioEntity>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository, IHttpContextAccessor httpContextAccessor)
            : base (usuarioRepository, httpContextAccessor) { }
    }
}
