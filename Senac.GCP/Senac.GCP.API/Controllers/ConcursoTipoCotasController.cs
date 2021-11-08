using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concurso-tipo-cotas")]
    public sealed class ConcursoTipoCotasController : Controller<ConcursoTipoCotasModel, ConcursoTipoCotasEntity>
    {
        public ConcursoTipoCotasController(IConcursoTipoCotasService concursoTipoCotasService) : base(concursoTipoCotasService)
        {
        }
    }
}