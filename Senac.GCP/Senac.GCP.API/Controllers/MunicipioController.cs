using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("municipio")]
    public sealed class MunicipioController : Controller<MunicipioModel, MunicipioEntity>
    {
        private readonly IMunicipioService municipioService;

        public MunicipioController(IMunicipioService municipioService) : base(municipioService)
        {
            this.municipioService = municipioService;
        }

        public override long Post([FromBody] MunicipioModel model)
        {
            (model as Model).Validate();
            municipioService.ValidarDuplicidadeCodigoIBGE(model.CodigoIBGE);
            return base.Post(model);
        }

        public override void Put([FromBody] MunicipioModel model)
        {
            (model as Model).Validate(true);
            municipioService.ValidarDuplicidadeCodigoIBGE(model.CodigoIBGE, model.Id);
            base.Put(model);
        }
    }
}