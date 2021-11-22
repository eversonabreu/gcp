using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infrastructure.Database.Repositories.Base;

namespace Senac.GCP.Infrastructure.Database.Repositories
{
    public sealed class ConcursoTipoCotasRepository : Repository<ConcursoTipoCotasEntity>, IConcursoTipoCotasRepository
    {
        public ConcursoTipoCotasRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}