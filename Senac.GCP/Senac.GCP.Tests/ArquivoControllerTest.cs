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
    public sealed class ArquivoControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockArquivoRepository = new Mock<IArquivoRepository>();
            var ArquivoService = new ArquivoService(mockArquivoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivoController = new ArquivoController(ArquivoService);

            var model = new ArquivoModel
            {

                Nome = "Fulano",

                Extensao = "PDF",
            };
             arquivoController.Post(model);
        }
    }
}

    

    

