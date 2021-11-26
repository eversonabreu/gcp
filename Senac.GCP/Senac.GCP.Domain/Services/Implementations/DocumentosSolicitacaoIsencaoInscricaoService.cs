using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class DocumentosSolicitacaoIsencaoInscricaoService : Service<DocumentosSolicitacaoIsencaoInscricaoEntity>, IDocumentosSolicitacaoIsencaoInscricaoService
    {
        private readonly ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository;
        private readonly IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService;

        public DocumentosSolicitacaoIsencaoInscricaoService(IDocumentosSolicitacaoIsencaoInscricaoRepository documentosSolicitacaoIsencaoInscricaoRepository, 
            ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository,
            IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService,
            IHttpContextAccessor httpContextAccessor)
            : base(documentosSolicitacaoIsencaoInscricaoRepository, httpContextAccessor)
        {
            this.solicitacaoIsencaoInscricaoRepository = solicitacaoIsencaoInscricaoRepository;
            this.integrantesComissaoOrganizacaoService = integrantesComissaoOrganizacaoService;
        }

        public override void BeforePost(DocumentosSolicitacaoIsencaoInscricaoEntity entity)
        {
            var solicitacaoIsencao = solicitacaoIsencaoInscricaoRepository.GetByIdWithDependencies(entity.IdSolicitacaoIsencaoInscricao);
            if (solicitacaoIsencao.Inscricao.Situacao != SituacaoInscricaoEnum.AguardandoPagamento && 
                solicitacaoIsencao.SituacaoSolicitacao != SituacaoSolicitacaoIsencaoInscricaoEnum.EmAnalise)
                throw new BusinessException(@"Não é possível anexar documentos porque não existe uma solicitação de isenção de inscrição
                                            pendente ou porque a inscrição do concurso já foi concluída.");
        }

        public override void AfterPost(DocumentosSolicitacaoIsencaoInscricaoEntity entity)
        {
            var repository = GetRepository();
            long idInscricao = repository.GetByIdWithDependencies(entity.Id).SolicitacaoIsencaoInscricao.IdInscricao;
            if (repository.Filter(x => x.IdSolicitacaoIsencaoInscricao == entity.IdSolicitacaoIsencaoInscricao).Count() == 1)
                integrantesComissaoOrganizacaoService.EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencao(idInscricao);
        }
    }
}