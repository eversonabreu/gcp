using Microsoft.EntityFrameworkCore;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace Senac.GCP.Infraestructure.Database.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DatabaseContext databaseContext;
        private readonly DbSet<TEntity> dbSet;

        public Repository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            dbSet = databaseContext.Set<TEntity>();
        }

        private void LoadDependencies(object entity)
        {
            var properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DependencyAttribute>();
                if (attribute != null && !string.IsNullOrWhiteSpace(attribute.NameForeignKey))
                {
                    var foreignKey = entity.GetType().GetProperty(attribute.NameForeignKey);
                    if (foreignKey != null)
                    {
                        var valueObject = foreignKey.GetValue(entity);
                        if (valueObject != null)
                        {
                            long idLoad = (long)valueObject;
                            var queryable = (IQueryable<object>)databaseContext.GetType().GetMethods().First(item => item.Name == "Set"
                                && item.GetParameters().Length == 0).MakeGenericMethod(property.PropertyType).Invoke(databaseContext, null);
                            var entityObject = queryable.FirstOrDefault($"Id == {idLoad}");
                            if (entityObject != null)
                            {
                                property.SetValue(entity, entityObject);
                            }
                        }
                    }
                }
            }
        }

        private TEntity GetById(long id, bool loadDependencies)
        {
            var entity = dbSet.FirstOrDefault($"Id == {id}");

            if (entity is null)
            {
                string nameEntity = typeof(TEntity).Name;
                throw new DbException($"Nenhum resultado encontrado para o id '{id}' na entidade '{nameEntity}'.");
            }

            if (loadDependencies)
            {
                LoadDependencies(entity);
            }

            return entity;
        }

        public TEntity GetById(long id) => GetById(id, false);

        public TEntity GetByIdWithDependencies(long id) => GetById(id, true);

        private TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, bool loadDependencies)
        {
            var entity = dbSet.FirstOrDefault(expression);
            if (entity is null)
            {
                return null;
            }

            if (loadDependencies)
            {
                LoadDependencies(entity);
            }

            return entity;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression) => FirstOrDefault(expression, false);

        public TEntity FirstOrDefaultWithDependencies(Expression<Func<TEntity, bool>> expression) => FirstOrDefault(expression, true);

        private TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression, bool loadDependencies)
        {
            var entity = dbSet.SingleOrDefault(expression);
            if (entity is null)
            {
                return null;
            }

            if (loadDependencies)
            {
                LoadDependencies(entity);
            }

            return entity;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression) => SingleOrDefault(expression, false);

        public TEntity SingleOrDefaultWithDependencies(Expression<Func<TEntity, bool>> expression) => SingleOrDefault(expression, true);

        private IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression, bool loadDependencies)
        {
            var entities = dbSet.Where(expression)?.ToList();

            if (entities?.Any() ?? false && loadDependencies)
            {
                foreach (var entity in entities)
                {
                    LoadDependencies(entity);
                }
            }

            return entities;
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression) => Filter(expression, false);

        public IEnumerable<TEntity> FilterWithDependencies(Expression<Func<TEntity, bool>> expression) => Filter(expression, true);

        public (IEnumerable<TEntity> Data, int Count) FilterWithPagination(string expression, string sort = null, uint page = 0, uint limit = 10, bool loadDependencies = false)
        {
            var data = dbSet.Where(expression);
            int count = data?.Count() ?? 0;

            if (!string.IsNullOrWhiteSpace(sort) && count > 0)
            {
                data = data.OrderBy($"{sort}");
            }

            if (limit > 0)
            {
                int skip = (int)(page * limit);
                data = data?.Skip(skip).Take((int)limit);
            }

            if (data != null)
            {
                var dataList = data.ToList();
                if (loadDependencies)
                {
                    foreach (var entity in dataList)
                    {
                        LoadDependencies(entity);
                    }
                }
            }

            return (data, count);
        }

        public long Add(TEntity entity)
        {
            dbSet.Add(entity);
            Commit();
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            TEntity entityDb = GetById(entity.Id);
            databaseContext.Entry(entityDb).State = EntityState.Modified;
            databaseContext.Entry(entityDb).CurrentValues.SetValues(entity);
            Commit();
        }

        public void DeleteById(long id)
        {
            TEntity entity = GetById(id);
            databaseContext.Entry(entity).State = EntityState.Deleted;
            dbSet.Remove(entity);
            Commit(true);
        }

        private void Commit(bool isDelete = false)
        {
            try
            {
                databaseContext.SaveChanges();
            }
            catch (Exception exc)
            {
                if (isDelete)
                {
                    throw new DbException("Não é possível excluir este registro, porque ele possui registros dependentes. Exclua primeiro os registros dependentes");
                }
                else
                {
                    ApplyErrorConstraint(exc);
                }
            }
        }

        private static void ApplyErrorConstraint(Exception exception)
        {
            string message = (exception.InnerException ?? exception).Message;
            var constraints = typeof(TEntity).GetCustomAttributes<ConstraintAttribute>();
            if (constraints != null)
            {
                string error = message.ToUpper();
                foreach (var item in constraints)
                {
                    if (error.Contains(item.Name.ToUpper()))
                        throw new DbException(item.ErrorMessage);
                }
            }

            throw new DbException(message);
        }
    }
}