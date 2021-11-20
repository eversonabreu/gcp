using Moq;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class ArquivoServiceTest
    {
        [Fact]
        public void Validar_Se_Arquivo_Nao_Supera_10MB_Test()
        {
            //arrange
            const decimal tamanhoEsperado = 1m;
            var mockRepositorioArquivo = new Mock<IArquivoRepository>();
            var arquivoService = new ArquivoService(mockRepositorioArquivo.Object, UtilsTest.GetHttpContextAccessor());
            var arquivo = new byte[1048576];

            //actual

            var result = arquivoService.ObterTamanhoEmMegaBytes(arquivo);

            //assert
            Assert.Equal(tamanhoEsperado, result);
        }

        [Fact]
        public void Validar_Se_Arquivo_Supera_10MB_Test()
        {
            //arrange
            const int tamanhoEsperado = 11534380;

            var mockRepositorioArquivo = new Mock<IArquivoRepository>();
            var arquivoService = new ArquivoService(mockRepositorioArquivo.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivo = new byte[tamanhoEsperado];

            //assert
            Assert.Throws<BusinessException>(() => arquivoService.ObterTamanhoEmMegaBytes(arquivo));
        }
    }
}