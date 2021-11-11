using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
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
        public void Post_PessoaBrasileira_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)"});
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
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
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
                NivelEscolaridade = NivelEscolaridadeEnum.EnsinoTecnico
            };

            Assert.Throws<SendEmailException>(() => pessoaController.Post(model));
        }

        
        [Fact]
        public void Post_PessoaBrasileiraSemNaturalidade_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)" });
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = null,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
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
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
                NivelEscolaridade = NivelEscolaridadeEnum.EnsinoTecnico
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }

        [Fact]
        public void Put_ComPessoaBrasileira_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)" });
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                Id = 1,
                IdArquivoFoto = 1,
                IdMunicipioNaturalidade = 1,
                IdNacionalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
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
        public void Put_ComPessoaBrasileiraSemNaturalidade_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)" });
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                Id = 1,
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
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

            Assert.Throws<BusinessException>(() => pessoaController.Put(model));
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
        public void Bloquear_Usuario_Test()
        {
            const long idPessoa = 1;
            string motivoBloqueio = "Senha incorreta várias vezes";
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            pessoaController.BloquearUsuario(idPessoa, motivoBloqueio);
        }

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
            mockPessoaRepository.Setup(x => x.GetById(idPessoa)).Returns(new PessoaEntity { ChaveAcesso = "gjhgjhgjgh" });
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

            Assert.Throws<SendEmailException>(() => pessoaController.ResetarChaveAcesso(idPessoa));
        }

        /*
        [Fact]
        public void ValidarNaturalidade_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();
            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            var pessoaService = new PessoaService(mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(), UtilsTest.GetEmailService(), mockNacionalidadeRepository.Object);
            var pessoaController = new PessoaController(pessoaService);

            Assert.Throws<BusinessException>(() => pessoaService.BeforePost());

        }
        */
    }
}
