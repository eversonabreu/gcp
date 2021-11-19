using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IIntegrantesComissaoOrganizacaoService : IService<IntegrantesComissaoOrganizacaoEntity>
    {
        bool VerificarExistenciaDeIntegrantesPorInscricao(long idInscricao);

        void EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencao(long idInscricao);
    }
}