﻿using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infraestructure.Database.Repositories.Base;

namespace Senac.GCP.Infraestructure.Database.Repositories
{
    public sealed class ArquivoRepository : Repository<ArquivoEntity>, IArquivoRepository
    {
        public ArquivoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}