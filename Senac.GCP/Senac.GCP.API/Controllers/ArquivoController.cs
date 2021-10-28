using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.API.Controllers
{
    [Route("arquivo")]
    public sealed class ArquivoController : Controller<ArquivoModel, ArquivoEntity>
    {
        public ArquivoController(IArquivoService arquivoService) : base(arquivoService)
        {
        }

        public override long Post([FromBody] ArquivoModel model)
        {
            if (model != null)
                model.DataUpload = DateTime.Now;
            return base.Post(model);
        }

        public override void Put([FromBody] ArquivoModel model)
        {
            if (model != null)
                model.DataUpload = GetById(model.Id.Value).DataUpload;
            base.Put(model);
        }
    }
}