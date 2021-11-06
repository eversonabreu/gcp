using Senac.GCP.API.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class Inscricoes : Model
    {
        public long IdPessoa { get; set; }

        public long IdConcurso { get; set; }

        public DateTime DataInscricao { get; set; }

        public string NumeroInscricao { get; set; }

        public int Situacao { get; set; }

        public bool ParticiparComoCotista { get; set; }

        public string MotivoRecusaInscricao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O 'Nome' não foi preenchido")]
        [StringLength(maximumLength: 200, ErrorMessage = "O 'Nome' aceita no máx 200 caracteres")]

        public DateTime DataRecusaInscricao { get; set; }

        public PessoaModel Pessoa { get; set; }
       
        public ConcursoModel Concurso { get; set; }


    }
}