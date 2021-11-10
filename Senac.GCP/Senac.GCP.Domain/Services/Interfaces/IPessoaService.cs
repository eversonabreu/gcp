using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IPessoaService : IService<PessoaEntity>
    {
        void ResetarChaveAcesso(long idPessoa);

        void AlterarChaveAcesso(long idPessoa, string chaveAcessoAtual, string novaChaveAcesso);

        void BloquearUsuario(long idPessoa, string motivoBloqueio);
    }
}