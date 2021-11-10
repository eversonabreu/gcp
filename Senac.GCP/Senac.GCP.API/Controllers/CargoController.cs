using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("cargo")]
    public sealed class CargoController : Controller<CargoModel, CargoEntity>
    {
        public CargoController(ICargoService CargoService) : base(CargoService)
        {

        }
    }
}