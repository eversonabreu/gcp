using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concurso-cargo-candidato-local")]
    public sealed class ConcursoCargoCandidatoLocalController : Controller<ConcursoCargoCandidatoLocalModel, ConcursoCargoCandidatoLocalEntity>
    {
        private readonly IConcursoCargoCandidatoLocalService concursoCargoCandidatoLocalService;

        public ConcursoCargoCandidatoLocalController(IConcursoCargoCandidatoLocalService concursoCargoCandidatoLocalService) 
            : base(concursoCargoCandidatoLocalService)
        {
            this.concursoCargoCandidatoLocalService = concursoCargoCandidatoLocalService;
        }

        [HttpPut, Route("selecionar-local-fase/{idInscricao:long}/{idConcursoFasesLocais:long}")]
        public void SelecionarLocalFase(long idInscricao, long idConcursoFasesLocais)
            => concursoCargoCandidatoLocalService.SelecionarLocalFase(idInscricao, idConcursoFasesLocais);
    }
}