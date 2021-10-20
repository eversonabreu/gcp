using Microsoft.Extensions.DependencyInjection;
using Senac.GCP.Domain.Services.Implementatios;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.IoC
{
    public static class RegisterService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
