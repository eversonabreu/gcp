using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Senac.GCP.Domain.Utils;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class UsuarioControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(mockUsuarioRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService());
            var usuarioController = new UsuarioController(usuarioService);

            var model = new UsuarioModel
            {
                Administrador = true,
                Ativo = true,
                CPF = "05450395922",
                Email = "everson.ean@gmail.com",
                Nome = "Everson"
            };

            Assert.Throws<SendEmailException>(() => usuarioController.Post(model));
        }

        [Fact]
        public void Put_Test()
        {
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            mockUsuarioRepository.Setup(x => x.GetById(1)).Returns(new UsuarioEntity());
            var usuarioService = new UsuarioService(mockUsuarioRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService());
            var usuarioController = new UsuarioController(usuarioService);

            var model = new UsuarioModel
            {
                Id = 1,
                Administrador = true,
                Ativo = true,
                CPF = "05450395922",
                Email = "everson.ean@gmail.com",
                Nome = "Everson"
            };

            usuarioController.Put(model);
        }

        [Fact]
        public void DeleteById_Test()
        {
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(mockUsuarioRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService());
            var usuarioController = new UsuarioController(usuarioService);

            usuarioController.DeleteById(1);
        }

        [Fact]
        public void AlterarSenha_ComSenhaAtualCorreta_Test()
        {
            const long idUsuario = 1;
            const string senhaAtual = "abc@123";
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            mockUsuarioRepository.Setup(x => x.GetById(idUsuario)).Returns(new UsuarioEntity { Senha = senhaAtual.Encrypt() });
            var usuarioService = new UsuarioService(mockUsuarioRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService());
            var usuarioController = new UsuarioController(usuarioService);

            usuarioController.AlterarSenha(idUsuario, senhaAtual, "xpto@789");
        }

        [Fact]
        public void AlterarSenha_ComSenhaAtualIncorreta_Test()
        {
            const long idUsuario = 1;
            const string senhaAtual = "abc@123";
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            mockUsuarioRepository.Setup(x => x.GetById(idUsuario)).Returns(new UsuarioEntity { Senha = senhaAtual });
            var usuarioService = new UsuarioService(mockUsuarioRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService());
            var usuarioController = new UsuarioController(usuarioService);

            Assert.Throws<BusinessException>(() => usuarioController.AlterarSenha(idUsuario, senhaAtual, "xpto@789"));
        }
    }
}
