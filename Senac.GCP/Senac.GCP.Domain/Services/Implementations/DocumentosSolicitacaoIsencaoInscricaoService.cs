using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class DocumentosSolicitacaoIsencaoInscricaoService : Service<DocumentosSolicitacaoIsencaoInscricaoEntity>, IDocumentosSolicitacaoIsencaoInscricaoService
    {
        private readonly IDocumentosSolicitacaoIsencaoInscricaoRepository documentosSolicitacaoIsencaoInscricaoRepository;
        private readonly ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository;
        private readonly IArquivoRepository arquivoRepository;
        private readonly IArquivoService arquivoService;
        private readonly IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService;
        private readonly IInscricaoRepository inscricaoRepository;

        public DocumentosSolicitacaoIsencaoInscricaoService(IDocumentosSolicitacaoIsencaoInscricaoRepository documentosSolicitacaoIsencaoInscricaoRepository, 
            ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository,
            IArquivoRepository arquivoRepository,
            IArquivoService arquivoService,
            IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService,
            IInscricaoRepository inscricaoRepository,
            IHttpContextAccessor httpContextAccessor)
            : base(documentosSolicitacaoIsencaoInscricaoRepository, httpContextAccessor)
        {
            this.documentosSolicitacaoIsencaoInscricaoRepository = documentosSolicitacaoIsencaoInscricaoRepository;
            this.solicitacaoIsencaoInscricaoRepository = solicitacaoIsencaoInscricaoRepository;
            this.arquivoRepository = arquivoRepository;
            this.arquivoService = arquivoService;
            this.integrantesComissaoOrganizacaoService = integrantesComissaoOrganizacaoService;
            this.inscricaoRepository = inscricaoRepository;
        }

        public override void BeforePost(DocumentosSolicitacaoIsencaoInscricaoEntity entity)
        {
            var inscrito = solicitacaoIsencaoInscricaoRepository.GetByIdWithDependencies(entity.IdSolicitacaoIsencaoInscricao).IdInscricao;

            if (arquivoRepository.ObterDocumentos(entity.IdSolicitacaoIsencaoInscricao) == true)
                   throw new BusinessException($"Você já anexou documento(s) para o pedido de solicitação de isenção de inscrição.");

            if (entity.SolicitacaoIsencaoInscricao.SituacaoSolicitacao == SituacaoSolicitacaoIsencaoInscricaoEnum.EmAnalise)
            {
                integrantesComissaoOrganizacaoService.EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencaoAsync(inscrito);
            }

            else
                throw new BusinessException("Só é permitido inserir documentos enquanto a situação da solicitação estiver em análise.");
        }

    }
}