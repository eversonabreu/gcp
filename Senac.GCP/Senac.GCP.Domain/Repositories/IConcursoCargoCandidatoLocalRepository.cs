using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories.Base;

namespace Senac.GCP.Domain.Repositories
{
    public interface IConcursoCargoCandidatoLocalRepository : IRepository<ConcursoCargoCandidatoLocalEntity>
    {
        int ObterQuantidadeAlocadosPorLocal(long idConcursoFasesLocais);

        int ObterQuantidadeAlocadosPorLocalPCD(long idConcursoFasesLocais);
    }
}