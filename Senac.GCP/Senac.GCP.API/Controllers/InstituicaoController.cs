using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("instituicao")]
    public sealed class InstituicaoController : Controller<InstituicaoModel, InstituicaoEntity>
    {
        private readonly IInstituicaoService instituicaoService;

        public InstituicaoController(IInstituicaoService instituicaoService) : base(instituicaoService)
        {
            this.instituicaoService = instituicaoService;
        }

        public override long Post([FromBody] InstituicaoModel instituicao)
        {
            (instituicao as Model).Validate();
            instituicaoService.ValidarDuplicidadeCNPJ(instituicao.CNPJ);
            return base.Post(instituicao);
        }

        public override void Put([FromBody] InstituicaoModel instituicao)
        {
            (instituicao as Model).Validate(true);
            instituicaoService.ValidarDuplicidadeCNPJ(instituicao.CNPJ, instituicao.Id);
            base.Put(instituicao);
        }
    }
}