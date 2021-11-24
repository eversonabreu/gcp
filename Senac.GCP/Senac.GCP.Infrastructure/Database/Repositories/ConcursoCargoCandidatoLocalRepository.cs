using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infrastructure.Database.Repositories.Base;
using System.Linq;

namespace Senac.GCP.Infrastructure.Database.Repositories
{
    public sealed class ConcursoCargoCandidatoLocalRepository : Repository<ConcursoCargoCandidatoLocalEntity>, 
        IConcursoCargoCandidatoLocalRepository
    {
        public ConcursoCargoCandidatoLocalRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public int ObterQuantidadeAlocadosPorLocal(long idConcursoFasesLocais)
        {
            var query = from x in databaseContext.ConcursoCargoCandidatoLocal
                        join y in databaseContext.Inscricao on x.IdInscricao equals y.Id
                        join z in databaseContext.Pessoa on y.IdPessoa equals z.Id
                        where x.IdConcursoFasesLocais == idConcursoFasesLocais && !z.PCD
                        select x;

            if (query is null)
                return 0;

            return query.Count();
        }

        public int ObterQuantidadeAlocadosPorLocalPCD(long idConcursoFasesLocais)
        {
            var query = from x in databaseContext.ConcursoCargoCandidatoLocal
                        join y in databaseContext.Inscricao on x.IdInscricao equals y.Id
                        join z in databaseContext.Pessoa on y.IdPessoa equals z.Id
                        where x.IdConcursoFasesLocais == idConcursoFasesLocais && z.PCD
                        select x;

            if (query is null)
                return 0;

            return query.Count();
        }
    }
}