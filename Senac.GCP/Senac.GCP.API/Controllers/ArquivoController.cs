using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("arquivo")]
    public sealed class ArquivoController : Controller<ArquivoModel, ArquivoEntity>
    {
        public ArquivoController(IArquivoService arquivoService) : base(arquivoService)
        {
        }
    }
}