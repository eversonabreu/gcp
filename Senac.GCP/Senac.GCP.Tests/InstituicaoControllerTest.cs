using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class InstituicaoControllerTest
    {

        // POSTS:
        [Fact]
        public void Post_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            instituicaoController.Post(model);
        }

        [Fact]
        public void Post_Instituicao_SemNome_test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }

        [Fact]
        public void Post_Instituicao_SemCNPJ_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }

        [Fact]
        public void Post_Instituicao_ComCNPJinválido_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83450285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }

        [Fact]
        public void Post_Instituicao_SemEnderecoRua_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }

        [Fact]
        public void Post_Instituicao_SemEnderecoBairro_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }

        [Fact]
        public void Post_Instituicao_SemEnderecoCEP_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }

        [Fact]
        public void Post_Instituicao_SemEmail_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }


        [Fact]
        public void Post_Instituicao_SemTelefone_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Post(model));
        }


        //PUTS:
        [Fact]
        public void Put_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            mockInstituicaoRepository.Setup(x => x.GetById(1)).Returns(new InstituicaoEntity());
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Id = 1,
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            instituicaoController.Put(model);
        }

        [Fact]
        public void Put_Instituicao_ComCNPJinválidoTest()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            mockInstituicaoRepository.Setup(x => x.GetById(1)).Returns(new InstituicaoEntity());
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Id = 1,
                Nome = "cris",
                CNPJ = "83455285002182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            Assert.Throws<BusinessException>(() => instituicaoController.Put(model));
        }



        //DELETES
        [Fact]
        public void DeleteById_Test()
        {

            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();

            mockInstituicaoRepository.Setup(x => x.GetById(1)).Returns(new InstituicaoEntity());

            var instituicaoService = new InstituicaoService
            (
                mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor()
            );
            var instituicaoController = new InstituicaoController(instituicaoService);

            instituicaoController.DeleteById(1);
        }

    }
}