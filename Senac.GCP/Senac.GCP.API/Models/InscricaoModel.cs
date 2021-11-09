using Senac.GCP.API.Models.Base;
using System;

namespace Senac.GCP.API.Models
{
    public sealed class InscricaoModel : Model
    {
        public long IdPessoa { get; set; }

        public long IdConcurso { get; set; }

        public DateTime DataInscricao { get; set; }

        public int Situacao { get; set; }

        public bool ParticiparComoCotista { get; set; }

        public string MotivoRecusaInscricao { get; set; }

        public DateTime DataRecusaInscricao { get; set; }
    }
}