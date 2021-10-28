using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Repositories.Base;

namespace Senac.GCP.Domain.Services.Base
{
    public interface IService<TEntity> where TEntity : Entity
    {
        IRepository<TEntity> GetRepository();

        HttpContext GetHttpContext();

        void BeforeSave(TEntity entity, bool isUpdated);

        void AfterSave(TEntity entity, bool isUpdated);
    }
}
