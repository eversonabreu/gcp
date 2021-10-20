using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Entities.Base;
using Senac.GCP.Domain.Repositories.Base;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Utils;
using System;
using System.Text.Json;

namespace Senac.GCP.API.Controllers.Base
{
    public class Controller<TModel, TEntity> : ControllerBase where TModel : Model where TEntity : Entity
    {
        protected Token Token { get; private set; }
        private readonly IRepository<TEntity> repository;

        public Controller(IService<TEntity> service)
        {
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

        [HttpPost]
        public virtual long Post([FromBody] TModel model)
        {
            model.Validate();
            var entity = model.ToEntity<TEntity>();
            return repository.Add(entity);
        }

        [HttpPut]
        public virtual void Put([FromBody] TModel model)
        {
            model.Validate(validateId: true);
            var entity = model.ToEntity<TEntity>(model.Id!.Value);
            repository.Update(entity);
        }

        [HttpDelete]
        public virtual void Delete(long id)
        {
            repository.DeleteById(id);
        }

        [Route("id/{id:long}"), HttpGet]
        public virtual TEntity GetById(long id) => repository.GetById(id);

        [HttpGet]
        public virtual ResultSet<TEntity> Get(string filter, string sort = null!, uint page = 0, uint limit = 10, bool loadDependencies = false)
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
