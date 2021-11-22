using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("documentos-solicitacao-isencao-inscricao")]
    public sealed class DocumentosSolicitacaoIsencaoInscricaoController : Controller<DocumentosSolicitacaoIsencaoInscricaoModel, DocumentosSolicitacaoIsencaoInscricaoEntity>
    {
        public DocumentosSolicitacaoIsencaoInscricaoController(IDocumentosSolicitacaoIsencaoInscricaoService documentosSolicitacaoIsencaoInscricaoService) : base(documentosSolicitacaoIsencaoInscricaoService)
        {
        }
    }
}