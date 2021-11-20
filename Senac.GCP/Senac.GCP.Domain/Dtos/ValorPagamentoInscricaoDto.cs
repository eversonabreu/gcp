namespace Senac.GCP.Domain.Dtos
{
    public struct ValorPagamentoInscricaoDto
    {
        public decimal? Valor { get; set; }

        public bool PossuiPedidoDeIsencaoEmAndamento { get; set; }

        public bool InscricaoIsenta { get; set; }
    }
}