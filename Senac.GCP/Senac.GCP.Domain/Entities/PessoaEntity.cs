using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKPessoaIdArquivoFoto", ErrorMessage = "A 'Foto' deve ser enviada obrigatóriamente")]
    [Constraint(Name = "FKPessoaIdClassificacaoDoenca", ErrorMessage = "A 'Classificação de Doença' é inválida")]
    [Constraint(Name = "FKPessoaIdCorRaca", ErrorMessage = "A 'Cor/Raça' é inválida ou não informada")]
    [Constraint(Name = "FKPessoaIdMunicipioEndereco", ErrorMessage = "O 'Município de Endereço' é inválido ou não informado")]
    [Constraint(Name = "FKPessoaIdMunicipioNaturalidade", ErrorMessage = "O 'Município de Naturalidade' é inválido")]
    [Constraint(Name = "FKPessoaIdNacionalidade", ErrorMessage = "A 'Nacionalidade' é inválida ou não informada")]
    [Constraint(Name = "UKPessoaCPF", ErrorMessage = "Não é possível salvar, porque já existe um registro com este CPF")]
    [Constraint(Name = "UKPessoaEmail", ErrorMessage = "Não é possível salvar, porque já existe um registro com este E-mail")]
    public sealed class PessoaEntity : Entity
    {
        public long IdArquivoFoto { get; set; }

        public long? IdMunicipioNaturalidade { get; set; }

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

        [NotUpdated]
        public bool Bloqueado { get; set; }

        [NotUpdated]
        public string ChaveAcesso { get; set; }

        [NotUpdated]
        public string MotivoBloqueio { get; set; }

        [NotUpdated]
        public DateTime? DataBloqueio { get; set; }

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
        public MunicipioEntity MunicipioNaturalidade { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdMunicipioEndereco))]
        public MunicipioEntity MunicipioEndereco { get; set; }
    }
}