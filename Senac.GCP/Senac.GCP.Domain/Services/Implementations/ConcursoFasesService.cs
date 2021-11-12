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

        private void ValidarDataInicioFase(ConcursoFasesEntity entity)
        {
            var dataFinalInscricaoConcurso = concursoRepository.GetById(entity.IdConcurso).DataFinalInscricao;
            if (entity.DataInicio <= dataFinalInscricaoConcurso)
                throw new BusinessException("A data de inicio deve ser superior a data final de inscrição do concurso");
        }

        private void ValidarDataInicioNovaFase(ConcursoFasesEntity entity)
        {
            //vc precisa as fases pelo repositorio das fases (utilize o id do concurso)
            //se não tiver fases ainda, não faz nada
            //vc precisa identificar se a fase corrente possui antecessor e posterior
            //posterior
            //pegar a data de início da fase posterior (idconcurso = 1 && numeroFase = numeroFaseCorrente + 1)
            //verificar se a data de início é menor ou igual a data de termino da fase corrente. (Se não for lança exceção)
            //antecessor
            //pegar a data de término da fase antecessor (idconcurso = 1 && numeroFase = numeroFaseCorrente - 1)
            //verificar se a data de término é maior ou igual a data de início da fase corrente. (Se não for lança exceção)


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