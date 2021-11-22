using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Notifications;
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
        private readonly IInscricaoService inscricaoService;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IInscricaoRepository inscricaoRepository;
        private readonly IEmailService emailService;
        private readonly IConcursoRepository concursoRepository;

        public SolicitacaoIsencaoInscricaoService(ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService,
            IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService,
            IInscricaoService inscricaoService,
            IPessoaRepository pessoaRepository,
            IInscricaoRepository inscricaoRepository,
            IConcursoRepository concursoRepository)
            : base(solicitacaoIsencaoInscricaoRepository, httpContextAccessor)
        {
            this.pessoaRepository = pessoaRepository;
            this.solicitacaoIsencaoInscricaoRepository = solicitacaoIsencaoInscricaoRepository;
            this.integrantesComissaoOrganizacaoService = integrantesComissaoOrganizacaoService;
            this.inscricaoService = inscricaoService;
            this.inscricaoRepository = inscricaoRepository;
            this.emailService = emailService;
            this.concursoRepository = concursoRepository;
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
            {
                if (inscricaoService.ObterValorPagamento(pedidoSolicitacaoIsencaoInscricaoDto.IdInscricao).InscricaoIsenta)
                    inscricaoService.IsentarValorDeInscricao(pedidoSolicitacaoIsencaoInscricaoDto.IdInscricao);

                EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoAprovada(pedidoSolicitacaoIsencaoInscricaoDto.IdPessoa,
                    pedidoSolicitacaoIsencaoInscricaoDto.IdInscricao);
            }
            else
            {
                EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoReprovada(pedidoSolicitacaoIsencaoInscricaoDto.IdPessoa,
                    pedidoSolicitacaoIsencaoInscricaoDto.IdInscricao, pedidoSolicitacaoIsencaoInscricaoDto.MotivoReprovacao);
            }
        }

        private void EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoAprovada(long idPessoa, long idInscricao)
        {
            var pessoa = pessoaRepository.GetByIdWithDependencies(idPessoa);
            var inscricao = inscricaoRepository.GetByIdWithDependencies(idInscricao);
            var concurso = concursoRepository.ObterConcursoPorInscricao(idInscricao);

            var envioEmail = emailService
                             .WithTitle("GCP - Pedido de Solicitação de Isenção Aprovado")
                             .WithBody(@$"<h4>Prezado(a): <b>{pessoa.Nome}</b>, seu pedido de solicitação 
                                          de isenção da inscrição {inscricao.NumeroInscricao}, do concurso: {concurso.Numero},
                                          foi <b>APROVADO</b>.</h4><br>", true)
                             .WithRecipient(pessoa.Email)
                             .Send();
            if (!envioEmail)
            {
                throw new SendEmailException("Não foi possível enviar o e-mail.");
            }
        }

        private void EnviarNotificacaoPedidoDeSolicitacaoDeIsencaoReprovada(long idPessoa, long idInscricao, string motivoReprovacao)
        {
            var pessoa = pessoaRepository.GetByIdWithDependencies(idPessoa);
            var inscricao = inscricaoRepository.GetByIdWithDependencies(idInscricao);
            var concurso = concursoRepository.ObterConcursoPorInscricao(idInscricao);

            var envioEmail = emailService
                             .WithTitle("GCP - Pedido de Solicitação de Isenção Reprovado")
                             .WithBody(@$"<h4>Prezado(a): <b>{pessoa.Nome}</b>, seu pedido de solicitação 
                                          de isenção da inscrição {inscricao.NumeroInscricao}, do concurso {concurso.Numero},
                                          infelizmente foi <b>Reprovado</b> pelo motivo de: {motivoReprovacao}.</h4><br>", true)
                             .WithRecipient(pessoa.Email)
                             .Send();
            if (!envioEmail)
            {
                throw new SendEmailException("Não foi possível enviar o e-mail.");
            }
        }
    }
}