using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infrastructure.Database.Repositories.Base;
using System.Linq;

namespace Senac.GCP.Infrastructure.Database.Repositories
{
    public sealed class TipoSolicitacaoIsencaoInscricaoRepository : Repository<TipoSolicitacaoIsencaoInscricaoEntity>, ITipoSolicitacaoIsencaoInscricaoRepository
    {
        public TipoSolicitacaoIsencaoInscricaoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public decimal ObterPercentualDeIsencaoPorInscricao(long idInscricao)
        {
            var tipoSolicitacao = (from sol in databaseContext.SolicitacaoIsencaoInscricao
                                   join tip in databaseContext.TipoSolicitacaoIsencaoInscricao on sol.IdTipoSolicitacaoIsencaoInscricao equals tip.Id
                                   where sol.IdInscricao == idInscricao
                                   select tip
                                  ).FirstOrDefault();

            if (tipoSolicitacao is null)
                throw new BusinessException($"Nenhum tipo de solicitação de isenção de inscrição encontrado para a inscrição de ID: {idInscricao}.");

            return tipoSolicitacao.PercentualIsencaoInscricao;
        }
    }
}