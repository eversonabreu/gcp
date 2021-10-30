using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoEditaisService : Service<ConcursoEditaisEntity>, IConcursoEditaisService
    {
        public ConcursoEditaisService(IConcursoEditaisRepository concursoEditaisRepository, IHttpContextAccessor httpContextAccessor)
            : base(concursoEditaisRepository, httpContextAccessor)
        {
        }

        public override void BeforePost(ConcursoEditaisEntity entity)
        {
            entity.DataEdital = DateTime.Now;
        }
    }
}