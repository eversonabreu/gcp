using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
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

        [Fact]
        public void Post_ConcursoFasesLocaisTest()
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

        [Fact]
        public void Post_ConcursoFasesLocais_NomeLocal_Test()
        {
            var mockConcursoFasesLocaisRepository = new Mock<IConcursoFasesLocaisRepository>();
            var ConcursoFasesLocaisService = new ConcursoFasesLocaisService(mockConcursoFasesLocaisRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var ConcursoFasesLocaisController = new ConcursoFasesLocaisController(ConcursoFasesLocaisService);

            var model = new ConcursoFasesLocaisModel
            {
                IdConcursoFases = 1,
                // NomeLocal = "Nao pode parar ",
                EnderecoRua = "Leonel",
                EnderecoNumero = "123",
                EnderecoBairro = "Favela Venceu",
                EnderecoComplemento = "Logo ali",
                EnderecoCEP = "10101010",
                IdMunicipioEndereco = 2,
                Telefone = "123123123",
                Email = "naoresponda.gcp@gmail.com"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }

        [Fact]
        public void Post_ConcursoFasesLocais_EnderecoRua_Test()
        {
            var mockConcursoFasesLocaisRepository = new Mock<IConcursoFasesLocaisRepository>();
            var ConcursoFasesLocaisService = new ConcursoFasesLocaisService(mockConcursoFasesLocaisRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var ConcursoFasesLocaisController = new ConcursoFasesLocaisController(ConcursoFasesLocaisService);

            var model = new ConcursoFasesLocaisModel
            {
                IdConcursoFases = 1,
                NomeLocal = "Nao pode parar ",
                //EnderecoRua = "Leonel",
                EnderecoNumero = "123",
                EnderecoBairro = "Favela Venceu",
                EnderecoComplemento = "Logo ali",
                EnderecoCEP = "10101010",
                IdMunicipioEndereco = 2,
                Telefone = "123123123",
                Email = "naoresponda.gcp@gmail.com"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }

        [Fact]
        public void Post_ConcursoFasesLocais_EnderecoNumero_Test()
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
                EnderecoNumero = "111111111122222222222",//21 caracteres
                EnderecoBairro = "Favela Venceu",
                EnderecoComplemento = "Logo ali",
                EnderecoCEP = "10101010",
                IdMunicipioEndereco = 2,
                Telefone = "123123123",
                Email = "naoresponda.gcp@gmail.com"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }

        [Fact]
        public void Post_ConcursoFasesLocais_EnderecoBairro_Test()
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
                //EnderecoBairro = "Favela Venceu",
                EnderecoComplemento = "Logo ali",
                EnderecoCEP = "10101010",
                IdMunicipioEndereco = 2,
                Telefone = "123123123",
                Email = "naoresponda.gcp@gmail.com"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }

        [Fact]
        public void Post_ConcursoFasesLocais_EnderecoComplemento_Test()
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
                EnderecoComplemento = "hahahahahahahahahahahahahahahahahahahahahahahahaha,hahahahahahahahahahahahahahahahahahahahahahahahaha,hahahahahahahahahahahahahahahahahahahahahahahahaha",
                EnderecoCEP = "10101010",
                IdMunicipioEndereco = 2,
                Telefone = "123123123",
                Email = "naoresponda.gcp@gmail.com"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }

        [Fact]
        public void Post_ConcursoFasesLocais_EnderecoCEP_Test()
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
                //EnderecoCEP = "10101010",
                IdMunicipioEndereco = 2,
                Telefone = "123123123",
                Email = "naoresponda.gcp@gmail.com"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }

        [Fact]
        public void Post_ConcursoFasesLocais_Telefone_Test()
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
                Telefone = "123123123222",
                Email = "naoresponda.gcp@gmail.com"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }

        [Fact]
        public void Post_ConcursoFasesLocais_Email_Test()
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
                Telefone = "123123123222",
                Email = "naoresponda.gcp.com.br"


            };

            Assert.Throws<BusinessException>(() => ConcursoFasesLocaisController.Post(model));
        }


        [Fact]
        public void Put_Test()
        {
            var mockConcursoFasesLocaisRepository = new Mock<IConcursoFasesLocaisRepository>();
            mockConcursoFasesLocaisRepository.Setup(x => x.GetById(1)).Returns(new ConcursoFasesLocaisEntity());
            var ConcursoFasesLocaisService = new ConcursoFasesLocaisService(mockConcursoFasesLocaisRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var ConcursoFasesLocaisController = new ConcursoFasesLocaisController(ConcursoFasesLocaisService);

            var model = new ConcursoFasesLocaisModel
            {
                Id = 1,
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

            ConcursoFasesLocaisController.Put(model);
        }

        [Fact]
        public void DeleteById_Test()
        {
            var mockConcursoFasesLocaisRepository = new Mock<IConcursoFasesLocaisRepository>();
            var ConcursoFasesLocaisService = new ConcursoFasesLocaisService(mockConcursoFasesLocaisRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var ConcursoFasesLocaisController = new ConcursoFasesLocaisController(ConcursoFasesLocaisService);

            ConcursoFasesLocaisController.DeleteById(1);
        }


    }
}
