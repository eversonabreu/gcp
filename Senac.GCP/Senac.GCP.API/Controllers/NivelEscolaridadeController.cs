using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("nivel-escolaridade")]
    public sealed class NivelEscolaridadeController : Controller<NivelEscolaridadeModel, NivelEscolaridadeEntity>
    {
        public NivelEscolaridadeController(INivelEscolaridadeService nivelEscolaridadeService) : base(nivelEscolaridadeService)
        {
        }
    }
}