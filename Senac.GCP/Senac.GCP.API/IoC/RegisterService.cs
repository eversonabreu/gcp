using Microsoft.Extensions.DependencyInjection;
using Senac.GCP.Domain.Services.Implementations;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.IoC
{
    public static class RegisterService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
