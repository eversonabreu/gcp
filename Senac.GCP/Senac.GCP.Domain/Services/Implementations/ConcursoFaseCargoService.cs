using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;


namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoFaseCargoService : Service<ConcursoFaseCargoEntity>, IConcursoFaseCargoService
    {
        public ConcursoFaseCargoService(IConcursoFaseCargoRepository ConcursoFaseCargoRepository, IHttpContextAccessor httpContextAccessor)
            : base(ConcursoFaseCargoRepository, httpContextAccessor)
        {
        }
    }
}
