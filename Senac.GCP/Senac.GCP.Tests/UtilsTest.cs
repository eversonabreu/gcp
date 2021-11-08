using Microsoft.AspNetCore.Http;
using Senac.GCP.API;
using Senac.GCP.Domain.Notifications;
using Senac.GCP.Domain.Utils;
using Senac.GCP.Infraestructure.Notifications;
using System;
using System.Text.Json;

namespace Senac.GCP.Tests
{
    public static class UtilsTest
    {
        public static IHttpContextAccessor GetHttpContextAccessor()
        {
            var token = new Token
            {
                IdUsuario = 1,
                NomeUsuario = "admin",
                Administrador = true,
                DataExpiracao = DateTime.Now.AddHours(12)
            };

            string jsonToken = JsonSerializer.Serialize(token);
            string encryptToken = jsonToken.Encrypt();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add("Authorization", $"Bearer {encryptToken}");
            var httpContextAccessor = new HttpContextAccessor { HttpContext = httpContext };
            return httpContextAccessor;
        }

        public static IEmailService GetEmailService() => new EmailService(null);
    }
}
