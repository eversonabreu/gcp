using Senac.GCP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Senac.GCP.Domain.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(long id, bool loadDependencies = false);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, TEntity defaultResult = null, bool loadDependencies = false);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression, TEntity defaultResult = null, bool loadDependencies = false);

        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression, bool loadDependencies = false);

        (IEnumerable<TEntity> Data, int Count) FilterWithPagination(string expression, string sort = null, uint page = 0, uint limit = 10, bool loadDependencies = false);

        long Add(TEntity entity);

        void Update(TEntity entity);

        void DeleteById(long id);
    }
}
