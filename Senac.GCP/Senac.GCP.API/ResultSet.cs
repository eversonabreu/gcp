using Senac.GCP.Domain.Entities.Base;
using System.Collections.Generic;

namespace Senac.GCP.API
{
    public sealed class ResultSet<TEntity> where TEntity : Entity
    {
        public IEnumerable<TEntity> Data { get; private set; }

        public int Count { get; private set; }

        public ResultSet(IEnumerable<TEntity> data, int count)
        {
            Data = data;
            Count = count;
        }
    }
}
