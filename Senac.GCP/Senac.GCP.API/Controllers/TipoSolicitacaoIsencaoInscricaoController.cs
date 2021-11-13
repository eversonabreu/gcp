using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("tipo-solicitacao-isencao-inscricao")]
    public sealed class TipoSolicitacaoIsencaoInscricaoController : Controller<TipoSolicitacaoIsencaoInscricaoModel, TipoSolicitacaoIsencaoInscricaoEntity>
    {
        public TipoSolicitacaoIsencaoInscricaoController(ITipoSolicitacaoIsencaoInscricaoService tipoSolicitacaoIsencaoInscricaoService) : base(tipoSolicitacaoIsencaoInscricaoService)
        {
        }
    }
}