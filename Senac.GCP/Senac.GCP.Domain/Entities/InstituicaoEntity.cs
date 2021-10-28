using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class InstituicaoEntity : Entity
    {
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string EnderecoRua { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoNumero { get; set; }

        public string EnderecoComplemento { get; set; }

        public string EnderecoCEP { get; set; }

        public bool Ativo { get; set; }

        public string Observacoes { get; set; }

        public long IdMunicipio { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdMunicipio))]
        public MunicipioEntity Municipio { get; set; }
    }
}