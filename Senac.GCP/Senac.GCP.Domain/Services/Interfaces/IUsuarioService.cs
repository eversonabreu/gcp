using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IUsuarioService : IService<UsuarioEntity>
    {
        void ValidarDuplicidadeEmailUsuario(string email, long? idUsuario = null);

        void ValidarDuplicidadeCPFUsuario(string cpf, long? idUsuario = null);

        void EnviarEmailUsuarioParaConfirmacaoDeCadasatro(long idUsuario, string nome, string email, string senha);

        void AlterarSenha(long idUsuario, string senhaAtual, string novaSenha);
    }
}
