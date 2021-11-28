using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Notifications;
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
        private readonly IEmailService emailService;

        public ConcursoCargoCandidatoLocalService(IConcursoCargoCandidatoLocalRepository concursoCargoCandidatoLocalRepository,
            IHttpContextAccessor httpContextAccessor,
            IInscricaoRepository inscricaoRepository,
            IConcursoFasesLocaisSalaRepository concursoFasesLocaisSalaRepository, 
            IEmailService emailService)
            : base(concursoCargoCandidatoLocalRepository, httpContextAccessor)
        {
            this.inscricaoRepository = inscricaoRepository;
            this.concursoFasesLocaisSalaRepository = concursoFasesLocaisSalaRepository;
            this.emailService = emailService;
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

            var concursoCargoCandidatoLocalRepository = (IConcursoCargoCandidatoLocalRepository)GetRepository();
            bool localEstaTotalmenteAlocado;

            if (inscricao.Pessoa.PCD)
            {

                int quantidadeCarteirasPCD = salas.Sum(x => x.QuantidadeDeCarteirasPcd);
                localEstaTotalmenteAlocado = concursoCargoCandidatoLocalRepository
                    .ObterQuantidadeAlocadosPorLocalPCD(idConcursoFasesLocais) == quantidadeCarteirasPCD;
            }
            else
            {
                int quantidadeCarteirasNormais = salas.Sum(x => x.QuantidadeDeCarteiras);
                localEstaTotalmenteAlocado = concursoCargoCandidatoLocalRepository
                    .ObterQuantidadeAlocadosPorLocal(idConcursoFasesLocais) == quantidadeCarteirasNormais;
            }

            if (localEstaTotalmenteAlocado)
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

            EnviarEmailDeConfirmacaoDaSelecao(idInscricao);
        }

        private void EnviarEmailDeConfirmacaoDaSelecao(long idPessoa)
        {
            var pessoa = inscricaoRepository.GetByIdWithDependencies(idPessoa).Pessoa;
            var local = concursoFasesLocaisSalaRepository.GetById(idPessoa).ConcursoFasesLocais;
            var envioEmail = emailService
                             .WithTitle("GCP - Confirmação da seleção do local")
                             .WithBody(@$"<h4>Prezado(a): <b>{pessoa.Nome}</b>, sua seleção do local da prova 
                                       foi confirmada com sucesso:
                                       Local: {local.NomeLocal}
                                       Endereço: {local.EnderecoRua}, {local.EnderecoNumero} - Bairro: {local.EnderecoBairro}
                                       CEP: {local.EnderecoCEP}
                                       Complemento: {local.EnderecoComplemento}", true)
                             .WithRecipient(pessoa.Email)
                             .Send();
            if (!envioEmail)
            {
                throw new SendEmailException(@"Houve uma falha ao enviar o e-mail de confirmação");
            }
        }
    }
   
}