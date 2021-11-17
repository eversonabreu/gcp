using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Text;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class InscricaoService : Service<InscricaoEntity>, IInscricaoService
    {
        private readonly IInscricaoRepository inscricaoRepository;

        public InscricaoService(IInscricaoRepository inscricaoRepository, IConcursoRepository concursoRepository, IHttpContextAccessor httpContextAccessor)
            : base(inscricaoRepository, httpContextAccessor)
        {
            this.inscricaoRepository = inscricaoRepository;
        }

        public override void BeforePost(InscricaoEntity entity)
        {
            GerarNumeroInscricao(entity);
            entity.Situacao = SituacaoInscricaoEnum.AguardandoPagamento;
            entity.DataInscricao = DateTime.Now;
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
    }
}
