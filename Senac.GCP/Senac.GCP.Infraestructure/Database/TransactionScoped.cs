using Microsoft.EntityFrameworkCore;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Repositories.Base;
using System.Linq;

namespace Senac.GCP.Infraestructure.Database
{
    public sealed class TransactionScoped : ITransactionScoped
    {
        private readonly DatabaseContext databaseContext;

        public TransactionScoped(DatabaseContext databaseContext) => this.databaseContext = databaseContext;

        public void AddInsert<TEntity>(TEntity entity) where TEntity : Entity
        {
            var dbSet = databaseContext.Set<TEntity>();
            dbSet.Add(entity);
        }

        public void AddUpdate<TEntity>(TEntity entity) where TEntity : Entity
        {
            var entityDb = databaseContext.Set<TEntity>().SingleOrDefault(x => x.Id == entity.Id);

            if (entityDb is null)
            {
                throw new System.Exception("Nenhum resultado encontrado para atualização de dados");
            }

            databaseContext.Entry(entityDb).State = EntityState.Modified;
            databaseContext.Entry(entityDb).CurrentValues.SetValues(entity);
        }

        public void AddDelete<TEntity>(long id) where TEntity : Entity
        {
            var dbSet = databaseContext.Set<TEntity>();

            var entityDb = dbSet.SingleOrDefault(x => x.Id == id);

            if (entityDb is null)
            {
                throw new System.Exception("Nenhum resultado encontrado para exclusão de dados");
            }

            databaseContext.Entry(entityDb).State = EntityState.Deleted;
            dbSet.Remove(entityDb);
        }

        public void SaveAll() => databaseContext.SaveChanges();
    }
}