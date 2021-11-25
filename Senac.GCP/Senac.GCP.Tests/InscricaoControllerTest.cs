using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using System;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class InscricaoControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockInscricaoRepository = new Mock<IInscricaoRepository>();
            var inscricaoService = new InscricaoService(mockInscricaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var inscricaoController = new InscricaoController(inscricaoService);

            var model = new InscricaoModel
            {
                IdPessoa = 1,
                IdConcursoCargo = 5,
                DataInscricao = DateTime.Now,
                Situacao = (Domain.Enums.SituacaoInscricaoEnum)2,
                ParticiparComoCotista = false,
                MotivoRecusaInscricao = "nenhum",
                DataRecusaInscricao = DateTime.Now.AddDays(3)
            };

            inscricaoController.Post(model);
        }

        //PUTS:
        [Fact]
        public void Put_Test()
        {
            var mockInscricaoRepository = new Mock<IInscricaoRepository>();
            mockInscricaoRepository.Setup(x => x.GetById(1)).Returns(new InscricaoEntity());
            var inscricaoService = new InscricaoService(mockInscricaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var inscricaoController = new InscricaoController(inscricaoService);

            var model = new InscricaoModel
            {
                Id = 1,
                IdPessoa = 1,
                IdConcursoCargo = 1,
                DataInscricao = DateTime.Now,
                Situacao = (Domain.Enums.SituacaoInscricaoEnum)2,
                ParticiparComoCotista = false,
                MotivoRecusaInscricao = "nenhum",
                DataRecusaInscricao = DateTime.Now.AddDays(3)
            };

            inscricaoController.Put(model);
        }

        //DELETES
        [Fact]
        public void DeleteById_Test()
        {

            var mockInscricaoRepository = new Mock<IInscricaoRepository>();

            mockInscricaoRepository.Setup(x => x.GetById(1)).Returns(new InscricaoEntity());

            var inscricaoService = new InscricaoService
            (
                mockInscricaoRepository.Object,
                UtilsTest.GetHttpContextAccessor()
            );
            var inscricaoController = new InscricaoController(inscricaoService);

            inscricaoController.DeleteById(1);
        }
    }
}
