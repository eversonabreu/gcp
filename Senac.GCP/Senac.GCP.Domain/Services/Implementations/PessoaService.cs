using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Notifications;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class PessoaService : Service<PessoaEntity>, IPessoaService
    {
        private readonly IEmailService emailService;
        private readonly IPessoaRepository pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository, IHttpContextAccessor httpContextAccessor, IEmailService emailService)
            : base(pessoaRepository, httpContextAccessor)
        {
            this.emailService = emailService;
            this.pessoaRepository = pessoaRepository;
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
        }

        public override void AfterPost(PessoaEntity entity)
        {
            if (!EnviarEmailUsuarioComChaveDeAcesso(entity))
            {
                pessoaRepository.DeleteById(entity.Id);
                throw new Exception("Não foi possível inserir esta pessoa porque ocorreu um problema no envio de e-mail de sua senha");
            }
        }

        private bool EnviarEmailUsuarioComChaveDeAcesso(PessoaEntity entity)
        {
            string chaveAcesso = entity.ChaveAcesso;
            var envioEmail = emailService
                             .WithTitle("GCP - Recebimento da chave de acesso")
                             .WithBody(@$"<h4>Prezado(a): <b>{entity.Nome}</b>, bem-vindo(a) ao sistema GCP.</h4><br/>
                                         <h5>Esta é a sua chave de acesso (foi gerada automáticamente pelo sistema): {chaveAcesso}</h5><br/><br/>
                                         <h6><i>Caso queira voçê poderá alterar a sua senha pelo sistema</i></h6>", true)
                             .WithRecipient(entity.Email)
                             .Send();
            return envioEmail;
        }

        public void ResetarChaveAcesso(long idPessoa)
        {
            var pessoa = pessoaRepository.GetById(idPessoa);
            pessoa.ChaveAcesso = GerarChaveAcesso();
            if (!EnviarEmailUsuarioComChaveDeAcesso(pessoa))
                throw new Exception(@"Não foi possível resetar a chave de acesso porque ocorreu um problema no
                     envio de e-mail da chave de acesso para a pessoa");

            pessoaRepository.Update(pessoa);
        }

        public void AlterarChaveAcesso(long idPessoa, string chaveAcessoAtual, string novaChaveAcesso)
        {
            var pessoa = pessoaRepository.GetById(idPessoa);
            if (pessoa.ChaveAcesso != chaveAcessoAtual)
            {
                throw new Exception("A chave de acesso atual não corresponde com a chave de acesso informada.");
            }

            pessoa.ChaveAcesso = novaChaveAcesso;
            pessoaRepository.Update(pessoa);
        }

        //public bool ValidarChaveAcesso(string chaveAcesso)
        //{

        //}
    }
}