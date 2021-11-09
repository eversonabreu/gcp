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
    public sealed class PessoaControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdClassificacaoDoenca = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                IdMunicipioNaturalidade = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cristina Priester",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<SendEmailException>(() => pessoaController.Post(model));
        }

        [Fact]
        public void Put_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                Id = 1,
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdClassificacaoDoenca = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                IdMunicipioNaturalidade = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cristina Priester",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            pessoaController.Put(model);
        }

        [Fact]
        public void DeleteById_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            pessoaController.DeleteById(1);
        }

        [Fact]
        public void Alterar_ChaveAcesso_ComChaveAcessoAtualCorreta_Test()
        {
            const long idPessoa = 1;
            const string chaveAcessoAtual = "abc@123";
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(idPessoa)).Returns(new PessoaEntity { ChaveAcesso = chaveAcessoAtual.Encrypt() });
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            pessoaController.AlterarChaveAcesso(idPessoa, chaveAcessoAtual, "xpto@789");
        }

        [Fact]
        public void Alterar_ChaveAcesso_ComChaveAcessoAtualIncorreta_Test()
        {
            const long idPessoa = 1;
            const string chaveAcessoAtual = "abc@123";
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(idPessoa)).Returns(new PessoaEntity { ChaveAcesso = chaveAcessoAtual });
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            Assert.Throws<BusinessException>(() => pessoaController.AlterarChaveAcesso(idPessoa, chaveAcessoAtual, "xpto@789"));
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
            var pessoaController = new PessoaController(pessoaService);

            Assert.Throws<BusinessException>(() => pessoaController.ResetarChaveAcesso(idPessoa));
        }


        [Fact]
        public void ValidarNacionalidadeBrasileira_Test()
        {
            const long idNacionalidade = 22;
            const long IdMunicipioNaturalidade = 1;
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);

            Assert.Throws<BusinessException>(() => pessoaService.ValidarNacionalidadeBrasileira(idNacionalidade, IdMunicipioNaturalidade));

        }
    }
}
