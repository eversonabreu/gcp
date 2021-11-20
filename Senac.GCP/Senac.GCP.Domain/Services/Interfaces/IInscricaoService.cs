using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Base;

namespace Senac.GCP.Domain.Services.Interfaces
{
    public interface IInscricaoService : IService<InscricaoEntity>
    {
        ValorPagamentoInscricaoDto ObterValorPagamento(long idInscricao);

        void EfetuarPagamento(long idInscricao, int tipoPagamento);
    }
}