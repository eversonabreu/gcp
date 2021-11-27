using Senac.GCP.API.Models.Base;


namespace Senac.GCP.API.Models
{
    public sealed class ConcursoCargoCandidatoLocalModel : Model
    {
        public long IdInscricao{ get; set; }

        public long IdConcursoFasesLocais { get; set; }
    }
}