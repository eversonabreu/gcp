using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoService : Service<ConcursoEntity>, IConcursoService
    {
        public ConcursoService(IConcursoRepository concursoRepository, IHttpContextAccessor httpContextAccessor)
            : base(concursoRepository, httpContextAccessor)
        {
        }
    }
}