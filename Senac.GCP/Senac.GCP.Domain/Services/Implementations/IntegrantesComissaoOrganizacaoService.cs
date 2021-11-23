using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Notifications;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class IntegrantesComissaoOrganizacaoService : Service<IntegrantesComissaoOrganizacaoRepository>, IIntegrantesComissaoOrganizacaoService
    {
        private readonly IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository;
        private readonly IInscricaoRepository inscricaoRepository;
        private readonly IEmailService emailService;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IConcursoRepository concursoRepository;
        private readonly ITipoSolicitacaoIsencaoInscricaoRepository tipoSolicitacaoIsencaoInscricaoRepository;

        public IntegrantesComissaoOrganizacaoService(IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository,
            IInscricaoRepository inscricaoRepository,
            IEmailService emailService,
            IUsuarioRepository usuarioRepository,
            IConcursoRepository concursoRepository,
            ITipoSolicitacaoIsencaoInscricaoRepository tipoSolicitacaoIsencaoInscricaoRepository,
            IHttpContextAccessor httpContextAccessor)
            : base(integrantesComissaoOrganizacaoRepository, httpContextAccessor)
        {
            this.integrantesComissaoOrganizacaoRepository = integrantesComissaoOrganizacaoRepository;
            this.inscricaoRepository = inscricaoRepository;
            this.emailService = emailService;
            this.usuarioRepository = usuarioRepository;
            this.concursoRepository = concursoRepository;
            this.tipoSolicitacaoIsencaoInscricaoRepository = tipoSolicitacaoIsencaoInscricaoRepository;
        }

        private IEnumerable<IntegrantesComissaoOrganizacaoRepository> ObterIntegrantes(long idInscricao)
        {
            var concursoCargo = inscricaoRepository.GetByIdWithDependencies(idInscricao).ConcursoCargo;
            return integrantesComissaoOrganizacaoRepository.Filter(x => x.IdConcurso == concursoCargo.IdConcurso);
        }

        public bool VerificarExistenciaDeIntegrantesPorInscricao(long idInscricao) => ObterIntegrantes(idInscricao).Any();

        public async Task EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencaoAsync(long idInscricao)
        {
            var integrantes = ObterIntegrantes(idInscricao);
            var inscrito = inscricaoRepository.GetById(idInscricao);
            var porcentagemIsencao = tipoSolicitacaoIsencaoInscricaoRepository.ObterPercentualDeIsencaoPorInscricao(idInscricao);
            var concurso = concursoRepository.ObterConcursoPorInscricao(idInscricao);
            
            foreach (var item in integrantes)
            {
                var integrante = usuarioRepository.GetById(item.IdUsuario);

                await emailService.WithTitle("GCP - Avaliação da solicitação para isenção do valor da inscrição")
                                  .WithBody(@$"<h4>Prezado(a): <b>{integrante.Nome}</b>, foi solicitado por: <b>{inscrito.Pessoa.Nome}</b> com
                                   inscrição de número: <b>{inscrito.NumeroInscricao}</b>, em <b>{inscrito.DataInscricao}, a isenção do valor 
                                   da inscrição para o concurso de número <b>{concurso.Numero}</b>. O tipo de solicitação de isenção escolhido, 
                                   refere-se à <b>{porcentagemIsencao}</b> do valor total da inscrição. Favor avaliar os documento(s) informados pela pessoa.</h4><br/>", true)
                                  .WithRecipient(integrante.Email)
                                  .SendAsync();
            }
        }
    }
}