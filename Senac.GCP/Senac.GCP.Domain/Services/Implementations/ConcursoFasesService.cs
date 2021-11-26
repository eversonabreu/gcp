using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoFasesService : Service<ConcursoFasesEntity>, IConcursoFasesService
    {
        private readonly IConcursoRepository concursoRepository;
        private readonly IConcursoFasesRepository concursoFasesRepository;

        public ConcursoFasesService(IConcursoFasesRepository concursoFasesRepository,
            IHttpContextAccessor httpContextAccessor, IConcursoRepository concursoRepository)
            : base(concursoFasesRepository, httpContextAccessor)
        {
            this.concursoRepository = concursoRepository;
            this.concursoFasesRepository = concursoFasesRepository;
        }

        public override void BeforePost(ConcursoFasesEntity entity)
        {
            VerificarSeFaseIniciaAntesDoPeriodoFinalDeInscricaoDoConcurso(entity);
            entity.NumeroFase = GerarNumeroFase(entity.IdConcurso);
            ValidarIntervalosDaFase(entity);
        }

        public override void BeforePut(ConcursoFasesEntity entity)
        {
            VerificarSeFaseIniciaAntesDoPeriodoFinalDeInscricaoDoConcurso(entity);
            ValidarIntervalosDaFase(entity);
        }

        public override void AfterDelete(ConcursoFasesEntity entity)
        {
            AjustarNumeracaoDasFases(entity.IdConcurso);
        }

        private void AjustarNumeracaoDasFases(long idConcurso)
        {
            var fases = concursoFasesRepository.Filter(x => x.IdConcurso == idConcurso).OrderBy(x => x.NumeroFase);
            int numeroFase = 1;
            foreach (var item in fases)
            {
                if (item.NumeroFase != numeroFase)
                {
                    item.NumeroFase = numeroFase;
                    concursoFasesRepository.Update(item);
                }

                numeroFase++;
            }
        }

        private void VerificarSeFaseIniciaAntesDoPeriodoFinalDeInscricaoDoConcurso(ConcursoFasesEntity entity)
        {
            var concurso = concursoRepository.GetById(entity.IdConcurso);

            if (entity.DataInicio <= concurso.DataFinalInscricao)
                throw new BusinessException("A data de inicio da fase deve ser superior a data final de inscrição do concurso");
        }

        private void ValidarIntervalosDaFase(ConcursoFasesEntity entity)
        {
            var faseAnterior = concursoFasesRepository
                .SingleOrDefault(x => x.IdConcurso == entity.IdConcurso && x.NumeroFase == (entity.NumeroFase - 1));
            if (faseAnterior != null && faseAnterior.DataTermino > entity.DataInicio)
                throw new BusinessException($"Não é possível salvar porque a data de início da fase deve ser igual ou superior à '{faseAnterior.DataTermino:dd/MM/yyyy}'");

            var fasePosterior = concursoFasesRepository
                .SingleOrDefault(x => x.IdConcurso == entity.IdConcurso && x.NumeroFase == (entity.NumeroFase + 1));
            if (fasePosterior != null && fasePosterior.DataInicio < entity.DataTermino)
                throw new BusinessException($"Não é possível salvar porque a data de término da fase deve ser igual ou inferior à '{fasePosterior.DataInicio:dd/MM/yyyy}'");
        }

        private int GerarNumeroFase(long idConcurso)
        {
            int quantidadeFases = concursoFasesRepository.Filter(x => x.IdConcurso == idConcurso).Count();
            quantidadeFases++;
            return quantidadeFases;
        }
    }
}