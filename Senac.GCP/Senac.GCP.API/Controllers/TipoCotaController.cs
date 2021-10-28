using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.API.Controllers
{
    [Route("tipo-cota")]
    public sealed class TipoCotaController : Controller<TipoCotaModel, TipoCotaEntity>
    {
        public TipoCotaController(ITipoCotaService tipoCotaService) : base(tipoCotaService)
        {
        }
    }
}