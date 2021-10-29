using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Repositories.Base;

namespace Senac.GCP.Domain.Services.Base
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> repository;

        private readonly IHttpContextAccessor httpContextAccessor;

        public Service(IRepository<TEntity> repository, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IRepository<TEntity> GetRepository() => repository;

        public HttpContext GetHttpContext() => httpContextAccessor.HttpContext;

        public virtual void BeforePost(TEntity entity) { }

        public virtual void BeforePut(TEntity entity) { }

        public virtual void BeforeDelete(long id) { }

        public virtual void AfterPost(TEntity entity) { }

        public virtual void AfterPut(TEntity entity) { }

        public virtual void AfterDelete(long id) { }
    }
}