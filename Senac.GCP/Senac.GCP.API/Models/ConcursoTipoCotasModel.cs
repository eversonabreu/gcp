using Senac.GCP.API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoTipoCotasModel : Model
    {
        public long IdConcurso { get; set; }

        public long IdTipoCota { get; set; }

        [Range(minimum: 0, maximum: 100, ErrorMessage = "O percentual do tipo da cota deve estar entre 0 (zero) e 100 (cem)")]
        public int PercentualVagas { get; set; }
    }
}
