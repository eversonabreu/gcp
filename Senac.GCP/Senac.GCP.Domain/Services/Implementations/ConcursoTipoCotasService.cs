using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoTipoCotasService : Service<ConcursoTipoCotasEntity>, IConcursoTipoCotasService
    {
        private readonly IConcursoTipoCotasRepository concursoTipoCotasRepository;
        private readonly IConcursoRepository concursoRepository;

        public ConcursoTipoCotasService(IConcursoTipoCotasRepository concursoTipoCotasRepository,
            IHttpContextAccessor httpContextAccessor,
            IConcursoRepository concursoRepository)
            : base(concursoTipoCotasRepository, httpContextAccessor)
        {
            this.concursoTipoCotasRepository = concursoTipoCotasRepository;
            this.concursoRepository = concursoRepository;
        }

        public override void BeforePost(ConcursoTipoCotasEntity entity)
        {
            ValidarPercentualDeVagas(entity);
        }

        public override void BeforePut(ConcursoTipoCotasEntity entity)
        {
            ValidarPercentualDeVagas(entity, entity.Id);
        }

        private void ValidarPercentualDeVagas(ConcursoTipoCotasEntity entity, long? id = null)
        {
            int totalPercentualDeVagasAmplaConcorrencia =
                concursoRepository.GetById(entity.IdConcurso).PercentualQuantidadeVagasAmplaConcorrencia;

            var vagasCotistas = concursoTipoCotasRepository
                .Filter(x => x.IdConcurso == entity.IdConcurso);

            if (id.HasValue)
                vagasCotistas = vagasCotistas.Where(x => x.Id != id.Value);

            int totalPercentualDeVagasCotistas = vagasCotistas.Sum(x => x.PercentualVagas);

            int totalPercentualDeVagas = totalPercentualDeVagasAmplaConcorrencia
                + totalPercentualDeVagasCotistas
                + entity.PercentualVagas;

            if (totalPercentualDeVagas > 100)
                throw new BusinessException("Não é possível salvar porque o percentual de vagas do concurso (ampla concorrência mais vagas para cotistas) ultrapassa 100%");
        }
    }
}