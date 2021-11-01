using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class DocumentosSolicitacaoIsencaoInscricaoEntity : Entity
    {
        public long IdSolicitacaoIsencaoInscricao { get; set; }
        public long IdArquivo { get; set; }        
        public long IdTipoSolicitacaoIsencaoInscricao { get; set; }
       
        //[Dependency(NameForeignKey = nameof(IdSolicitacaoIsencaoInscricao))]
        //public SolicitacaoIsencaoInscricaoEntity SolicitacaoIsencaoInscricao { get; set; }

        [Dependency(NameForeignKey = nameof(IdArquivo))]
        public ArquivoEntity Arquivo { get; set; }

        [Dependency(NameForeignKey = nameof(IdTipoSolicitacaoIsencaoInscricao))]
        public TipoSolicitacaoIsencaoInscricaoEntity TipoSolicitacaoIsencaoInscricao { get; set; }


    }
}