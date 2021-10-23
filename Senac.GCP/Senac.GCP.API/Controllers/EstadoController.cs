using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("estado")]
    public sealed class EstadoController : Controller<EstadoModel, EstadoEntity>
    {
        public EstadoController(IEstadoService estadoService) : base(estadoService)
        {

        }
    }
}