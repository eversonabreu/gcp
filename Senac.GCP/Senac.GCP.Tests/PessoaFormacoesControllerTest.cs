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
    public sealed class PessoaFormacoesControllerTest
    {

        //Testes de post

        //teste1
        [Fact]
        public void Post_PessoaFormacoes_Test()
        {
            var mockPessoaFormacoesRepository = new Mock<IPessoaFormacoesRepository>();
            var PessoaFormacoesService = new PessoaFormacoesService(mockPessoaFormacoesRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var pessoaFormacoesController = new PessoaFormacoesController(PessoaFormacoesService);

            var model = new PessoaFormacoesModel
            {
                IdPessoa = 1,
                IdCurso = 1,
                AnoConclusao = new DateTime(2022, 08, 04),
            };

            pessoaFormacoesController.Post(model);
        }

        //teste2
        [Fact]
        public void Post_PessoaFormacoes_Com_Ano_Invalido_Test()
        {
            var mockPessoaFormacoesRepository = new Mock<IPessoaFormacoesRepository>();
            var PessoaFormacoesService = new PessoaFormacoesService(mockPessoaFormacoesRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var pessoaFormacoesController = new PessoaFormacoesController(PessoaFormacoesService);

            var model = new PessoaFormacoesModel
            {
                IdPessoa = 1,
                IdCurso = 1,
                AnoConclusao = new DateTime(2020, 08, 04),
            };

            Assert.Throws<BusinessException>(() => pessoaFormacoesController.Post(model));
        }
    }
}