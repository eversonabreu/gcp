using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("curso")]
    public sealed class CursoController : Controller<CursoModel, CursoEntity>
    {
        public CursoController(ICursoService CursoService) : base(CursoService)
        {

        }
    }
}