using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infraestructure.Database.Repositories.Base;

namespace Senac.GCP.Infraestructure.Database.Repositories
{
    public sealed class ConcursoFasesRepository : Repository<ConcursoFasesEntity>, IConcursoFasesRepository
    {
        public ConcursoFasesRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}