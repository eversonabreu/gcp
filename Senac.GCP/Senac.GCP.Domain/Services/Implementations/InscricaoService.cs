using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Dtos;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Enums;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Text;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class InscricaoService : Service<InscricaoEntity>, IInscricaoService
    {
        private readonly IInscricaoRepository inscricaoRepository;
        private readonly IConcursoCargoRepository concursoCargoRepository;
        private readonly IConcursoRepository concursoRepository;
        private readonly ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository;

        public InscricaoService(IInscricaoRepository inscricaoRepository,
            IConcursoCargoRepository concursoCargoRepository,
            IHttpContextAccessor httpContextAccessor,
            ISolicitacaoIsencaoInscricaoRepository solicitacaoIsencaoInscricaoRepository,
            IConcursoRepository concursoRepository)
                : base(inscricaoRepository, httpContextAccessor)
        {
            this.inscricaoRepository = inscricaoRepository;
            this.concursoCargoRepository = concursoCargoRepository;
            this.solicitacaoIsencaoInscricaoRepository = solicitacaoIsencaoInscricaoRepository;
            this.concursoRepository = concursoRepository;
        }

        public override void BeforePost(InscricaoEntity entity)
        {
            ValidarDatas(entity);
            GerarNumeroInscricao(entity);
            entity.Situacao = SituacaoInscricaoEnum.AguardandoPagamento;
        }

        private void GerarNumeroInscricao(InscricaoEntity entity)
        {
            do
            {
                var num = new StringBuilder();
                num.Append('1');

                for (int aux = 0; aux < 8; aux++)
                {
                    var random = new Random();
                    num.Append(random.Next(0, 10));
                }

                string numeroInscricao = num.ToString();
                if (inscricaoRepository.SingleOrDefault(x => x.NumeroInscricao == numeroInscricao) is null)
                {
                    entity.NumeroInscricao = numeroInscricao;
                    break;
                }

            } while (true);
        }

        public void ValidarDatas(InscricaoEntity entity)
        {
            var concurso = concursoCargoRepository.GetByIdWithDependencies(entity.IdConcursoCargo).Concurso;

            if (entity.DataInscricao < concurso.DataInicioInscricao)
                throw new BusinessException("A data de inscriçao não pode ser inferior a data de início do concurso!");

            if (entity.DataInscricao > concurso.DataFinalInscricao)
                throw new BusinessException("A data de inscriçao não pode ser superior a data final de incrição do concurso!");

            if (entity.DataPagamento < concurso.DataInicioInscricao)
                throw new BusinessException("A data de pagamento não pode ser inferior a data de incrição!");

            if (entity.DataPagamento > concurso.DataFinalInscricao)
                throw new BusinessException("A data de pagamento não pode ser superior a data final de incrição!");
        }

        public ValorPagamentoInscricaoDto ObterValorPagamento(long idInscricao)
        {      
            var valorPagamentoInscricaoDto = new ValorPagamentoInscricaoDto();
            var valorInscricao = concursoRepository.GetById(idInscricao).ValorInscricao;
            var solicitacaoIsencaoInscricao = solicitacaoIsencaoInscricaoRepository
                .SingleOrDefaultWithDependencies(x => x.IdInscricao == idInscricao);

            if (solicitacaoIsencaoInscricao != null)
            {
                if (solicitacaoIsencaoInscricao.SituacaoSolicitacao == SituacaoSolicitacaoIsencaoInscricaoEnum.Aprovado)
                {
                    var percentualIsencao = solicitacaoIsencaoInscricao
                        .TipoSolicitacaoIsencaoInscricao.PercentualIsencaoInscricao;
                    valorInscricao -= valorInscricao * (percentualIsencao / 100);
                    valorPagamentoInscricaoDto.InscricaoIsenta = valorInscricao == 0m;
                }
                else if (solicitacaoIsencaoInscricao.SituacaoSolicitacao == SituacaoSolicitacaoIsencaoInscricaoEnum.EmAnalise)
                {
                    valorPagamentoInscricaoDto.PossuiPedidoDeIsencaoEmAndamento = true;
                }
            }

            valorPagamentoInscricaoDto.Valor = valorInscricao;
            return valorPagamentoInscricaoDto;
        }

        public void EfetuarPagamento(long idInscricao, int tipoPagamento)
        {
            if (tipoPagamento != 1 && tipoPagamento != 2)
                throw new BusinessException("Tipo de pagamento inválido");

            var valorPagamentoDto = ObterValorPagamento(idInscricao);

            if (valorPagamentoDto.InscricaoIsenta)
                throw new BusinessException("Não é possível efetuar o pagamento porque a inscrição foi considerada isenta.");

            if (valorPagamentoDto.PossuiPedidoDeIsencaoEmAndamento)
                throw new BusinessException(@"Não é possível efetuar o pagamento porque 
                                                existe um pedido de solicitação de isenção em análise.
                                                Aguarde a resposta da equipe de organização do concurso.");

            var inscricao = inscricaoRepository.GetById(idInscricao);
            inscricao.DataPagamento = DateTime.Now;
            inscricao.TipoPagamento = (TipoPagamentoEnum)tipoPagamento;
            inscricao.ValorPago = valorPagamentoDto.Valor.Value;
            inscricaoRepository.Update(inscricao);
        }
        //criar um metodo para envio de email notificando que o pagamento foi realizado com sucesso
        //mandar a ficha de inscrição (no futuro).
    }
}