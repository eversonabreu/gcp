using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{

    [Route("inscricao")]
    public sealed class InscricaoController : Controller<InscricaoModel, InscricaoEntity>
    {
        private readonly IInscricaoService inscricaoService;

        public InscricaoController(IInscricaoService inscricaoService) : base(inscricaoService)
        {
            this.inscricaoService = inscricaoService;
        }

        [Route("obter-valor-pagamento/{idInscricao:long}")]
        [HttpGet]
        public ValorPagamentoInscricaoDto ObterValorPagamento(long idInscricao)
            => inscricaoService.ObterValorPagamento(idInscricao);

        [Route("efetuar-pagamento/{idInscricao:long}/{tipoPagamento:int}")]
        [HttpPut]
        public void EfetuarPagamento(long idInscricao, int tipoPagamento)
            => inscricaoService.EfetuarPagamento(idInscricao, tipoPagamento);
    }
}