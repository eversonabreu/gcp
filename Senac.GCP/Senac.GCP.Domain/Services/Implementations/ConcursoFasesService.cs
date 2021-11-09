using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
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
            ValidarDataInicioFase(entity);
            ValidarDataInicioNovaFase(entity);
            entity.NumeroFase = GerarNumeroFase(entity.IdConcurso);
        }

        public override void BeforePut(ConcursoFasesEntity entity)
        {
            ValidarDataInicioFase(entity);
            ValidarDataInicioNovaFase(entity);
        }

        public override void AfterDelete(long id)
        {

        }

        private void ValidarDataInicioFase(ConcursoFasesEntity entity)
        {
            var dataFinalInscricaoConcurso = concursoRepository.GetById(entity.IdConcurso).DataFinalInscricao;
            if (entity.DataInicio <= dataFinalInscricaoConcurso)
                throw new BusinessException("A data de inicio deve ser superior a data final de inscrição do concurso");
        }

        private void ValidarDataInicioNovaFase(ConcursoFasesEntity entity)
        {
            if (entity.DataInicio < entity.DataTermino)
                throw new BusinessException("A data de inicio da nova fase, deve superior ou igual à anterior");
        }

        private int GerarNumeroFase(long idConcurso)
        {
            int quantidadeFases = concursoFasesRepository.Filter(x => x.IdConcurso == idConcurso).Count();
            return quantidadeFases++;
        }
    }
}