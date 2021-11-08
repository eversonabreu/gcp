using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    public sealed class ConcursoFasesLocaisEntity : Entity
    {
        public long IdConcursoFases { get; set; }

        public string NomeLocal { get; set; }

        public string EnderecoRua { get; set; }

        public string EnderecoNumero { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoComplemento { get; set; }

        public string EnderecoCEP { get; set; }

        public long IdMunicipioEndereco { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdConcursoFases))]
        public ConcursoFasesEntity ConcursoFases { get; set; }

        [NotMapped]
        [Dependency(NameForeignKey = nameof(IdMunicipioEndereco))]
        public MunicipioEntity MucipioEndereco { get; set; }

    }
}