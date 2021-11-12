using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Senac.GCP.Domain.Services.Interfaces;
using System;
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
            const decimal arquivoMais10MB = 1048575m;
            var mockRepositorioArquivo = new Mock<IArquivoRepository>();
            var arquivoService = new ArquivoService(mockRepositorioArquivo.Object, UtilsTest.GetHttpContextAccessor());
            var arquivo = new byte[1048576];

            //actual
            var result = arquivoService.ObterTamanhoEmMegaBytes(arquivo);
            
            if (arquivoMais10MB > 104876)
            {
                Assert.Throws<BusinessException>(())
            }
            Assert.Throws<Exception>.(arquivoMais10MB, result);
        }

    }
    }
}