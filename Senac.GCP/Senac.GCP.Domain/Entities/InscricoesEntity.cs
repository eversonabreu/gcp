//using Senac.GCP.Domain.Attributes;
//using Senac.GCP.Domain.Entities.Base;
//using System;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Senac.GCP.Domain.Entities
//{
//    public sealed class InscricoesEntity : Entity
//    {
//        public long IdPessoa { get; set; }

//        public long IdConcurso { get; set; }

//        public DateTime DataInscricao { get; set; }

//        public string NumeroInscricao { get; set; }

//        public int Situacao { get; set; }

//        public bool ParticiparComoCotista { get; set; }

//        public string MotivoRecusaInscricao { get; set; }

//        public DateTime DataRecusaInscricao { get; set; }

//        [NotMapped]
//        [Dependency(NameForeignKey = nameof(IdPessoa))]
//        public PessoaEntity Pessoa { get; set; }

//        [NotMapped]
//        [Dependency(NameForeignKey = nameof(IdConcurso))]
//        public ConcursoEntity Concurso { get; set; }
//    }
//}