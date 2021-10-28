using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IUsuarioService : IService<UsuarioEntity>
    {
        void AlterarSenha(long idUsuario, string senhaAtual, string novaSenha);
    }
}
