using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class SolicitacaoIsencaoInscricaoService : Service<SolicitacaoIsencaoInscricaoEntity>, ISolicitacaoIsencaoInscricaoService
    {
        private readonly IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService;

        public SolicitacaoIsencaoInscricaoService(ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository,
            IHttpContextAccessor httpContextAccessor, 
            IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService
            )
            : base(solicitacaoIsencaoInscricaoRepository, httpContextAccessor)
        {
            this.integrantesComissaoOrganizacaoService = integrantesComissaoOrganizacaoService;
        }

        public override void AfterPost(SolicitacaoIsencaoInscricaoEntity entity)
        {
            integrantesComissaoOrganizacaoService.EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencao(entity.IdInscricao);
        }

        public override void BeforePost(SolicitacaoIsencaoInscricaoEntity entity)
        {
            if (!integrantesComissaoOrganizacaoService.VerificarExistenciaDeIntegrantesPorInscricao(entity.IdInscricao))
                throw new BusinessException("Não é possível realizar a solicitação porque não existem integrantes para avaliar.");

            entity.DataSolicitacao = DateTime.Now;
            entity.SituacaoSolicitacao = SituacaoSolicitacaoIsencaoInscricaoEnum.EmAnalise;
        }
    }
}