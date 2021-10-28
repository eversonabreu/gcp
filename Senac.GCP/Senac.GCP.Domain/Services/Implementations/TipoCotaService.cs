using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class TipoCotaService : Service<TipoCotaEntity>, ITipoCotaService
    {
        private readonly ITipoCotaRepository tipoCotaRepository;

        public TipoCotaService(ITipoCotaRepository tipoCotaRepository, IHttpContextAccessor httpContextAccessor)
            : base (tipoCotaRepository, httpContextAccessor)
        {
            this.tipoCotaRepository = tipoCotaRepository;
        }

        public void ValidarDuplicidadeCodigo(string codigo, long? id = null)
        {
            var tipoCota = tipoCotaRepository.FirstOrDefault(x => x.Codigo == codigo);
            if (tipoCota != null)
            {
                if (id.HasValue)
                {
                    if (tipoCota.Id != id.Value)
                    {
                        throw new System.Exception("Não é possível atualizar, pois este Codigo já está sendo utilizado por outro registro.");
                    }
                }
                else
                {
                    throw new System.Exception("Não é possível inserir, pois este Codigo já está sendo utilizado por outro registro.");
                }
            }
        }
    }
}
