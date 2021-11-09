using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
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

        public InscricaoService(IInscricaoRepository inscricaoRepository, IHttpContextAccessor httpContextAccessor)
            : base(inscricaoRepository, httpContextAccessor)
        {
            this.inscricaoRepository = inscricaoRepository;
        }

        public override void BeforePost(InscricaoEntity entity)
        {
            while (true)
            {
                string numeroInscricao = GerarNumeroInscricao();

                if (numeroInscricao == entity.NumeroInscricao) continue;

                else entity.NumeroInscricao = numeroInscricao; break;
            }
        }

        private string GerarNumeroInscricao()
        {
            var num = new StringBuilder();
            num.Append("1");
            for (int i = 0; i < 7; i++)
            {
                var random = new Random();
                num.Append(random.Next(0, 10));
            }

            return num.ToString();
        }
    }
}
