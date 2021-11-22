using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Notifications;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class IntegrantesComissaoOrganizacaoService : Service<IntegrantesComissaoOrganizacaoRepository>, IIntegrantesComissaoOrganizacaoService
    {
        private readonly IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository;
        private readonly IInscricaoRepository inscricaoRepository;
        private readonly IEmailService emailService;
        private readonly IUsuarioRepository usuarioRepository;

        public IntegrantesComissaoOrganizacaoService(IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository,
            IInscricaoRepository inscricaoRepository,
            IEmailService emailService,
            IUsuarioRepository usuarioRepository,
            IHttpContextAccessor httpContextAccessor)
            : base(integrantesComissaoOrganizacaoRepository, httpContextAccessor)
        {
            this.integrantesComissaoOrganizacaoRepository = integrantesComissaoOrganizacaoRepository;
            this.inscricaoRepository = inscricaoRepository;
            this.emailService = emailService;
            this.usuarioRepository = usuarioRepository;

        }
        public IEnumerable<IntegrantesComissaoOrganizacaoRepository> Teste(long idInscricao)
        {
            var concursoCargo = inscricaoRepository.GetByIdWithDependencies(idInscricao).ConcursoCargo;
            return integrantesComissaoOrganizacaoRepository.Filter(x => x.IdConcurso == concursoCargo.IdConcurso);
        }

        public bool VerificarExistenciaDeIntegrantesPorInscricao(long idInscricao) => Teste(idInscricao).Any();

        public void EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencao(long idInscricao)
        {
            var teste = Teste(idInscricao).ToList();
            var inscritos = inscricaoRepository.GetById(idInscricao);


            foreach (var x in teste)
            {
                var integrantes = usuarioRepository.GetById(x.IdUsuario);

                emailService
                             .WithTitle("GCP - Avaliação da solicitação para isenção do valor da inscrição")
                             .WithBody(@$"<h4>Prezado(a): <b>{integrantes.Nome}</b>, o inscrito(a): <b>{inscritos.Pessoa.Nome}</b> solicitou uma isenção 
                              para a inscrição de número: <b>{inscritos.NumeroInscricao}, do concurso: <b>{inscritos.ConcursoCargo.IdConcurso}</b> . favor avaliar os documentos 
                              anexados pelo mesmo. </b></b>.</h4><br/>", true)
                             .WithRecipient(integrantes.Email)
                             .Send();
            }
        }
    }
}