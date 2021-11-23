using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infrastructure.Database.Repositories.Base;
using System.Linq;

namespace Senac.GCP.Infrastructure.Database.Repositories
{
    public sealed class ConcursoRepository : Repository<ConcursoEntity>, IConcursoRepository
    {
        public ConcursoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public ConcursoEntity ObterConcursoPorInscricao(long idInscricao)
        {
            var concurso = (from con in databaseContext.Concurso
                            join car in databaseContext.ConcursoCargo on con.Id equals car.IdConcurso
                            join ins in databaseContext.Inscricao on car.Id equals ins.IdConcursoCargo
                            where ins.Id == idInscricao
                            select con
                            )
                           .FirstOrDefault();

            if (concurso is null)
                throw new BusinessException($"Nenhum concurso encontrado pela inscrição de ID: '{idInscricao}'.");

            return concurso;
        }
    }
}