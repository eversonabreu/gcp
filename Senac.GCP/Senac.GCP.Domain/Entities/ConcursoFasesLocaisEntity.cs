using Senac.GCP.Domain.Attributes;
using Senac.GCP.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senac.GCP.Domain.Entities
{
    [Constraint(Name = "FKConcursoFasesLocaisIdConcursoFases", ErrorMessage = "O campo 'Concurso Fases' não é válido ou não foi atribuído corretamente.")]
    [Constraint(Name = "UKConcursoFasesLocaisIdConcursoFases", ErrorMessage = "Não é possível salvar, porque já existe um registro neste campo.")]
    [Constraint(Name = "FKConcursoFasesLocaisIdMunicipioEndereco", ErrorMessage = "O município de endereço não é válido ou não foi atribuído corretamente.")]
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
        public MunicipioEntity MunicipioEndereco { get; set; }
    }
}