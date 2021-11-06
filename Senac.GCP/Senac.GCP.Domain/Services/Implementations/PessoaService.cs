using Microsoft.AspNetCore.Http;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Base;
using Senac.GCP.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace Senac.GCP.Domain.Services.Implementations
{
    public sealed class PessoaService : Service<PessoaEntity>, IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly INacionalidadeRepository nacionalidadeRepository;

        public PessoaService(IPessoaRepository pessoaRepository, IHttpContextAccessor httpContextAccessor, INacionalidadeRepository nacionalidadeRepository)
            : base(pessoaRepository, httpContextAccessor)
        {
            this.pessoaRepository = pessoaRepository;
            this.nacionalidadeRepository = nacionalidadeRepository;
        }

        private static string GerarChaveAcesso()
        {
            var colunasChaveAcesso = Guid.NewGuid().ToString().Split('-');
            string chaveAcesso = $"{colunasChaveAcesso.First()}{colunasChaveAcesso.Last()}";
            return chaveAcesso;
        }

        public override void BeforePost(PessoaEntity entity)
        {
            ValidarNacionalidadeBrasileira(entity.IdNacionalidade, entity.IdMunicipioNaturalidade);
            entity.ChaveAcesso = GerarChaveAcesso();
            //tua tarefa....
            //ver como foi implementado no usuário...
            //e enviar e-mail para a pessoa com a sua chave....

            //tbm criar método para alteração de chave de acesso
            //tbm criar método reset desta chave
        }

        public void ValidarNacionalidadeBrasileira(long idNacionalidade, long? IdMunicipioNaturalidade = null)
        {
            var nacionalidadeInformada = nacionalidadeRepository.SingleOrDefault(x => x.Id == idNacionalidade);

            if (nacionalidadeInformada.Nome == "Brasileiro(a)" && !IdMunicipioNaturalidade.HasValue)
                throw new Exception("Você deve informar sua naturalidade.");
        }

    }
}