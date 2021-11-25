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
    public sealed class ConcursoFasesLocaisSalaTest
    {

        //Testes de post

        //teste1
        [Fact]
        public void Post_ConcursoFasesLocaisSala_Test()
        {
            var mockConcursoFasesLocaisSalaRepository = new Mock<IConcursoFasesLocaisSalaRepository>();
            var concursoFasesLocaisSalaService = new ConcursoFasesLocaisSalaService(mockConcursoFasesLocaisSalaRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var concursoFasesLocaisSalaController = new ConcursoFasesLocaisSalaController(concursoFasesLocaisSalaService);

            var model = new ConcursoFasesLocaisSalaModel
            {

            };

            concursoFasesLocaisSalaController.Post(model);
        } 
    
        //-------------------
        //Teste de Put 

        //teste1Put
        [Fact]
        public void Put_ConcursoFasesLocaisSala_Arquivo_Test()
        {
            var mockConcursoFasesLocaisSalaRepository = new Mock<IConcursoFasesLocaisSalaRepository>();
            mockConcursoFasesLocaisSalaRepository.Setup(x => x.GetById(1)).Returns(new ConcursoFasesLocaisSalaEntity());
            var concursoFasesLocaisSalaService = new ConcursoFasesLocaisSalaService(mockConcursoFasesLocaisSalaRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var concursoFasesLocaisSalaController = new ConcursoFasesLocaisSalaController(concursoFasesLocaisSalaService);

            var model = new ConcursoFasesLocaisSalaModel
            {
                Id = 1,
                
            };

            concursoFasesLocaisSalaController.Put(model);
        }

        //----------
        //TesteDelete
        [Fact]
        public void DeleteByIdArquivo_Test()
        {
            var mockArquivoRepository = new Mock<IArquivoRepository>();
            var arquivoService = new ArquivoService(mockArquivoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var arquivoController = new ArquivoController(arquivoService);

            arquivoController.DeleteById(1);
        }
    }
}