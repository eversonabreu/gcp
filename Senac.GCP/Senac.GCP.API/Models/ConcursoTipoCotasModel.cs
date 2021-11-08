using Senac.GCP.API.Models.Base;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoTipoCotasModel : Model
    {
        public long IdConcurso { get; set; }

        public long IdTipoCota { get; set; }

        public int PercentualVagas { get; set; }
    }
}
