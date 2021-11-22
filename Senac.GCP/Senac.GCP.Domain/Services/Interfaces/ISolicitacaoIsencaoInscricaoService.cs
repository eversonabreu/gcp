using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface ISolicitacaoIsencaoInscricaoService : IService<SolicitacaoIsencaoInscricaoEntity>
    {
        void ResponderPedidoDeIsencao(PedidoSolicitacaoIsencaoInscricaoDto pedidoSolicitacaoIsencaoInscricaoDto);
    }
}