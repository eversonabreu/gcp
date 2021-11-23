using Moq;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using System.Collections.Generic;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class ConcursoTipoCotasServiceTest
    {
        [Fact]
        public void Post_Test()
        {
            var mockConcursoTipoCotasRepository = new Mock<IConcursoTipoCotasRepository>();
            var mockConcursoRepository = new Mock<IConcursoRepository>();

            mockConcursoRepository.Setup(x => x.GetById(1)).Returns(new ConcursoEntity
            {
                PercentualQuantidadeVagasAmplaConcorrencia = 50
            });

            var concursoTipoCotasService = new ConcursoTipoCotasService(mockConcursoTipoCotasRepository.Object,
                UtilsTest.GetHttpContextAccessor(), mockConcursoRepository.Object);

            var model = new ConcursoTipoCotasModel
            {

                IdConcurso = 1,
                IdTipoCota = 5,
                PercentualVagas = 45
            };

            var entity = model.ToEntity<ConcursoTipoCotasEntity>();

            concursoTipoCotasService.BeforePost(entity);
            concursoTipoCotasService.AfterPost(entity);
        }

        [Fact]
        public void Post_Com_Percentual_Acima_Do_Permitido_Test()
        {
            var model = new ConcursoTipoCotasModel
            {

                IdConcurso = 1,
                IdTipoCota = 5,
                PercentualVagas = 40
            };

            var entity = model.ToEntity<ConcursoTipoCotasEntity>();

            var mockConcursoTipoCotasRepository = new Mock<IConcursoTipoCotasRepository>();

            mockConcursoTipoCotasRepository.Setup(y => y.Filter(x => x.IdConcurso == entity.IdConcurso))
                .Returns(new List<ConcursoTipoCotasEntity>()
            {
                new ConcursoTipoCotasEntity
                {
                    PercentualVagas = 10
                }
            });

            var mockConcursoRepository = new Mock<IConcursoRepository>();

            mockConcursoRepository.Setup(x => x.GetById(entity.IdConcurso)).Returns(new ConcursoEntity
            {
                PercentualQuantidadeVagasAmplaConcorrencia = 50
            });

            var concursoTipoCotasService = new ConcursoTipoCotasService(mockConcursoTipoCotasRepository.Object,
                UtilsTest.GetHttpContextAccessor(), mockConcursoRepository.Object);

            Assert.Throws<BusinessException>(() => concursoTipoCotasService.BeforePost(entity));
            Assert.Throws<BusinessException>(() => concursoTipoCotasService.AfterPost(entity));
        }

    }
}
