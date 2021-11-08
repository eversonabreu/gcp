using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoService : Service<ConcursoEntity>, IConcursoService
    {
        private readonly IConcursoRepository concursoRepository;
        private readonly IConcursoTipoCotasRepository concursoTipoCotasRepository;

        public ConcursoService(IConcursoRepository concursoRepository,
            IConcursoTipoCotasRepository concursoTipoCotasRepository,
            IHttpContextAccessor httpContextAccessor)
            : base(concursoRepository, httpContextAccessor)
        {
            this.concursoRepository = concursoRepository;
            this.concursoTipoCotasRepository = concursoTipoCotasRepository;
        }

        private static int GerarCodigoConcurso()
        {
            int anoCorrente = DateTime.Today.Year;
            var numeroAleatorio = new Random();
            int numeroAleatorioValor = numeroAleatorio.Next(1000, 9999);
            int numeroConcurso = int.Parse($"{anoCorrente}{numeroAleatorioValor}");
            return numeroConcurso;
        }
 
        public override void BeforePost(ConcursoEntity entity)
        {
            entity.Numero = GerarCodigoConcurso();
        }

        public override void BeforePut(ConcursoEntity entity)
        {
            if (ObterPercentualTotalDeVagas(entity.Id, entity.PercentualQuantidadeVagasAmplaConcorrencia) > 100)
                throw new Exception("Não é possível atualizar porque o percentual de vagas do concurso (ampla concorrência mais vagas para cotistas) ultrapassa 100%");
        }

        private int ObterPercentualTotalDeVagas(long idConcurso, int percentualQuantidadeVagasAmplaConcorrencia)
        {
            int totalPercentualDeVagasCotistas = concursoTipoCotasRepository
                .Filter(x => x.IdConcurso == idConcurso)
                .Sum(x => x.PercentualVagas);
            int totalPercentualDeVagas = percentualQuantidadeVagasAmplaConcorrencia + totalPercentualDeVagasCotistas;
            
            return totalPercentualDeVagas;
        }

        public int ObterPercentualTotalDeVagas(long idConcurso)
        {
            int totalPercentualDeVagasAmplaConcorrencia =
                concursoRepository.GetById(idConcurso).PercentualQuantidadeVagasAmplaConcorrencia;
            int totalPercentualDeVagasCotistas = concursoTipoCotasRepository
                .Filter(x => x.IdConcurso == idConcurso)
                .Sum(x => x.PercentualVagas);
            int totalPercentualDeVagas = totalPercentualDeVagasAmplaConcorrencia + totalPercentualDeVagasCotistas;

            return totalPercentualDeVagas;
        }
    }
}