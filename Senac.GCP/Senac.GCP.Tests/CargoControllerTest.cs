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
    public sealed class CargoControllerTest
    {
        //Testes de post

        //teste1
        [Fact]
        public void Post_Cargo_Test()
        {
            var mockCargoRepository = new Mock<ICargoRepository>();
            var cargoService = new CargoService(mockCargoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var cargoController = new CargoController(cargoService);

            var model = new CargoModel
            {
                Descricao = "Professor",
                IdNivelEscolaridade = 1,
                Codigo = 1,
            };
            cargoController.Post(model);
        }

        //test2
        [Fact]
        public void Post_Cargo_Sem_Descricao_Test()
        {
            var mockCargoRepository = new Mock<ICargoRepository>();
            var cargoService = new CargoService(mockCargoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var cargoController = new CargoController(cargoService);

            var model = new CargoModel
            {                
                IdNivelEscolaridade = 1,
                Codigo = 1,
            };

            Assert.Throws<BusinessException>(() => cargoController.Post(model));
        }

        //-------------------
        //Teste de Put 

        //teste1Put
        [Fact]
        public void Put_Cargo_Test()
        {
            var mockCargoRepository = new Mock<ICargoRepository>();
            mockCargoRepository.Setup(x => x.GetById(1)).Returns(new CargoEntity());
            var cargoService = new CargoService(mockCargoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var cargoController = new CargoController(cargoService);

            var model = new CargoModel
            {
                Id = 1,
                Descricao = "Professor",
                IdNivelEscolaridade = 1,
                Codigo = 1,
            };

            cargoController.Put(model);
        }

        //teste2Put
        [Fact]
        public void Put_Cargo_Sem_Descricao_Test()
        {
            var mockCargoRepository = new Mock<ICargoRepository>();
            mockCargoRepository.Setup(x => x.GetById(1)).Returns(new CargoEntity());
            var cargoService = new CargoService(mockCargoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var cargoController = new CargoController(cargoService);

            var model = new CargoModel
            {
                Id = 1,                
                IdNivelEscolaridade = 1,
                Codigo = 1,
            };

            Assert.Throws<BusinessException>(() => cargoController.Put(model));
        }

        //----------
        //TesteDelete
        [Fact]
        public void DeleteByIdCargo_Test()
        {
            var mockCargoRepository = new Mock<ICargoRepository>();
            var cargoService = new CargoService(mockCargoRepository.Object,
                UtilsTest.GetHttpContextAccessor());
            var cargoController = new CargoController(cargoService);

            cargoController.DeleteById(1);
        }
    }
}