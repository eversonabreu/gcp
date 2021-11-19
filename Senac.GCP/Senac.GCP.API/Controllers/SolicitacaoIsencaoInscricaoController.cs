using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("solicitacao-isencao-inscricao")]
    public sealed class SolicitacaoIsencaoInscricaoController 
        : Controller<SolicitacaoIsencaoInscricaoModel, SolicitacaoIsencaoInscricaoEntity>
    {
        public SolicitacaoIsencaoInscricaoController(
            ISolicitacaoIsencaoInscricaoService solicitacaoIsencaoInscricaoService) 
            : base(solicitacaoIsencaoInscricaoService)
        {
        }
    }
}