﻿using Microsoft.EntityFrameworkCore;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq.Dynamic.Core;

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

        private void LoadPropertiesEntities(object entity)
        {
            var properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<LoadEntityAttribute>();
                if (attribute != null && !string.IsNullOrWhiteSpace(attribute.NameForeignKey))
                {
                    var foreignKey = entity.GetType().GetProperty(attribute.NameForeignKey);
                    if (foreignKey != null)
                    {
                        var valueObject = foreignKey.GetValue(entity);
                        if (valueObject != null)
                        {
                            long idLoad = (long)valueObject;
                            var queryable = (IQueryable<object>)databaseContext.GetType().GetMethods().First(item => item.Name == "Set" && item.GetParameters().Length == 0).MakeGenericMethod(property.PropertyType).Invoke(databaseContext, null);
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

        public TEntity GetById(long id, bool loadDependencies = false)
        {
            var entity = dbSet.FirstOrDefault($"Id == {id}");

            if (entity is null)
            {
                string nameEntity = typeof(TEntity).Name;
                throw new Exception($"Nenhum resultado encontrado para o id '{id}' na entidade '{nameEntity}'.");
            }

            if (loadDependencies)
            {
                LoadPropertiesEntities(entity);
            }

            return entity;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, TEntity defaultResult = null, bool loadDependencies = false)
        {
            var entity = dbSet.FirstOrDefault(expression);
            if (entity is null)
            {
                return defaultResult;
            }

            if (loadDependencies)
            {
                LoadPropertiesEntities(entity);
            }

            return entity;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression, TEntity defaultResult = null, bool loadDependencies = false)
        {
            var entity = dbSet.SingleOrDefault(expression);
            if (entity is null)
            {
                return defaultResult;
            }

            if (loadDependencies)
            {
                LoadPropertiesEntities(entity);
            }

            return entity;
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression, bool loadDependencies = false)
        {
            var entities = dbSet.Where(expression)?.ToList();

            if (entities?.Any() ?? false && loadDependencies)
            {
                foreach (var entity in entities)
                {
                    LoadPropertiesEntities(entity);
                }
            }

            return entities;
        }

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
                        LoadPropertiesEntities(entity);
                    }
                }
            }

            return (data, count);
        }

        public long Add(TEntity entity)
        {
            BeforeAdd(entity);
            dbSet.Add(entity);
            databaseContext.SaveChanges();
            AfterAdd(entity);
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            TEntity entityDb = GetById(entity.Id, false);
            string json = System.Text.Json.JsonSerializer.Serialize(entityDb);
            BeforeUpdate(entityDb, entity);
            databaseContext.Entry(entityDb).State = EntityState.Modified;
            databaseContext.Entry(entityDb).CurrentValues.SetValues(entity);
            databaseContext.SaveChanges();
            var oldEntity = System.Text.Json.JsonSerializer.Deserialize<TEntity>(json);
            AfterUpdate(oldEntity, entity);
        }

        public void DeleteById(long id)
        {
            TEntity entity = GetById(id, false);
            BeforeDelete(entity);
            databaseContext.Entry(entity).State = EntityState.Deleted;
            dbSet.Remove(entity);
            databaseContext.SaveChanges();
            AfterDelete(entity);
        }

        protected virtual void BeforeAdd(TEntity entity) { }

        protected virtual void AfterAdd(TEntity entity) { }

        protected virtual void BeforeUpdate(TEntity oldValue, TEntity newValue) { }

        protected virtual void AfterUpdate(TEntity oldValue, TEntity newValue) { }

        protected virtual void BeforeDelete(TEntity entity) { }

        protected virtual void AfterDelete(TEntity entity) { }
    }
}
