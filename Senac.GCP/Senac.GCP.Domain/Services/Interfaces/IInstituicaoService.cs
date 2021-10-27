﻿using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IInstituicaoService : IService<InstituicaoEntity> 
    {
        void ValidarDuplicidadeCNPJ(string cnpj, long? idInstituicao = null);
    }

}