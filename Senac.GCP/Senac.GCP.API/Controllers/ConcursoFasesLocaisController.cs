using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concursofaseslocais")]
    public sealed class ConcursoFasesLocaisController : Controller<ConcursoFasesLocaisModel, ConcursoFasesLocaisEntity>
    {
        public ConcursoFasesLocaisController(IConcursoFasesLocaisService concursoFasesLocaisService) : base(concursoFasesLocaisService)
        {
        }
    }
}