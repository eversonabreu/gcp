using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("pessoa-formacoes")]
    public sealed class PessoaFormacoesController : Controller<PessoaFormacoesModel, PessoaFormacoesEntity>
    {
        public PessoaFormacoesController(IPessoaFormacoesService pessoaFormacoesService) : base(pessoaFormacoesService)
        {
        }
    }
}