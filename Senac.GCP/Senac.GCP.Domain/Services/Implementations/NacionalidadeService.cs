using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class NacionalidadeService : Service<NacionalidadeEntity>, INacionalidadeService
    {
        public NacionalidadeService(INacionalidadeRepository nacionalidadeRepository, IHttpContextAccessor httpContextAccessor)
            : base(nacionalidadeRepository, httpContextAccessor)
        {
        }
    }
}