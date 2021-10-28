using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("usuario")]
    public sealed class UsuarioController : Controller<UsuarioModel, UsuarioEntity>
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService) : base(usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPut]
        [Route("alterar-senha/{idUsuario:long}/{senhaAtual}/{novaSenha}")]
        public void AlterarSenha(long idUsuario, string senhaAtual, string novaSenha)
            => usuarioService.AlterarSenha(idUsuario, senhaAtual, novaSenha);
    }
}
