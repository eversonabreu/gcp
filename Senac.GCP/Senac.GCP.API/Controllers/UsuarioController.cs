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
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService) : base (usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public override long Post([FromBody] UsuarioModel model)
        {
            string senhaAutomatica = Guid.NewGuid().ToString().Replace("-", string.Empty);
            model.Senha = senhaAutomatica.Encrypt();
            model.DataCadastramento = DateTime.Now;
            long id = base.Post(model);

            if (!usuarioService.EnviarEmailUsuarioParaConfirmacaoDeCadasatro(model.Nome, model.Email, senhaAutomatica))
            {
                Delete(id);
                throw new Exception("Não foi possível inserir este usuário porque ocorreu um problema no envio de e-mail de sua senha");
            }

            return id;
        }

        public override void Put([FromBody] UsuarioModel model)
        {
            var usuario = GetById(model.Id.Value);
            model.Senha = usuario.Senha;
            base.Put(model);
        }
    }
}
