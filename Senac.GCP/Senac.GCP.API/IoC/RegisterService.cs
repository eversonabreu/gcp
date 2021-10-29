using Microsoft.Extensions.DependencyInjection;
using Senac.GCP.Domain.Notifications;
using Senac.GCP.Domain.Services.Implementations;
using Senac.GCP.Domain.Services.Interfaces;
using Senac.GCP.Infraestructure.Notifications;

namespace Senac.GCP.API.IoC
{
    public static class RegisterService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IInstituicaoService, InstituicaoService>();
            services.AddScoped<IArquivoService, ArquivoService>();
        }
    }
}