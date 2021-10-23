using Microsoft.Extensions.DependencyInjection;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infraestructure.Database.Repositories;

namespace Senac.GCP.API.IoC
{
    public static class RegisterRepository
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IEstadoRepository, EstadoRepository>();
        }
    }
}
