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
    public sealed class ConcursoEditaisControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockConcursoEditaisRepository = new Mock<IConcursoEditaisRepository>();
            var ConcursoEditaisService = new ConcursoEditaisService(mockConcursoEditaisRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var ConcursoEditaisController = new ConcursoEditaisController(ConcursoEditaisService);

            var model = new ConcursoEditaisModel
            {
                DataEdital = System.DateTime.MaxValue,
                Descricao = "Nao pode parar",
                IdConcurso = 1,
                IdArquivo = 2
                
            };

            ConcursoEditaisController.Post(model);
        }

        
    }
}
