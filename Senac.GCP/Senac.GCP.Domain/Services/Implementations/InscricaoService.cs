using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Text;
using Senac.GCP.Domain.Exceptions;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class InscricaoService : Service<InscricaoEntity>, IInscricaoService
    {
        private readonly IInscricaoRepository inscricaoRepository;
        private readonly IConcursoCargoRepository concursoCargoRepository;

    public InscricaoService(IInscricaoRepository inscricaoRepository, IConcursoCargoRepository concursoCargoRepository, IHttpContextAccessor httpContextAccessor)
            : base(inscricaoRepository, httpContextAccessor)
        {
            this.inscricaoRepository = inscricaoRepository;
            this.concursoCargoRepository = concursoCargoRepository;
        }
        public override void BeforePost(InscricaoEntity entity)
        {
            ValidarDatas(entity);
            GerarNumeroInscricao(entity);
            entity.Situacao = SituacaoInscricaoEnum.AguardandoPagamento;
        }

        private void GerarNumeroInscricao(InscricaoEntity entity)
        {
            do
            {
                var num = new StringBuilder();
                num.Append('1');

                for (int aux = 0; aux < 8; aux++)
                {
                    var random = new Random();
                    num.Append(random.Next(0, 10));
                }

                string numeroInscricao = num.ToString();
                if (inscricaoRepository.SingleOrDefault(x => x.NumeroInscricao == numeroInscricao) is null)
                {
                    entity.NumeroInscricao = numeroInscricao;
                    break;
                }

            } while (true);
        }
  
        public void ValidarDatas(InscricaoEntity entity)
        {
            var concurso = concursoCargoRepository.GetByIdWithDependencies(entity.IdConcursoCargo).Concurso;

            if (entity.DataInscricao < concurso.DataInicioInscricao)
                throw new BusinessException("A data de inscriçao não pode ser inferior a data de início do concurso!");

            if (entity.DataInscricao > concurso.DataFinalInscricao)
                throw new BusinessException("A data de inscriçao não pode ser superior a data final de inscrição do concurso!");

            if (entity.DataPagamento < concurso.DataInicioInscricao)
                throw new BusinessException("A data de pagamento não pode ser inferior a data de inscrição!");

            if (entity.DataPagamento > concurso.DataFinalInscricao)
                throw new BusinessException("A data de pagamento não pode ser superior a data final de inscrição!");
        }

    }
}