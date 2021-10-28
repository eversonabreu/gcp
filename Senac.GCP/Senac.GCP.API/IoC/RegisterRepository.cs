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
<<<<<<< HEAD
            services.AddTransient<ITipoCotaRepository, TipoCotaRepository>();
=======
>>>>>>> e3228b53c31f569a4b210918e54b0398807c5ac2
>>>>>>> 373731fcdf7baee8e4621d7c7eeac46761e68e31
        }
    }
}
