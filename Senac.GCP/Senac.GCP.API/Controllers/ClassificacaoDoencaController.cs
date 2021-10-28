using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("classificacaoDoenca")]
    public sealed class ClassificacaoDoencaController : Controller<ClassificacaoDoencaModel, ClassificacaoDoencaEntity>
    {
        private readonly IInstituicaoService instituicaoService;

        public ClassificacaoDoencaController(IClassificacaoDoencaService classificacaoDoencaService) : base(classificacaoDoencaService)
        {

        }
    }
}