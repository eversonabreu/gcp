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
            services.AddTransient<IMunicipioRepository, MunicipioRepository>();
            services.AddTransient<IInstituicaoRepository, InstituicaoRepository>();
<<<<<<< HEAD
            services.AddTransient<IClassificacaoDoencaRepository, ClassificacaoDoencaRepository>();

=======
            services.AddTransient<IArquivoRepository, ArquivoRepository>();
>>>>>>> e3228b53c31f569a4b210918e54b0398807c5ac2
        }
    }
}
