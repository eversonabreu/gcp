using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Runtime.Serialization;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class InscricoesService : Service<InscricoesEntity>, IInscricoesService
    {
        private readonly IInscricoesRepository inscricoesRepository;
        public InscricoesService(IInscricoesRepository inscricoesRepository, IHttpContextAccessor httpContextAccessor)
            : base(inscricoesRepository, httpContextAccessor)
        {
            this.inscricoesRepository = inscricoesRepository;
        }

        public override void BeforePost(InscricoesEntity entity)
        {
            ValidarDuplicidadeInscricoes(entity.IdConcurso, entity.IdPessoa);
        }

        public override void BeforePut(InscricoesEntity entity)
        {
            ValidarDuplicidadeInscricoes(entity.IdConcurso, entity.IdPessoa, entity.Id);
        }

        private void ValidarDuplicidadeInscricoes(long idConcurso, long idPessoa, long? id = null)
        {
            var inscricoes = inscricoesRepository.SingleOrDefault(x => x.IdConcurso == idConcurso && x.IdPessoa == idPessoa);
            if (inscricoes != null)
            {
                if (id.HasValue)
                {
                    throw new Exception("Não é possível inserir porque este concurso com esta pessoa já está sendo utilizado em outro registro.");
                }
            }
        }
    }
}
