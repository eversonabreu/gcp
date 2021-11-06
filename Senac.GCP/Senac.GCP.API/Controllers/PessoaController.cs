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
        private readonly IPessoaService pessoaService;

        public PessoaController(IPessoaService pessoaService) : base(pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        [HttpPut]
        [Route("alterar-chave-acesso/{idPessoa:long}/{chaveAcessoAtual}/{novaChaveAcesso}")]
        public void AlterarChaveAcesso(long idPessoa, string chaveAcessoAtual, string novaChaveAcesso)
            => pessoaService.AlterarChaveAcesso(idPessoa, chaveAcessoAtual, novaChaveAcesso);

        [HttpPut]
        [Route("resetar-chave-acesso/{idPessoa:long}")]
        public void ResetarChaveAcesso(long idPessoa)
            => pessoaService.ResetarChaveAcesso(idPessoa);
    }
}
