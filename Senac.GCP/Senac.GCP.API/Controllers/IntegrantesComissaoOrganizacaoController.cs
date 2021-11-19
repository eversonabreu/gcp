using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Implementations;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("integrantes-comissao-organizacao")]
    public sealed class IntegrantesComissaoOrganizacaoController : Controller<IntegrantesComissaoOrganizacaoModel, IntegrantesComissaoOrganizacaoRepository>
    {
        private readonly IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService;
        public IntegrantesComissaoOrganizacaoController(IIntegrantesComissaoOrganizacaoService integrantesComissaoOrganizacaoService) : base(integrantesComissaoOrganizacaoService)
        {
            this.integrantesComissaoOrganizacaoService = integrantesComissaoOrganizacaoService;
        }

        [HttpGet]
        [Route("verificar-integrantes")]
        public bool VerificarExistenciaIntegrantes(long idConcurso)
            => integrantesComissaoOrganizacaoService.VerificarExistenciaIntegrantes(idConcurso);
    }
}