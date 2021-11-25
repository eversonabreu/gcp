using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Infrastructure.Database.Repositories.Base;
using System.Linq;

namespace Senac.GCP.Infrastructure.Database.Repositories
{
    public sealed class ArquivoRepository : Repository<ArquivoEntity>, IArquivoRepository
    {
        public ArquivoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public bool ObterDocumentos(long idSolicitacaoIsencaoInscricao)
        {
            var tipoDocumento = (from doc in databaseContext.DocumentosSolicitacaoIsencaoInscricao
                                 join arq in databaseContext.Arquivo on doc.IdArquivo equals arq.Id
                                 where doc.IdSolicitacaoIsencaoInscricao == idSolicitacaoIsencaoInscricao
                                 select arq
                                ).FirstOrDefault();
            if (tipoDocumento == null)
                return true;
            else
                return false;
        }
    }
}