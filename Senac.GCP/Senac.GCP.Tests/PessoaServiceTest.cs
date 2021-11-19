using Moq;
using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class PessoaServiceTest
    {
        [Fact]
        public void Bloquear_PessoaSemMotivo_Test()
        {
            var pessoaBloqueioDto = new PessoaBloqueioDto
            {
                IdPessoa = 1
            };

            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(pessoaBloqueioDto.IdPessoa)).Returns(new PessoaEntity());

            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);

            Assert.Throws<BusinessException>(() => pessoaService.BloquearUsuario(pessoaBloqueioDto));
        }
        /*
        [Fact]
        public void Desbloquear_PessoaSemMotivo_Test()
        {
            var pessoaBloqueioDto = new PessoaBloqueioDto
            {
                IdPessoa = 1
            };

            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(pessoaBloqueioDto.IdPessoa)).Returns(new PessoaEntity());

            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);

            Assert.Throws<BusinessException>(() => pessoaService.DesbloquearUsuario(pessoaBloqueioDto));
        }
        */

        [Fact]
        public void Alterar_ChaveAcesso_ComChaveAcessoAtualCorreta_Test()
        {
            const long idPessoa = 1;
            const string chaveAcessoAtual = "abc@123";

            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(idPessoa)).Returns(new PessoaEntity { ChaveAcesso = chaveAcessoAtual });

            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);

            pessoaService.AlterarChaveAcesso(idPessoa, chaveAcessoAtual, "xpto@789");
        }

        [Fact]
        public void Alterar_ChaveAcesso_ComChaveAcessoAtualIncorreta_Test()
        {
            const long idPessoa = 1;
            const string chaveAcessoAtual = "abc@123";

            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(idPessoa)).Returns(new PessoaEntity { ChaveAcesso = "gjhgjhgjgh" });

            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);

            Assert.Throws<BusinessException>(() => pessoaService.AlterarChaveAcesso(idPessoa, chaveAcessoAtual, "xpto@789"));
        }

        [Fact]
        public void Resetar_ChaveAcesso_Test()
        {
            const long idPessoa = 1;

            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());

            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);

            Assert.Throws<SendEmailException>(() => pessoaService.ResetarChaveAcesso(idPessoa));
        }

    }
}
