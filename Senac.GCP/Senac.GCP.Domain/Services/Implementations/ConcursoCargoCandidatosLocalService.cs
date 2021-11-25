﻿using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class ConcursoCargoCandidatoLocalService : Service<ConcursoCargoCandidatoLocalEntity>, 
        IConcursoCargoCandidatoLocalService
    {
        private readonly IInscricaoRepository inscricaoRepository;
        private readonly IConcursoFasesLocaisSalaRepository concursoFasesLocaisSalaRepository;

        public ConcursoCargoCandidatoLocalService(IConcursoCargoCandidatoLocalRepository concursoCargoCandidatoLocalRepository, 
            IHttpContextAccessor httpContextAccessor,
            IInscricaoRepository inscricaoRepository,
            IConcursoFasesLocaisSalaRepository concursoFasesLocaisSalaRepository)
            : base(concursoCargoCandidatoLocalRepository, httpContextAccessor)
        {
            this.inscricaoRepository = inscricaoRepository;
            this.concursoFasesLocaisSalaRepository = concursoFasesLocaisSalaRepository;
        }

        public void SelecionarLocalFase(long idInscricao, long idConcursoFasesLocais)
        {
            var inscricao = inscricaoRepository.GetByIdWithDependencies(idInscricao);
            if (inscricao.Situacao != Enums.SituacaoInscricaoEnum.Pago &&
                inscricao.Situacao != Enums.SituacaoInscricaoEnum.Isento)
                throw new BusinessException(@"Não é possível proceder com a seleção do local,
                                              porque o valor da inscrição ainda não foi pago
                                              ou existe uma solicitação de isenção pendente ou 
                                              a inscrição foi recusada");

            var salas = concursoFasesLocaisSalaRepository.Filter(x => x.IdConcursoFasesLocais == idConcursoFasesLocais);
            if (!salas.Any())
                throw new BusinessException("Não existem salas disponíveis no local selecionado");

            var concursoCargoCandidatoLocalRepository = (IConcursoCargoCandidatoLocalRepository) GetRepository();
            bool localEstaTotalAlocado;

            if (inscricao.Pessoa.PCD)
            {
                
                int quantidadeCarteirasPCD = salas.Sum(x => x.QuantidadeDeCarteirasPcd);
                localEstaTotalAlocado = concursoCargoCandidatoLocalRepository
                    .ObterQuantidadeAlocadosPorLocalPCD(idConcursoFasesLocais) == quantidadeCarteirasPCD;
            }
            else
            {
                int quantidadeCarteirasNormais = salas.Sum(x => x.QuantidadeDeCarteiras);
                localEstaTotalAlocado = concursoCargoCandidatoLocalRepository
                    .ObterQuantidadeAlocadosPorLocal(idConcursoFasesLocais) == quantidadeCarteirasNormais;
            }

            if (localEstaTotalAlocado)
                throw new BusinessException("O local selecionado não possui mais vagas disponíveis. Selecione outro local.");

            VincularLocalFase(idInscricao, idConcursoFasesLocais);
        }

        private void VincularLocalFase(long idInscricao, long idConcursoFasesLocais)
        {
            var concursoCargoCandidatoLocalRepository = GetRepository();
            
            var concursoCargoCandidatoLocal = new ConcursoCargoCandidatoLocalEntity
            {
                IdConcursoFasesLocais = idConcursoFasesLocais,
                IdInscricao = idInscricao
            };

            concursoCargoCandidatoLocalRepository.Add(concursoCargoCandidatoLocal);

            //fazer um método para envio de e-mail avisando a pessoa que a seleção ocorreu com sucesso!
        }
    }
}