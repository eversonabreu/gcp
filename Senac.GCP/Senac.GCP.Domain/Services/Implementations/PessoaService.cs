using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
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
        private readonly INacionalidadeRepository nacionalidadeRepository;

        public PessoaService(IPessoaRepository pessoaRepository, IHttpContextAccessor httpContextAccessor, IEmailService emailService, INacionalidadeRepository nacionalidadeRepository)
            : base(pessoaRepository, httpContextAccessor)
        {
            this.emailService = emailService;
            this.pessoaRepository = pessoaRepository;
            this.nacionalidadeRepository = nacionalidadeRepository;
        }


        public override void BeforePost(PessoaEntity entity)
        {
            ValidarNaturalidade(entity);
            entity.ChaveAcesso = GerarChaveAcesso();
        }

        public override void BeforePut(PessoaEntity entity)
        {
            ValidarNaturalidade(entity);
        }

        public override void AfterPost(PessoaEntity entity)
        {
            if (!EnviarEmailUsuarioComChaveDeAcesso(entity))
            {
                pessoaRepository.DeleteById(entity.Id);
                    throw new SendEmailException("Não foi possível inserir esta pessoa porque ocorreu um problema no envio de e-mail de sua senha");
            }
        }

        private static string GerarChaveAcesso()
        {
            var colunasChaveAcesso = Guid.NewGuid().ToString().Split('-');
            string chaveAcesso = $"{colunasChaveAcesso.First()}{colunasChaveAcesso.Last()}";
            return chaveAcesso;
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
                throw new SendEmailException(@"Não foi possível resetar a chave de acesso porque ocorreu um problema no
                     envio de e-mail da chave de acesso para a pessoa");

            pessoaRepository.Update(pessoa);
        }

        public void AlterarChaveAcesso(long idPessoa, string chaveAcessoAtual, string novaChaveAcesso)
        {
            var pessoa = pessoaRepository.GetById(idPessoa);
            if (pessoa.ChaveAcesso != chaveAcessoAtual)
                throw new BusinessException("A chave de acesso atual não corresponde com a chave de acesso informada.");

            ValidarChaveAcesso(novaChaveAcesso);
            pessoa.ChaveAcesso = novaChaveAcesso;
            pessoaRepository.Update(pessoa);
        }

        private void ValidarNaturalidade(PessoaEntity pessoaEntity)
        {
            var nacionalidade = nacionalidadeRepository.GetById(pessoaEntity.IdNacionalidade);
            if (nacionalidade.Nome.ToUpper().Contains("BRASILEIRO(A)"))
            {
                if (pessoaEntity.IdMunicipioNaturalidade is null)
                    throw new BusinessException("O município de naturalidade deve ser informado obrigatóriamente quando a nacionalidade informada for 'Brasileiro(a)'.");
            }
            else
            {
                pessoaEntity.IdMunicipioNaturalidade = null;
            }
        }

        private static void ValidarChaveAcesso(string chaveAcesso)
        {
            const string chaveAcessoInvalido = "A chave de acesso informada é inválida. É necessário ter no mínimo 6 caracteres, contendo no mínimo uma letra e um número.";
            if (string.IsNullOrEmpty(chaveAcesso) || chaveAcesso.Length < 6)
                throw new BusinessException(chaveAcessoInvalido);

            int contadorNumeros = 0;
            int contadorLetras = 0;

            foreach (char ch in chaveAcesso)
            {
                if (char.IsDigit(ch))
                    contadorNumeros++;
                else if (char.IsLetter(ch))
                    contadorLetras++;

                if (contadorNumeros > 0 && contadorLetras > 0)
                    break;
            }

            if (contadorNumeros == 0 || contadorLetras == 0)
                throw new BusinessException(chaveAcessoInvalido);
        }

        public void BloquearUsuario(PessoaBloqueioDto pessoaBloqueioDto)
        {
            var pessoa = pessoaRepository.GetById(pessoaBloqueioDto.IdPessoa);
            if (!pessoa.Bloqueado)
            {
                pessoa.Bloqueado = true;
                pessoa.MotivoBloqueio = pessoaBloqueioDto.MotivoBloqueio;
                pessoa.DataBloqueio = DateTime.Now;
                pessoaRepository.Update(pessoa);
            }
        }

        public void DesbloquearUsuario(PessoaBloqueioDto pessoaBloqueioDto)
        {
            var pessoa = pessoaRepository.GetById(pessoaBloqueioDto.IdPessoa);
            if (pessoa.Bloqueado)
            {
                pessoa.Bloqueado = false;
                pessoa.MotivoBloqueio = null;
                pessoa.DataBloqueio = null;
                pessoaRepository.Update(pessoa);
            }
        }
    }
}