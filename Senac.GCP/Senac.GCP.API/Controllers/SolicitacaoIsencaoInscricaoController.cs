using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("solicitacao-isencao-inscricao")]
    public sealed class SolicitacaoIsencaoInscricaoController
        : Controller<SolicitacaoIsencaoInscricaoModel, SolicitacaoIsencaoInscricaoEntity>
    {
        private readonly ISolicitacaoIsencaoInscricaoService solicitacaoIsencaoInscricaoService;

        public SolicitacaoIsencaoInscricaoController(
            ISolicitacaoIsencaoInscricaoService solicitacaoIsencaoInscricaoService)
            : base(solicitacaoIsencaoInscricaoService)
        {
            this.solicitacaoIsencaoInscricaoService = solicitacaoIsencaoInscricaoService;
        }

        [Route("responder-pedido-isencao")]
        [HttpPut]
        public void ResponderPedidoDeIsencao([FromBody] PedidoSolicitacaoIsencaoInscricaoDto pedidoSolicitacaoIsencaoInscricaoDto)
            => solicitacaoIsencaoInscricaoService.ResponderPedidoDeIsencao(pedidoSolicitacaoIsencaoInscricaoDto);
    }
}