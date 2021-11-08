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
        private readonly INacionalidadeRepository nacionalidadeRepository;

        public PessoaService(IPessoaRepository pessoaRepository, IHttpContextAccessor httpContextAccessor, IEmailService emailService, INacionalidadeRepository nacionalidadeRepository)
            : base(pessoaRepository, httpContextAccessor)
        {
            this.emailService = emailService;
            this.pessoaRepository = pessoaRepository;
            this.nacionalidadeRepository = nacionalidadeRepository;
        }

        private static string GerarChaveAcesso()
        {
            var colunasChaveAcesso = Guid.NewGuid().ToString().Split('-');
            string chaveAcesso = $"{colunasChaveAcesso.First()}{colunasChaveAcesso.Last()}";
            return chaveAcesso;
        }

        public override void BeforePost(PessoaEntity entity)
        {
            ValidarNacionalidadeBrasileira(entity.IdNacionalidade, entity.IdMunicipioNaturalidade);
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

            if(ValidarChaveAcesso(novaChaveAcesso) == false || novaChaveAcesso.Length < 6)
            {
                throw new Exception("A nova chave de acesso é inválida! deve conter no minímo 6 caracteres, letras e números.");
            }
            pessoa.ChaveAcesso = novaChaveAcesso;
            pessoaRepository.Update(pessoa);
        }

        public void ValidarNacionalidadeBrasileira(long idNacionalidade, long? IdMunicipioNaturalidade = null)
        {
            var nacionalidadeInformada = nacionalidadeRepository.SingleOrDefault(x => x.Id == idNacionalidade);

            if (nacionalidadeInformada.Nome == "Brasileiro(a)" && !IdMunicipioNaturalidade.HasValue)
                throw new Exception("Você deve informar sua naturalidade.");
        }

        public bool ValidarChaveAcesso(string chaveAcesso)
        {
            var contadorNumeros = 0;
            var contadorLetras = 0;
            var numeros = new char[10] {'0','1','2','3','4','5','6','7','8','9'};
            var letras = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                                        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            var aux = chaveAcesso.ToCharArray();
            for (int index = 0; index < aux.Length; index++)
            {
                for (int subIndex = 0; subIndex < numeros.Length; subIndex++)
                {
                    if (numeros[subIndex] == aux[index])
                    {
                        contadorNumeros++;
                    }
                }
            }

            for (int index = 0; index < aux.Length; index++)
            {
                for (int subIndex = 0; subIndex < letras.Length; subIndex++)
                {
                    if (letras[subIndex] == aux[index])
                    {
                        contadorLetras++;
                    }
                }
            }

            if (contadorLetras >= 1 && contadorNumeros >= 1) return true;

            else return false;
        }
    }
}