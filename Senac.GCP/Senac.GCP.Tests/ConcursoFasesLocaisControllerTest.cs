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
    public sealed class ConcursoFasesLocaisControllerTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockConcursoFasesLocaisRepository = new Mock<IConcursoFasesLocaisRepository>();
            var ConcursoFasesLocaisService = new ConcursoFasesLocaisService(mockConcursoFasesLocaisRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var ConcursoFasesLocaisController = new ConcursoFasesLocaisController(ConcursoFasesLocaisService);

            var model = new ConcursoFasesLocaisModel
            {
                IdConcursoFases = 1,
                NomeLocal = "Nao pode parar ",
                EnderecoRua = "Leonel",
                EnderecoNumero = "123",
                EnderecoBairro = "Favela Venceu",
                EnderecoComplemento = "Logo ali",
                EnderecoCEP = "10101010",
                IdMunicipioEndereco = 2,
                Telefone = "123123123",
                Email = "naoresponda.gcp@gmail.com"


            };

            ConcursoFasesLocaisController.Post(model);
        }

        
    }
}
