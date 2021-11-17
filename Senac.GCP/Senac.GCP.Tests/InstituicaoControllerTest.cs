using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class InstituicaoControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockInstituicaoRepository = new Mock<IInstituicaoRepository>();
            var instituicaoService = new InstituicaoService(mockInstituicaoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var instituicaoController = new InstituicaoController(instituicaoService);

            var model = new InstituicaoModel
            {
                Nome = "cris",
                CNPJ = "83455285000182",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                IdMunicipio = 1,
                EnderecoCEP = "10101010",
                Ativo = true,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                Observacoes = "nada",
                Email = "naoresponda.gcp@gmail.com",
                Telefone = "123123123"
            };

            instituicaoController.Post(model);
        }

    }
}
