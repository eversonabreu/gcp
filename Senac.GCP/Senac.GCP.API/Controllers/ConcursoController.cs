using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concurso")]
    public sealed class ConcursoController : Controller<ConcursoModel, ConcursoEntity>
    {
        public ConcursoController(IConcursoService concursoService) : base(concursoService)
        {
        }
    }
}