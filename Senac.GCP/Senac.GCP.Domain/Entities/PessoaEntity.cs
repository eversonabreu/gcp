using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;


namespace Senac.GCP.Domain.Entities
{
    public sealed class PessoaEntity : Entity
    {
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

        public long IdNacionalidade { get; set; }

        public long IdClassificacaoDoenca { get; set; }

        public long IdCorRaca { get; set; }

        public string EnderecoRua { get; set; }

        public string EnderecoNumero { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoComplemento { get; set; }

        public string EnderecoCEP { get; set; }

        public long IdMunicipio { get; set; }

        public bool Ativo { get; set; }

        public string ChaveAcesso { get; set; }

        public long IdArquivoFoto { get; set; }

        public long IdNaturalidade { get; set; }

    }
}
