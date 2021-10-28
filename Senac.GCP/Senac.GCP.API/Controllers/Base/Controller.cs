using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Repositories.Base;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Utils;
using System;
using System.Reflection;
using System.Text.Json;

namespace Senac.GCP.API.Controllers.Base
{
    public class Controller<TModel, TEntity> : ControllerBase where TModel : Model where TEntity : Entity
    {
        protected Token Token { get; private set; }
        private readonly IService<TEntity> service;
        private readonly IRepository<TEntity> repository;

        public Controller(IService<TEntity> service)
        {
            this.service = service;
            repository = service.GetRepository();
            ValidarToken(service.GetHttpContext());
        }

        private static Token GetDataToken(HttpContext httpContext)
        {
            string bearer = httpContext.Request.Headers["Authorization"];
            string jsonToken = bearer[7..].Decrypt();
            var result = JsonSerializer.Deserialize<Token>(jsonToken);
            return result;
        }

        private void ValidarToken(HttpContext httpContext)
        {
            try
            {
                var dataToken = GetDataToken(httpContext);
                if (DateTime.Now > dataToken.DataExpiracao)
                {
                    throw new Exception();
                }

                Token = dataToken;
            }
            catch
            {
                throw new Exception("401");
            }
        }

        private void SetPropertiesNotUpdated(TEntity entity)
        {
            var dbEntity = repository.GetById(entity.Id);
            var properties = dbEntity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<NotUpdatedAttribute>();
                if (attribute != null)
                {
                    var value = property.GetValue(dbEntity);
                    property.SetValue(obj: entity, value);
                }
            }
        }

        [HttpPost]
        public long Post([FromBody] TModel model)
        {
            model.Validate();
            var entity = model.ToEntity<TEntity>();
            service.BeforePost(entity);
            var id = repository.Add(entity);
            service.AfterPost(entity);
            return id;
        }

        [HttpPut]
        public void Put([FromBody] TModel model)
        {
            model.Validate(validateId: true);
            var entity = model.ToEntity<TEntity>(model.Id!.Value);
            SetPropertiesNotUpdated(entity);
            service.BeforePut(entity);
            repository.Update(entity);
            service.AfterPut(entity);
        }

        [HttpDelete]
        public void DeleteById(long id)
        {
            service.BeforeDelete(id);
            repository.DeleteById(id);
            service.AfterDelete(id);
        }

        [Route("id/{id:long}"), HttpGet]
        public TEntity GetById(long id) => repository.GetById(id, true);

        [HttpGet]
        public ResultSet<TEntity> Get(string filter, string sort = null!, uint page = 0, uint limit = 10, bool loadDependencies = false)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return new ResultSet<TEntity>(null!, 0);
            }

            var (Data, Count) = repository.FilterWithPagination(filter, sort, page, limit, loadDependencies);
            return new ResultSet<TEntity>(Data, Count);
        }
    }
}