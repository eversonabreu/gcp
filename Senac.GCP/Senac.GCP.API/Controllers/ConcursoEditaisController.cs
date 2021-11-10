using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concurso-editais")]
    public sealed class ConcursoEditaisController : Controller<ConcursoEditaisModel, ConcursoEditaisEntity>
    {
        public ConcursoEditaisController(IConcursoEditaisService concursoEditaisService) : base(concursoEditaisService)
        {
        }
    }
}