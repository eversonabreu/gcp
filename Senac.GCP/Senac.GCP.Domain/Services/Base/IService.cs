using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Repositories.Base;

namespace Senac.GCP.Domain.Services.Base
{
    public interface IService<TEntity> where TEntity : Entity
    {
        IRepository<TEntity> GetRepository();

        HttpContext GetHttpContext();

        void BeforePost(TEntity entity);

        void BeforePut(TEntity entity);

        void BeforeDelete(TEntity entity);

        void AfterPost(TEntity entity);

        void AfterPut(TEntity entity);

        void AfterDelete(TEntity entity);
    }
}