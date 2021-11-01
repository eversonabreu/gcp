using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class PessoaEntity : Entity
    {
        public long IdArquivoFoto { get; set; }

        public long IdNaturalidade { get; set; }

        public long IdNacionalidade { get; set; }

        public long IdClassificacaoDoenca { get; set; }

        public long IdCorRaca { get; set; }

        public long IdMunicipio { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public string OrgaoEmissorRG { get; set; }

        public DateTime DataEmissaoRG { get; set; }

        public DateTime DataNascimento { get; set; }

        public char Genero { get; set; }

        public bool PCD { get; set; }

        public string EnderecoRua { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoComplemento { get; set; }

        public string EnderecoCEP { get; set; }

        public string ChaveAcesso { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdArquivoFoto))]
        public ArquivoFotoEntity ArquivoFoto { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdNaturalidade))]
        public NaturalidadeEntity Naturalidade { get; set; }

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
        [Dependency(NameForeignKey = nameof(IdMunicipio))]
        public MunicipioEntity Municipio { get; set; }
    }
}
