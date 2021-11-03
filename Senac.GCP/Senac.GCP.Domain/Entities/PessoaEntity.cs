using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class PessoaEntity : Entity
    {
        public long IdArquivoFoto { get; set; }

        public long IdMunicipioNaturalidade { get; set; }

        public long IdMunicipioEndereco { get; set; }

        public long IdNacionalidade { get; set; }

        public long IdClassificacaoDoenca { get; set; }

        public long IdCorRaca { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public DateTime DataEmissaoRG { get; set; }

        public string OrgaoEmissorRG { get; set; }

        public char Genero { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool PCD { get; set; }

        public string EnderecoRua { get; set; }

        public string EnderecoNumero { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoComplemento { get; set; }

        public string EnderecoCEP { get; set; }

        public bool Bloqueado { get; set; }

        public string ChaveAcesso { get; set; }

        public string MotivoBloqueio { get; set; }

        public DateTime DataBloqueio { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdArquivoFoto))]
        public ArquivoEntity ArquivoFoto { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdNacionalidade))]
        public NacionalidadeEntity Nacionalidade { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdClassificacaoDoenca))]
        public ClassificacaoDoencaEntity ClassificacaoDoenca { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdCorRaca))]
        public CorRacaEntity CorRaca { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdMunicipioNaturalidade))]
        public MunicipioEntity MucipioNaturalidade { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdMunicipioEndereco))]
        public MunicipioEntity MucipioEndereco { get; set; }

    }
}