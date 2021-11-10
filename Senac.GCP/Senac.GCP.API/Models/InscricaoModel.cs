using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Enums;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class InscricaoModel : Model
    {
        public long IdPessoa { get; set; }

        public long IdConcurso { get; set; }

        public DateTime DataInscricao { get; set; }

        public SituacaoInscricaoEnum Situacao { get; set; }

        public bool ParticiparComoCotista { get; set; }

        public string MotivoRecusaInscricao { get; set; }

        public DateTime DataRecusaInscricao { get; set; }
    }
}