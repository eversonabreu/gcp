using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoTipoCotasService : Service<ConcursoTipoCotasEntity>, IConcursoTipoCotasService
    {
        private readonly IConcursoTipoCotasRepository concursoTipoCotasRepository;

        public ConcursoTipoCotasService(IConcursoTipoCotasRepository concursoTipoCotasRepository, IHttpContextAccessor httpContextAccessor)
            : base(concursoTipoCotasRepository, httpContextAccessor)
        {
            this.concursoTipoCotasRepository = concursoTipoCotasRepository;
        }
 
        public override void BeforePost(ConcursoTipoCotasEntity entity)
        {
            ValidarDuplicidadeConcursoTipoCota(entity.IdConcurso, entity.IdTipoCota);
            int percentualVagas = 0;
            entity.PercentualVagas = percentualVagas;
        }

        public override void BeforePut(ConcursoTipoCotasEntity entity)
        {
            ValidarDuplicidadeConcursoTipoCota(entity.IdConcurso, entity.IdTipoCota, entity.Id);
        }

        private void ValidarDuplicidadeConcursoTipoCota(long idConcurso, long idTipoCota, long? id = null)
        {
            var concursoTipoCota = concursoTipoCotasRepository.SingleOrDefault(x => x.IdConcurso == idConcurso && x.IdTipoCota == idTipoCota);
            if (concursoTipoCota != null)
            {
                if (id.HasValue)
                {
                    if (concursoTipoCota.Id != id.Value)
                    {
                        throw new Exception("Não é possível atualizar porque este concurso com este tipo de cota já está sendo utilizado em outro registro.");
                    }
                }
                else
                {
                    throw new Exception("Não é possível inserir porque este concurso com este tipo de cota já está sendo utilizado em outro registro.");
                }
            }
        }
    }
}