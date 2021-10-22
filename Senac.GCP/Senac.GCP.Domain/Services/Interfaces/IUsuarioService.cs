﻿using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IUsuarioService : IService<UsuarioEntity>
    {
        void EnviarEmailUsuarioParaConfirmacaoDeCadasatro(long idUsuario, string nome, string email, string senha);
    }
}
