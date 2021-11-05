﻿using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IPessoaService : IService<PessoaEntity>
    {
        void ResetarChaveAcesso(long idPessoa);
    }
}