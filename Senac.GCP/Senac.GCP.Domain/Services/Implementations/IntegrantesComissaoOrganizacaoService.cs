using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class IntegrantesComissaoOrganizacaoService : Service<IntegrantesComissaoOrganizacaoEntity>, IIntegrantesComissaoOrganizacaoService
    {
        private readonly IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository;

        public IntegrantesComissaoOrganizacaoService(IIntegrantesComissaoOrganizacaoRepository integrantesComissaoOrganizacaoRepository, IHttpContextAccessor httpContextAccessor)
            : base(integrantesComissaoOrganizacaoRepository, httpContextAccessor)
        {
<<<<<<< HEAD

=======
            this.integrantesComissaoOrganizacaoRepository = integrantesComissaoOrganizacaoRepository;
>>>>>>> aac83f7870f99183bed08f4d03e112d8f75d973b
        }

        public bool VerificarExistenciaIntegrantes(long idConcurso)
        {
            var integrantes = integrantesComissaoOrganizacaoRepository.Filter(x => x.IdConcurso == idConcurso).ToList().Count();
            if (integrantes>0) return true;
            else return false;
        }

    }
}