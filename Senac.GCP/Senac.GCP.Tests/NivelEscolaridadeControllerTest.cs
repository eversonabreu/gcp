using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class NivelEscolaridadeControllerTest
    {

        //Testes de post

        //teste1
        [Fact]
        public void Post_NivelEscolaridade_Test()
        {
            var mockNivelEscolaridadeRepository = new Mock<INivelEscolaridadeRepository>();
            var nivelEscolaridadeService = new NivelEscolaridadeService(mockNivelEscolaridadeRepository.Object, UtilsTest.GetHttpContextAccessor());
            var nivelEscolaridadeController = new NivelEscolaridadeController(nivelEscolaridadeService);
            var model = new NivelEscolaridadeModel
            {
                Sigla = "SG",
                Descricao = "Teste"
            };

            nivelEscolaridadeController.Post(model);
        }
    }
}