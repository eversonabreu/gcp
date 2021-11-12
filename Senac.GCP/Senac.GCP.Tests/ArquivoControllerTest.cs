using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using System;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class ArquivoControllerTest
    {
        [Fact]
        public void Post_Arquivo_Sem_Conteudo_Test()
        {
            var mockArquivoRepository = new Mock<IArquivoRepository>();
            var ArquivoService = new ArquivoService(mockArquivoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivoController = new ArquivoController(ArquivoService);

            var model = new ArquivoModel
            {
                Nome = "Manuel.pdf"
            };

            Assert.Throws<BusinessException>(() => arquivoController.Post(model));
        }

        [Fact]
        public void Post_Arquivo_Com_Conteudo_Vazio_Test()
        {
            var mockArquivoRepository = new Mock<IArquivoRepository>();
            var ArquivoService = new ArquivoService(mockArquivoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivoController = new ArquivoController(ArquivoService);

            var model = new ArquivoModel
            {
                Nome = "Manuel.pdf",
                Conteudo = Array.Empty<byte>()
            };

            Assert.Throws<BusinessException>(() => arquivoController.Post(model));
        }

        [Fact]
        public void Post_Arquivo_Sem_Extensao_Test()
        {
            //arrange
            var mockArquivoRepository = new Mock<IArquivoRepository>();
            var ArquivoService = new ArquivoService(mockArquivoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivoController = new ArquivoController(ArquivoService);

            var model = new ArquivoModel
            {
                Nome = "Manuel",
                Conteudo = new byte[10]
            };

            //actual and assert
            Assert.Throws<BusinessException>(() => arquivoController.Post(model));
            
            //Assert.Throws<> => É chamado para testar os erros. sendo o segundo passo para testar o método. 
            //<BusinessException> => testa os erros esperados qual são voids "erros sem retorno"
            //assert => valida as informações do método, caso seja void, o passo actual e assert atuam juntamente.
        }

        [Fact]
        public void Post_Arquivo_Sem_Nome_Test()
        {
            var mockArquivoRepository = new Mock<IArquivoRepository>();
            var ArquivoService = new ArquivoService(mockArquivoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivoController = new ArquivoController(ArquivoService);

            var model = new ArquivoModel
            {
                Conteudo = new byte [10]
            };

            Assert.Throws<BusinessException>(() => arquivoController.Post(model));
        }

        [Fact]
        public void Post_Arquivo_Com_Nome_Excedendo_225Caracteres_Test()
        {
            var mockArquivoRepository = new Mock<IArquivoRepository>();
            var ArquivoService = new ArquivoService(mockArquivoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivoController = new ArquivoController(ArquivoService);

            var model = new ArquivoModel
            {
                Nome = "NomeParaOTesteDoNomeDeArquivoQueUltrapassaOsDuzentosEVinteECincoCaracteresManoelTesteMarianaTeste123Teste1111111111111111111111111111111111" +
                "11111111111111111111111111111111111111111111111111111111111111111111111111111111112222222222222222222221111222222222222222222222222222222.pdf",
                Conteudo = new byte[10]
            };

            Assert.Throws<BusinessException>(() => arquivoController.Post(model));
        }
    }
}