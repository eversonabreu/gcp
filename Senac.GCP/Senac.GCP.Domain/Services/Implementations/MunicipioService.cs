using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class MunicipioService : Service<MunicipioEntity>, IMunicipioService
    {
        private readonly IMunicipioRepository municipioRepository;

        public MunicipioService(IMunicipioRepository municipioRepository, IHttpContextAccessor httpContextAccessor)
            : base (municipioRepository, httpContextAccessor)
        {
            this.municipioRepository = municipioRepository;
        }

        public void ValidarDuplicidadeCodigoIBGE(int codigoIBGE, long? idMunicipio = null)
        {
            var municipio = municipioRepository.FirstOrDefault(x => x.CodigoIBGE == codigoIBGE);
            if (municipio != null)
            {
                if (idMunicipio.HasValue)
                {
                    if (municipio.Id != idMunicipio.Value)
                    {
                        throw new System.Exception("Não é possível atualizar, pois este código IBGE já está sendo utilizado por outro registro.");
                    }
                }
                else
                {
                    throw new System.Exception("Não é possível inserir, pois este código IBGE já está sendo utilizado por outro registro.");
                }
            }
        }

    }
}
