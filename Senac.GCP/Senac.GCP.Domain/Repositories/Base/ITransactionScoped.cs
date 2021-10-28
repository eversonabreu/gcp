using Senac.GCP.Domain.Entities.Base;

namespace Senac.GCP.Domain.Repositories.Base
{
    public interface ITransactionScoped
    {
        void AddInsert<TEntity>(TEntity entity) where TEntity : Entity;

        void AddUpdate<TEntity>(TEntity entity) where TEntity : Entity;

        void AddDelete<TEntity>(long id) where TEntity : Entity;

        void SaveAll();
    }
}