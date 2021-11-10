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
            services.AddTransient<IClassificacaoDoencaRepository, ClassificacaoDoencaRepository>();
            services.AddTransient<IArquivoRepository, ArquivoRepository>();
            services.AddTransient<ITipoCotaRepository, TipoCotaRepository>();
            services.AddTransient<INacionalidadeRepository, NacionalidadeRepository>();
            services.AddTransient<IConcursoRepository, ConcursoRepository>();
            services.AddTransient<IConcursoFasesRepository, ConcursoFasesRepository>();
            services.AddTransient<IConcursoEditaisRepository, ConcursoEditaisRepository>();
            services.AddTransient<IConcursoTipoCotasRepository, ConcursoTipoCotasRepository>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<ICorRacaRepository, CorRacaRepository>();
            services.AddTransient<ITipoSolicitacaoIsencaoInscricaoRepository, TipoSolicitacaoIsencaoInscricaoRepository>();
            services.AddTransient<ISolicitacaoIsencaoInscricaoRepository, SolicitacaoIsencaoInscricaoRepository>();
            services.AddTransient<IInscricaoRepository, InscricaoRepository>();
            services.AddTransient<IDocumentosSolicitacaoIsencaoInscricaoRepository, DocumentosSolicitacaoIsencaoInscricaoRepository>();
            services.AddTransient<IInscricaoRepository, InscricaoRepository>();
            services.AddTransient<IConcursoFasesLocaisRepository, ConcursoFasesLocaisRepository>();
            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<IConcursoCargoRepository, ConcursoCargoRepository>();
            services.AddTransient<ITipoSolicitacaoIsencaoInscricaoRepository, TipoSolicitacaoIsencaoInscricaoRepository>();

        }
    } 
}