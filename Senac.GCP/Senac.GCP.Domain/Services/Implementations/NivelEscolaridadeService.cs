using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class NivelEscolaridadeService : Service<NivelEscolaridadeEntity>, INivelEscolaridadeService
    {
        public NivelEscolaridadeService(INivelEscolaridadeRepository nivelEscolaridadeRepository, IHttpContextAccessor httpContextAccessor)
            : base(nivelEscolaridadeRepository, httpContextAccessor)
        {
        }
    }
}