using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoEditaisService : Service<ConcursoEditaisEntity>, IConcursoEditaisService
    {
        private readonly IConcursoRepository concursoRepository;

        public ConcursoEditaisService(IConcursoEditaisRepository concursoEditaisRepository,
            IConcursoRepository concursoRepository, IHttpContextAccessor httpContextAccessor)
            : base(concursoEditaisRepository, httpContextAccessor)
        {
            this.concursoRepository = concursoRepository;
        }

        public override void BeforePost(ConcursoEditaisEntity entity)
        {
            VerificarSeDataEditalEMaiorQueDataFinalInscricao(entity);
        }

        public override void BeforePut(ConcursoEditaisEntity entity)
        {
            VerificarSeDataEditalEMaiorQueDataFinalInscricao(entity);
        }

        private void VerificarSeDataEditalEMaiorQueDataFinalInscricao(ConcursoEditaisEntity entity)
        {
            var dataFinalInscricaoConcurso = concursoRepository.GetByIdWithDependencies(entity.IdConcurso).DataFinalInscricao;
            if (entity.DataEdital <= dataFinalInscricaoConcurso)
                throw new BusinessException("A data de inicio do edital deve ser superior a data final de inscrição do concurso");
        }
    }
}