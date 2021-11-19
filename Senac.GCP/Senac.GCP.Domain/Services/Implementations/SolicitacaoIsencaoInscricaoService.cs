using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Dtos;
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
        private readonly ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository;

        public SolicitacaoIsencaoInscricaoService(ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository,
            IHttpContextAccessor httpContextAccessor, 
            IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService
            )
            : base(solicitacaoIsencaoInscricaoRepository, httpContextAccessor)
        {
            this.integrantesComissaoOrganizacaoService = integrantesComissaoOrganizacaoService;
            this.solicitacaoIsencaoInscricaoRepository = solicitacaoIsencaoInscricaoRepository;
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

        public void ResponderPedidoDeIsencao(PedidoSolicitacaoIsencaoInscricaoDto pedidoSolicitacaoIsencaoInscricaoDto)
        {
            var solicitacaoIsencaoInscricao = solicitacaoIsencaoInscricaoRepository.GetById(pedidoSolicitacaoIsencaoInscricaoDto.Id);
            solicitacaoIsencaoInscricao.DataRespostaSolicitacao = DateTime.Now;
            solicitacaoIsencaoInscricao.SituacaoSolicitacao = pedidoSolicitacaoIsencaoInscricaoDto.Aprovado
                ? SituacaoSolicitacaoIsencaoInscricaoEnum.Aprovado
                : SituacaoSolicitacaoIsencaoInscricaoEnum.Recusado;
            solicitacaoIsencaoInscricao.MotivoRecusaSolicitacaoIsensaoInscricao = pedidoSolicitacaoIsencaoInscricaoDto.Aprovado
                ? null
                : pedidoSolicitacaoIsencaoInscricaoDto.MotivoReprovacao;

            solicitacaoIsencaoInscricaoRepository.Update(solicitacaoIsencaoInscricao);

            if (pedidoSolicitacaoIsencaoInscricaoDto.Aprovado)
                EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoAprovada(pedidoSolicitacaoIsencaoInscricaoDto.IdPessoa,
                    pedidoSolicitacaoIsencaoInscricaoDto.IdInscricao);
            else
                EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoReprovada(pedidoSolicitacaoIsencaoInscricaoDto.IdPessoa,
                    pedidoSolicitacaoIsencaoInscricaoDto.IdInscricao, pedidoSolicitacaoIsencaoInscricaoDto.MotivoReprovacao);
        }

        private void EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoAprovada(long idPessoa, long idInscricao)
        {

        }

        private void EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoReprovada(long idPessoa, long idInscricao, string motivoReprovacao)
        {

        }
    }
}