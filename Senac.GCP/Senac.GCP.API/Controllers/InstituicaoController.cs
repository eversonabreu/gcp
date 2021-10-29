using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("instituicao")]
    public sealed class InstituicaoController : Controller<InstituicaoModel, InstituicaoEntity>
    {
        public InstituicaoController(IInstituicaoService instituicaoService) : base(instituicaoService)
        {
        }
    }
}