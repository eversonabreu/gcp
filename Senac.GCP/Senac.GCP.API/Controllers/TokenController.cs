using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Services.Interfaces;
using Senac.GCP.Domain.Utils;
using System;
using System.Text.Json;

namespace Senac.GCP.API.Controllers
{
    [Route("token")]
    public sealed class TokenController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public TokenController(IUsuarioService usuarioService) => this.usuarioService = usuarioService;

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public string Login([FromBody] LoginModel loginModel)
        {
            var usuario = usuarioService.GetRepository().SingleOrDefault(item => item.Email == loginModel.Email.ToUpper() && item.Ativo);

            if (usuario != null && usuario.Senha == loginModel.Senha.Encrypt())
            {
                var token = new Token
                {
                    IdUsuario = usuario.Id,
                    NomeUsuario = usuario.Nome,
                    Administrador = usuario.Administrador,
                    DataExpiracao = DateTime.Now.AddHours(12)
                };

                string jsonToken = JsonSerializer.Serialize(token);
                string encryptToken = jsonToken.Encrypt();
                return encryptToken;
            }

            return null;
        }
    }
}