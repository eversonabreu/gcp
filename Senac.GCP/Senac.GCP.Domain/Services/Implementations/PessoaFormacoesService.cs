using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class PessoaFormacoesService : Service<PessoaFormacoesEntity>, IPessoaFormacoesService
    {
        public PessoaFormacoesService(IPessoaFormacoesRepository pessoaFormacoesRepository, IHttpContextAccessor httpContextAccessor)
            : base(pessoaFormacoesRepository, httpContextAccessor)
        {
        }
    }
}