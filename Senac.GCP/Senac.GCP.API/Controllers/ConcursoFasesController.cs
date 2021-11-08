using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concursofases")]
    public sealed class ConcursoFasesController : Controller<ConcursoFasesModel, ConcursoFasesEntity>
    {
        public ConcursoFasesController(IConcursoFasesService concursoFasesService) : base(concursoFasesService)
        {
        }
    }
}