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
<<<<<<< HEAD
            services.AddScoped<IClassificacaoDoencaService, ClassificacaoDoencaService>();

=======
            services.AddScoped<IArquivoService, ArquivoService>();
>>>>>>> e3228b53c31f569a4b210918e54b0398807c5ac2
        }
    }
}
