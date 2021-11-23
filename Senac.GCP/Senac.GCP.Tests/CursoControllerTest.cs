using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class CursoControllerTest
    {
        [Fact]
        public void Post_Curso_Test()
        {
            var mockCursoRepository = new Mock<ICursoRepository>();
            var cursoService = new CursoService(mockCursoRepository.Object, UtilsTest.GetHttpContextAccessor());
            var cursoController = new CursoController(cursoService);
            var model = new CursoModel
            {
                Descricao = "Teste",
                Codigo = 2,
                IdNivelEscolaridade = 2
            };

            cursoController.Post(model);
        }
    }
}