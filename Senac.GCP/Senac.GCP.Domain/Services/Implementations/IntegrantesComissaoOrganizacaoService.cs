using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class IntegrantesComissaoOrganizacaoService : Service<IntegrantesComissaoOrganizacaoRepository>, IIntegrantesComissaoOrganizacaoService
    {
        private readonly IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository;

        public IntegrantesComissaoOrganizacaoService(IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository, IHttpContextAccessor httpContextAccessor)
            : base(integrantesComissaoOrganizacaoRepository, httpContextAccessor)
        {
            this.integrantesComissaoOrganizacaoRepository = integrantesComissaoOrganizacaoRepository;
        }



           
        }
}

