using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("pessoa")]
    public sealed class PessoaController : Controller<PessoaModel, PessoaEntity>
    {
        public PessoaController(IPessoaService pessoaService) : base(pessoaService)
        {

        }
    }
}