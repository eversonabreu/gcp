using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class InscricaoModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "A 'Pessoa' deve ser informada obrigatoriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O tamanho do campo 'Pessoa' não pode superar 255 caractéres.")]
        public long IdPessoa { get; set; }

        [Required(ErrorMessage = "O Campo 'IdConcurso' Deve Ser Informado Obrigatóriamente.")]
        [DateOnly]
        public long IdConcurso { get; set; }

        [Required(ErrorMessage = "O Campo 'Data da Inscricao' Deve Ser Informado Obrigatóriamente.")]        
        [DateOnly]
        public DateTime DataInscricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Número da inscrição' Deve Ser Informado Obrigatóriamente.")]
        public string NumeroInscricao { get; set; }

        public int Situacao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A 'Pessoa' deve ser informada obrigatoriamente.")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Participar como cotista' deve ser informado")]
        public bool ParticiparComoCotista { get; set; }

        public string MotivoRecusaInscricao { get; set; }

        [Required(ErrorMessage = "O Campo 'Data da Recusa' Deve Ser Informado Obrigatóriamente.")]
        public DateTime DataRecusaInscricao { get; set; }

        public PessoaModel Pessoa { get; set; }
       
        public ConcursoModel Concurso { get; set; }


    }
}