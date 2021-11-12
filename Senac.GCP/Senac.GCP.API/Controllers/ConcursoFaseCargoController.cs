using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concurso-fase-cargo")]
    public sealed class ConcursoFaseCargoController : Controller<ConcursoFaseCargoModel, ConcursoFaseCargoEntity>
    {
        public ConcursoFaseCargoController(IConcursoFaseCargoService ConcursoFaseCargoService) : base(ConcursoFaseCargoService)
        {
        }
    }
}