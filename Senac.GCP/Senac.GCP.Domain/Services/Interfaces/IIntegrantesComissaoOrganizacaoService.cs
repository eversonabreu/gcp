using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;
using System.Threading.Tasks;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IIntegrantesComissaoOrganizacaoService : IService<IntegrantesComissaoOrganizacaoRepository>
    {
        bool VerificarExistenciaDeIntegrantesPorInscricao(long idInscricao);

        void EnviarNotificacaoSobrePedidoDeSolicitacaoDeIsencao(long idInscricao);
    }
}