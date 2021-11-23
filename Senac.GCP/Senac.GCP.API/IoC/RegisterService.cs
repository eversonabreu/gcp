using Microsoft.Extensions.DependencyInjection;
using Senac.GCP.Domain.Notifications;
using Senac.GCP.Domain.Services.Implementations;
using Senac.GCP.Domain.Services.Interfaces;
using Senac.GCP.Infrastructure.Notifications;

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
            services.AddScoped<IConcursoService, ConcursoService>();
            services.AddScoped<IConcursoFasesService, ConcursoFasesService>();
            services.AddScoped<IConcursoEditaisService, ConcursoEditaisService>();
            services.AddScoped<IConcursoTipoCotasService, ConcursoTipoCotasService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IInscricaoService, InscricaoService>();
            services.AddScoped<IConcursoFasesLocaisService, ConcursoFasesLocaisService>();
            services.AddScoped<IConcursoFaseCargoService, ConcursoFaseCargoService>();
            services.AddScoped<IConcursoFasesLocaisSalaService, ConcursoFasesLocaisSalaService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IConcursoCargoService, ConcursoCargoService>();
            services.AddScoped<IPessoaFormacoesService, PessoaFormacoesService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ITipoSolicitacaoIsencaoInscricaoService, TipoSolicitacaoIsencaoInscricaoService>();
            services.AddScoped<INivelEscolaridadeService, NivelEscolaridadeService>();
            services.AddScoped<ICargoFormacoesService, CargoFormacoesService>();
            services.AddScoped<IConcursoFaseCargoService, ConcursoFaseCargoService>();
            services.AddScoped<IIntegrantesComissaoOrganizacaoService, IntegrantesComissaoOrganizacaoService>();
            services.AddScoped<ISolicitacaoIsencaoInscricaoService, SolicitacaoIsencaoInscricaoService>();
            services.AddScoped<IConcursoCargoCandidatoLocalService, ConcursoCargoCandidatoLocalService>();
        }
    }
}