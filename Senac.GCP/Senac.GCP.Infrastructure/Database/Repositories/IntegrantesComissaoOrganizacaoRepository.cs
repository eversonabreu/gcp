using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infrastructure.Database.Repositories.Base;

namespace Senac.GCP.Infrastructure.Database.Repositories
{
    public sealed class IntegrantesComissaoOrganizacaoRepository : Repository<IntegrantesComissaoOrganizacaoEntity>, IIntegrantesComissaoOrganizacaoRepository
    {
        public IntegrantesComissaoOrganizacaoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}