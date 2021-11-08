using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.Domain.Entities;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    
    [Route("inscricao")]
    public sealed class InscricaoController : Controller<InscricaoModel, InscricaoEntity>
    {
        public InscricaoController(IInscricaoService inscricaoService) : base(inscricaoService)
        {
        }
    }
}