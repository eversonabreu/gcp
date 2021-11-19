using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class IntegrantesComissaoOrganizacaoService : Service<IntegrantesComissaoOrganizacaoEntity>, IIntegrantesComissaoOrganizacaoService
    {
        private readonly IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository;
        private readonly IInscricaoRepository inscricaoRepository;

        public IntegrantesComissaoOrganizacaoService(IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository,
            IInscricaoRepository inscricaoRepository,
            IHttpContextAccessor httpContextAccessor)
            : base(integrantesComissaoOrganizacaoRepository, httpContextAccessor)
        {
            this.integrantesComissaoOrganizacaoRepository = integrantesComissaoOrganizacaoRepository;
            this.inscricaoRepository = inscricaoRepository;
        }

        public bool VerificarExistenciaDeIntegrantesPorInscricao(long idInscricao)
        {
            var concursoCargo = inscricaoRepository.GetByIdWithDependencies(idInscricao).ConcursoCargo;
            return integrantesComissaoOrganizacaoRepository.Filter(x => x.IdConcurso == concursoCargo.IdConcurso).Any();
        }

        public void EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencao(long idInscricao)
        {

        }
    }
}