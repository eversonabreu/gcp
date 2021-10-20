using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;
using Senac.GCP.Domain.Utils;
using System;

namespace Senac.GCP.API.Controllers
{
    [Route("usuario")]
    public sealed class UsuarioController : Controller<UsuarioModel, UsuarioEntity>
    {
        public UsuarioController(IUsuarioService usuarioService) : base (usuarioService)
        {
        }

        public override long Post([FromBody] UsuarioModel model)
        {
            string senhaAutomatica = Guid.NewGuid().ToString().Replace("-", string.Empty);
            model.Senha = senhaAutomatica.Encrypt();
            model.DataCadastramento = DateTime.Now;
            return base.Post(model);
        }
    }
}
