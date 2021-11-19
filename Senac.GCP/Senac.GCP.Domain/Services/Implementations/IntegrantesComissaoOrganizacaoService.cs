using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class IntegrantesComissaoOrganizacaoService : Service<IntegrantesComissaoOrganizacaoEntity>, IIntegrantesComissaoOrganizacaoService
    {
        public IntegrantesComissaoOrganizacaoService(IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository, IHttpContextAccessor httpContextAccessor)
            : base(integrantesComissaoOrganizacaoRepository, httpContextAccessor)
        {

        }
    }
}