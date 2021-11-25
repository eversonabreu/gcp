using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using System;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class ConcursoEditaisControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockConcursoEditaisRepository = new Mock<IConcursoEditaisRepository>();
            var mockConcursoRepository = new Mock<IConcursoRepository>();
            
            var ConcursoEditaisService = new ConcursoEditaisService
            (
                mockConcursoEditaisRepository.Object,
                mockConcursoRepository.Object, 
                UtilsTest.GetHttpContextAccessor()
            );
            var ConcursoEditaisController = new ConcursoEditaisController(ConcursoEditaisService);

            var model = new ConcursoEditaisModel
            {
                DataEdital = new DateTime(2021, 08, 05),
                Descricao = "Nao pode parar",
                IdConcurso = 1,
                IdArquivo = 1
            };

            ConcursoEditaisController.Post(model);
        }

        [Fact]
        public void Post_Descricao_Test()
        {
            var mockConcursoEditaisRepository = new Mock<IConcursoEditaisRepository>();
            var mockConcursoRepository = new Mock<IConcursoRepository>();
            var ConcursoEditaisService = new ConcursoEditaisService(mockConcursoEditaisRepository.Object,
                mockConcursoRepository.Object, UtilsTest.GetHttpContextAccessor());
            var ConcursoEditaisController = new ConcursoEditaisController(ConcursoEditaisService);

            var model = new ConcursoEditaisModel
            {
                DataEdital = new DateTime(2021, 08, 05),
                Descricao = "Nao pode parar",
                IdConcurso = 1,
                IdArquivo = 2

            };

            Assert.Throws<BusinessException>(() => ConcursoEditaisController.Post(model));
        }

        [Fact]
        public void Put_Test()
        {
            var mockConcursoEditaisRepository = new Mock<IConcursoEditaisRepository>();
            var mockConcursoRepository = new Mock<IConcursoRepository>();
            mockConcursoEditaisRepository.Setup(x => x.GetById(1)).Returns(new ConcursoEditaisEntity());
            var ConcursoEditaisService = new ConcursoEditaisService(mockConcursoEditaisRepository.Object,
                mockConcursoRepository.Object, UtilsTest.GetHttpContextAccessor());
            var ConcursoEditaisController = new ConcursoEditaisController(ConcursoEditaisService);

            var model = new ConcursoEditaisModel
            {
                Id = 1,
                DataEdital = new DateTime(2021, 08, 05),
                Descricao = "Nao pode parar",
                IdConcurso = 1,
                IdArquivo = 2
            };

            ConcursoEditaisController.Put(model);
        }

        [Fact]
        public void DeleteById_Test()
        {
            var mockConcursoEditaisRepository = new Mock<IConcursoEditaisRepository>();
            var mockConcursoRepository = new Mock<IConcursoRepository>();
            var ConcursoEditaisService = new ConcursoEditaisService(mockConcursoEditaisRepository.Object,
                mockConcursoRepository.Object, UtilsTest.GetHttpContextAccessor());
            var ConcursoEditaisController = new ConcursoEditaisController(ConcursoEditaisService);

            ConcursoEditaisController.DeleteById(1);
        }
    }
}