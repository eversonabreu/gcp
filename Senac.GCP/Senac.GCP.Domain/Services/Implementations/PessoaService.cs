using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class PessoaService : Service<PessoaEntity>, IPessoaService
    {
        public PessoaService(IPessoaRepository pessoaRepository, IHttpContextAccessor httpContextAccessor)
            : base(pessoaRepository, httpContextAccessor)
        {
        }

        private static string GerarChaveAcesso()
        {
            var colunasChaveAcesso = Guid.NewGuid().ToString().Split('-');
            string chaveAcesso = $"{colunasChaveAcesso.First()}{colunasChaveAcesso.Last()}";
            return chaveAcesso;
        }

        public override void BeforePost(PessoaEntity entity)
        {
            entity.ChaveAcesso = GerarChaveAcesso();
            //tua tarefa....
            //ver como foi implementado no usuário...
            //e enviar e-mail para a pessoa com a sua chave....

            //tbm criar método para alteração de chave de acesso
            //tbm criar método reset desta chave
        }
    }
}