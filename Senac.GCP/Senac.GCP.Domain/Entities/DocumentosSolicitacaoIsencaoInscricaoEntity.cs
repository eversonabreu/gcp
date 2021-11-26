using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FkDocumentosSolicitacaoIsencaoInscricaoIdSolicitacaoIsencaoInscricao", ErrorMessage = "O Id de Solicitacao de Isencao e Inscricao não é válido ou não foi atribuído corretamente")]
    [Constraint(Name = "FkDocumentosSolicitacaoIsencaoInscricaoIdArquivo", ErrorMessage = "O Id do Arquivo não foi atribuído corretamente")]
    public sealed class DocumentosSolicitacaoIsencaoInscricaoEntity : Entity
    {
        public long IdSolicitacaoIsencaoInscricao { get; set; }

        public long IdArquivo { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdSolicitacaoIsencaoInscricao))]
        public SolicitacaoIsencaoInscricaoEntity SolicitacaoIsencaoInscricao { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdArquivo))]
        public ArquivoEntity Arquivo { get; set; }
    }
}