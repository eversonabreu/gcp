using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class InstituicaoService : Service<InstituicaoEntity>, IInstituicaoService
    {
        private readonly IInstituicaoRepository instituicaoRepository;

        public InstituicaoService(IInstituicaoRepository instituicaoRepository, IHttpContextAccessor httpContextAccessor)
            : base (instituicaoRepository, httpContextAccessor)
        {
            this.instituicaoRepository = instituicaoRepository;
        }

        public void ValidarDuplicidadeCNPJ(string cnpj, long? idInstituicao = null)
        {
            var instituicao = instituicaoRepository.FirstOrDefault(x => x.CNPJ == cnpj);
            if (instituicao != null)
            {
                if (idInstituicao.HasValue)
                {
                    if (instituicao.Id != idInstituicao.Value)
                    {
                        throw new System.Exception("Não é possível atualizar, pois este CNPJ já está sendo utilizado por outro registro.");
                    }
                }
                else
                {
                    throw new System.Exception("Não é possível inserir, pois este CNPJ já está sendo utilizado por outro registro.");
                }
            }
        }
    }
}
