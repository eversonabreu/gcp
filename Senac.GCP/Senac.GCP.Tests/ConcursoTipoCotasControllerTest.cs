using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class ConcursoTipoCotasTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockConcursoTipoCotasRepository = new Mock<IConcursoTipoCotasRepository>();
            var concursoTipoCotasService = new ConcursoTipoCotasService(mockConcursoTipoCotasRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var concursoTipoCotasController = new ConcursoTipoCotasController(concursoTipoCotasService);

            var model = new ConcursoTipoCotasModel
            {

                IdConcurso = 122,
                IdTipoCota = 5,
                PercentualVagas = 45

            };

            concursoTipoCotasController.Post(model);
        }

    }
}
