using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
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
                IdConcursoCargo = 1,
                DataInscricao = DateTime.Now,
                Situacao = (Domain.Enums.SituacaoInscricaoEnum) 2,
                ParticiparComoCotista = false,
                MotivoRecusaInscricao = "nenhum",
                DataRecusaInscricao = DateTime.Now.AddDays(3)
            };

            inscricaoController.Post(model);
        }

    }
}
