using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Notifications;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using Senac.GCP.Domain.Utils;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class UsuarioService : Service<UsuarioEntity>, IUsuarioService
    {
        private readonly IEmailService emailService;
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService)
            : base(usuarioRepository, httpContextAccessor)
        {
            this.emailService = emailService;
            this.usuarioRepository = usuarioRepository;
        }

        public override void BeforePost(UsuarioEntity entity)
        {
            ValidarDuplicidadeEmailUsuario(entity.Email);
            ValidarDuplicidadeCPFUsuario(entity.CPF);
            string senhaAutomatica = Guid.NewGuid().ToString().Split('-').First();
            entity.Senha = senhaAutomatica.Encrypt();
            entity.Ativo = true;
            entity.DataCadastramento = DateTime.Now;
        }

        public override void BeforePut(UsuarioEntity entity)
        {
            ValidarDuplicidadeEmailUsuario(entity.Email, entity.Id);
            ValidarDuplicidadeCPFUsuario(entity.CPF, entity.Id);
        }

        public override void AfterPost(UsuarioEntity entity)
        {
            EnviarEmailUsuarioParaConfirmacaoDeCadasatro(entity);
        }

        private void ValidarDuplicidadeEmailUsuario(string email, long? idUsuario = null)
        {
            var usuario = usuarioRepository.SingleOrDefault(item => item.Email == email);
            if (usuario != null)
            {
                if (idUsuario.HasValue)
                {
                    if (usuario.Id != idUsuario.Value)
                    {
                        throw new Exception("Não é possível atualizar este usuário porque o e-mail informado já está sendo utilizado por outro registro");
                    }
                }
                else
                {
                    throw new Exception("Não é possível inserir este usuário porque o e-mail informado já está sendo utilizado por outro registro");
                }
            }
        }

        private void ValidarDuplicidadeCPFUsuario(string cpf, long? idUsuario = null)
        {
            var usuario = usuarioRepository.SingleOrDefault(item => item.CPF == cpf);
            if (usuario != null)
            {
                if (idUsuario.HasValue)
                {
                    if (usuario.Id != idUsuario.Value)
                    {
                        throw new Exception("Não é possível atualizar este usuário porque o CPF informado já está sendo utilizado por outro registro");
                    }
                }
                else
                {
                    throw new Exception("Não é possível inserir este usuário porque o CPF informado já está sendo utilizado por outro registro");
                }
            }
        }

        private void EnviarEmailUsuarioParaConfirmacaoDeCadasatro(UsuarioEntity entity)
        {
            string senha = entity.Senha.Decrypt();
            var envioEmail = emailService
                             .WithTitle("GCP - Recebimento de senha automática para acesso ao sistema")
                             .WithBody(@$"<h4>Prezado(a): <b>{entity.Nome}</b>, bem-vindo(a) ao sistema GCP.</h4><br/>
                                         <h5>Esta a sua senha de acesso (foi gerada automáticamente pelo sistema): {senha}</h5><br/><br/>
                                         <h6><i>Caso queira voçê poderá alterar a sua senha pelo sistema</i></h6>", true)
                             .WithRecipient(entity.Email)
                             .Send();
            if (!envioEmail)
            {
                usuarioRepository.DeleteById(entity.Id);
                throw new Exception("Não foi possível inserir este usuário porque ocorreu um problema no envio de e-mail de sua senha");
            }
        }

        public void AlterarSenha(long idUsuario, string senhaAtual, string novaSenha)
        {
            var usuario = usuarioRepository.GetById(idUsuario);
            if (usuario.Senha != senhaAtual.Encrypt())
            {
                throw new Exception("A senha atual não corresponde com a senha informada.");
            }

            usuario.Senha = novaSenha.Encrypt();
            usuarioRepository.Update(usuario);
        }
    }
}