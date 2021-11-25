using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IConcursoCargoCandidatoLocalService : IService<ConcursoCargoCandidatoLocalEntity>
    {
        void SelecionarLocalFase(long idInscricao, long idConcursoFasesLocais);
    }
}