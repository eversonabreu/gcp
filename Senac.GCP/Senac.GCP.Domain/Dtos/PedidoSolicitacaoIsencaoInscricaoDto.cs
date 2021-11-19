namespace Senac.GCP.Domain.Dtos
{
    public struct PedidoSolicitacaoIsencaoInscricaoDto
    {
        public long Id { get; set; }

        public bool Aprovado { get; set; }

        public string MotivoReprovacao { get; set; }

        public long IdPessoa { get; set; }

        public long IdInscricao { get; set; }
    }
}