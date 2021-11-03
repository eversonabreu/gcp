using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class NaturalidadeService : Service<NaturalidadeEntity>, INaturalidadeService
    {
        public NaturalidadeService(INaturalidadeRepository naturalidadeRepository, IHttpContextAccessor httpContextAccessor)
            : base(naturalidadeRepository, httpContextAccessor)
        {
        }
 
        //public override void BeforePost(ConcursoEntity entity)
        //{
        //    int codigo = 0;
        //    entity.Codigo = codigo;
        //}
    }

}