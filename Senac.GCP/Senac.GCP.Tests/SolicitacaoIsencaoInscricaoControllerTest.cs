using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class SolicitacaoIsencaoInscricaoControllerTest
    {
        //Testes de post

        //teste1
        [Fact]
        public void Post_SolicitacaoIsencaoInscricao_Test()
        {
            var mockSolicitacaoIsencaoInscricaoRepository = new Mock<ISolicitacaoIsencaoInscricaoRepository>();
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockInscricaoRepository = new Mock<IInscricaoRepository>();
            var mockConcursoRepository = new Mock<IConcursoRepository>();

            var mockIntegrantesComissaoOrganizacaoService = new Mock<IIntegrantesComissaoOrganizacaoService>();
            var mockInscricaoService = new Mock<IInscricaoService>();

            var SolicitacaoIsencaoInscricaoService = new SolicitacaoIsencaoInscricaoService
            (
                mockSolicitacaoIsencaoInscricaoRepository.Object,
                UtilsTest.GetHttpContextAccessor(), 
                UtilsTest.GetEmailService(),
                mockIntegrantesComissaoOrganizacaoService.Object,
                mockInscricaoService.Object,
                mockPessoaRepository.Object,
                mockInscricaoRepository.Object,
                mockConcursoRepository.Object
            );

            var solicitacaoIsencaoInscricaoController = new SolicitacaoIsencaoInscricaoController(SolicitacaoIsencaoInscricaoService);

            var model = new SolicitacaoIsencaoInscricaoModel
            {
                IdInscricao = 1,
                IdTipoSolicitacaoIsencaoInscricao = 1,
                DataSolicitacao = new DateTime(2020, 08, 04),
                SituacaoSolicitacao = Domain.Enums.SituacaoSolicitacaoIsencaoInscricaoEnum.EmAnalise
            };

            solicitacaoIsencaoInscricaoController.Post(model);
        }

    }
}