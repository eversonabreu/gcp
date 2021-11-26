using Microsoft.EntityFrameworkCore;
using Senac.GCP.Domain.Entities;

namespace Senac.GCP.Infrastructure.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        public DbSet<EstadoEntity> Estado { get; set; }

        public DbSet<MunicipioEntity> Municipio { get; set; }

        public DbSet<InstituicaoEntity> Instituicao { get; set; }

        public DbSet<ArquivoEntity> Arquivo { get; set; }

        public DbSet<ClassificacaoDoencaEntity> ClassificacaoDoenca { get; set; }

        public DbSet<NacionalidadeEntity> Nacionalidade { get; set; }

        public DbSet<ConcursoEntity> Concurso { get; set; }

        public DbSet<ConcursoFasesEntity> ConcursoFases { get; set; }

        public DbSet<ConcursoEditaisEntity> ConcursoEditais { get; set; }

        public DbSet<ConcursoTipoCotasEntity> ConcursoTipoCotas { get; set; }

        public DbSet<PessoaEntity> Pessoa { get; set; }

        public DbSet<CorRacaEntity> CorRaca { get; set; }

        public DbSet<TipoSolicitacaoIsencaoInscricaoEntity> TipoSolicitacaoIsencaoInscricao { get; set; }

        public DbSet<SolicitacaoIsencaoInscricaoEntity> SolicitacaoIsencaoInscricao { get; set; }

        public DbSet<InscricaoEntity> Inscricao { get; set; }

        public DbSet<ConcursoFasesLocaisEntity> ConcursoFasesLocais { get; set; }

        public DbSet<ConcursoFaseCargoEntity> ConcursoFaseCargo { get; set; }

        public DbSet<CargoEntity> Cargo { get; set; }

        public DbSet<ConcursoCargoEntity> ConcursoCargo { get; set; }

        public DbSet<PessoaFormacoesEntity> PessoaFormacoes { get; set; }

        public DbSet<CursoEntity> Curso { get; set; }

        public DbSet<ConcursoFasesLocaisSalaEntity> ConcursoFasesLocaisSala { get; set; }

        public DbSet<CargoFormacoesEntity> CargoFormacoes { get; set; }

        public DbSet<IntegrantesComissaoOrganizacaoRepository> IntegrantesComissaoOrganizacao { get; set; }

        public DbSet<ConcursoCargoCandidatoLocalEntity> ConcursoCargoCandidatoLocal { get; set; }

        public DbSet<DocumentosSolicitacaoIsencaoInscricaoEntity> DocumentosSolicitacaoIsencaoInscricao { get; set; }

        public DbSet<NivelEscolaridadeEntity> NivelEscolaridade { get; set; }
    }
}