using Senac.GCP.API.Models.Base;

namespace Senac.GCP.API.Models
{
    public sealed class ConcursoFaseCargoModel : Model
    {
        public long IdCargo { get; set; }

        public long IdConcursoCargo { get; set; }
    }
}
