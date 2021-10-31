using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoTipoCotasService : Service<ConcursoTipoCotasEntity>, IConcursoTipoCotasService
    {
        public ConcursoTipoCotasService(IConcursoTipoCotasRepository concursoTipoCotasRepository, IHttpContextAccessor httpContextAccessor)
            : base(concursoTipoCotasRepository, httpContextAccessor)
        {
        }
 
        public override void BeforePost(ConcursoTipoCotasEntity entity)
        {
            int percentualVagas = 0;
            entity.PercentualVagas = percentualVagas;
        }
    }
}