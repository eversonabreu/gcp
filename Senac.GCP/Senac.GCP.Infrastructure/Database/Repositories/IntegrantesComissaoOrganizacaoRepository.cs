using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infrastructure.Database.Repositories.Base;

namespace Senac.GCP.Infrastructure.Database.Repositories
{
    public sealed class IntegrantesComissaoOrganizacaoRepository : Repository<Domain.Entities.IntegrantesComissaoOrganizacaoRepository>, IIntegrantesComissaoOrganizacaoRepository
    {
        public IntegrantesComissaoOrganizacaoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}